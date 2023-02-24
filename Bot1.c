#region Using declarations
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Serialization;
using NinjaTrader.Cbi;
using NinjaTrader.Gui;
using NinjaTrader.Gui.Chart;
using NinjaTrader.Gui.SuperDom;
using NinjaTrader.Gui.Tools;
using NinjaTrader.Data;
using NinjaTrader.NinjaScript;
using NinjaTrader.Core.FloatingPoint;
using NinjaTrader.NinjaScript.Indicators;
using NinjaTrader.NinjaScript.DrawingTools;
#endregion

//This namespace holds Strategies in this folder and is required. Do not change it. 


// nasdaq 15 minuts chart 
namespace NinjaTrader.NinjaScript.Strategies.mystrategies
{
	public class sma10and20 : Strategy
	{
		
		// Set the parameters for the moving averages
		int maFast = 10;
		int maSlow = 20;
		int maFilter = 50;
		int rsiPeriod = 20;
	
				
		
		protected override void OnStateChange()
		{
			if (State == State.SetDefaults)
			{
				Description									= @"10and20SMA";
				Name										= "sma10and20";
				Calculate									= Calculate.OnBarClose;
				EntriesPerDirection							= 1;
				EntryHandling								= EntryHandling.AllEntries;
				IsExitOnSessionCloseStrategy				= true;
				ExitOnSessionCloseSeconds					= 30;
				IsFillLimitOnTouch							= false;
				MaximumBarsLookBack							= MaximumBarsLookBack.TwoHundredFiftySix;
				OrderFillResolution							= OrderFillResolution.Standard;
				Slippage									= 0;
				StartBehavior								= StartBehavior.WaitUntilFlat;
				TimeInForce									= TimeInForce.Gtc;
				TraceOrders									= false;
				RealtimeErrorHandling						= RealtimeErrorHandling.StopCancelClose;
				StopTargetHandling							= StopTargetHandling.PerEntryExecution;
				BarsRequiredToTrade							= 20;
				// Disable this property for performance gains in Strategy Analyzer optimizations
				// See the Help Guide for additional information
				IsInstantiatedOnEachOptimizationIteration	= true;
				
				
				takeProfit = 1000;                     //   (1000,500,40,63,45) good winrate
				stopLoss = 500;
				minPriceDistance = 40;
				highRSI= 63;
				lowRSI= 45; 
			}
			else if (State == State.Configure)
			{
				
				
				AddChartIndicator(SMA(Close, maFast));
    			AddChartIndicator(SMA(Close, maSlow));
				AddChartIndicator(SMA(Close, maFilter));
			 	AddChartIndicator(RSI(rsiPeriod,1));
				
				
			}
			
		}

		protected override void OnBarUpdate()
		{
			
			
			if (IsLongEntry())
		    {
		        EnterLong();
				SetStopLoss(CalculationMode.Currency, stopLoss);
    			SetProfitTarget(CalculationMode.Currency, takeProfit);
		    }
		    else if (IsShortEntry())
		    {
		        EnterShort();
				SetStopLoss(CalculationMode.Currency, 500);
    			SetProfitTarget(CalculationMode.Currency, 1000);
		    }
			
			
			if (Position.MarketPosition == MarketPosition.Long && Close[0] < SMA(Close, maFast)[0])
		    {
		        ExitLong();
		    }
		    else if (Position.MarketPosition == MarketPosition.Short && Close[0] > SMA(Close, maFast)[0])
		    {
		        ExitShort();
		    }
				
		}
			
		/*
		{
    double priceDistance = Math.Abs(Close[0] - SMA(Close, maFast)[0]);
    return Close[0] > SMA(Close, maFast)[0] && SMA(Close, maFast)[0] > SMA(Close, maSlow)[0] && SMA(Close, maSlow)[0] > SMA(Close, maFilter)[0] && priceDistance > minPriceDistance && Close[0] < SMA(Close, maSlow)[0] && Close[0] > Open[1] && RSI(rsiPeriod)[0] > 50 && IsTradeTime();
}
		
		*/
		
		
		
		// Define the long and short entry conditions with the filter
		private bool IsLongEntry()
		{
		    double priceDistance = Math.Abs(Close[0] - SMA(Close, maFast)[0]);
		    return Close[0] > SMA(Close, maFast)[0] && SMA(Close, maFast)[0] > SMA(Close, maSlow)[0] && 
				SMA(Close, maSlow)[0] > SMA(Close, maFilter)[0] && priceDistance > minPriceDistance && Close[0] > Open[1] && IsTradeTime() && RSI(rsiPeriod,1)[0] < highRSI;// && CheckVolume();
		}

		private bool IsShortEntry()
		{
		    double priceDistance = Math.Abs(Close[0] - SMA(Close, maFast)[0]);
		    return Close[0] < SMA(Close, maFast)[0] && SMA(Close, maFast)[0] < SMA(Close, maSlow)[0] && 
				SMA(Close, maSlow)[0] < SMA(Close, maFilter)[0] && priceDistance > minPriceDistance && Close[0] < Open[1] && IsTradeTime() && RSI(rsiPeriod,1)[0] > lowRSI;// && CheckVolume();
		}
		
		
		
		private bool IsTradeTime()
		{
		    int hour = Time[0].Hour;
		    return (hour >= 14 && hour <= 17) || (hour >= 20 && hour <= 23);
		}
		
		
		
		private bool CheckVolume()
		{
			 double volume = VolumeUpDown()[0];
			
			if(volume < 40000){
				
				return true; 
			}
		    
			return false;
		}
		
		
		
		
				
		
		
		
		[NinjaScriptProperty]
		[Display(ResourceType = typeof(Custom.Resource), Name = "Stop Loss", Description= "Stop Loss")]
		public double stopLoss
		{get; set;}
		
		
		[NinjaScriptProperty]
		[Display(ResourceType = typeof(Custom.Resource), Name = "Take Profit", Description= "Take Profit")]
		public double takeProfit
		{get; set;}
		
		
		[NinjaScriptProperty]
		[Display(ResourceType = typeof(Custom.Resource), Name = "Price Distance", Description= "Price Distance")]
		public double minPriceDistance
		{get; set;}
		
		
		
		[NinjaScriptProperty]
		[Display(ResourceType = typeof(Custom.Resource), Name = "Low RSI", Description= "Low RSI")]
		public double lowRSI
		{get; set;}
		
		
		[NinjaScriptProperty]
		[Display(ResourceType = typeof(Custom.Resource), Name = "highRSI", Description= "highRSI")]
		public double highRSI
		{get; set;}
		

	}
}
