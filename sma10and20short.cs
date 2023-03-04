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
	public class Bot2 : Strategy
	{
		
		// Set the parameters for the moving averages
		int maFast = 10;
		int maSlow = 20;
		int maFilter = 50;
		int rsiPeriod = 20;
		
		public double MyVolume;
				
		
		protected override void OnStateChange()
		{
			if (State == State.SetDefaults)
			{
				Description									= @"10and20SMA(Short)";
				Name										= "sma10and20(short)";
				Calculate									= Calculate.OnBarClose;
				EntriesPerDirection							= 10;
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
				BarsRequiredToTrade							= 1;
				// Disable this property for performance gains in Strategy Analyzer optimizations
				// See the Help Guide for additional information
				IsInstantiatedOnEachOptimizationIteration	= true;
				
				
				takeProfit = 1000;                     //   (1000,500,40,63,45) good winrate
				stopLoss = 900;
				minPriceDistance = 63;
				lowRSI= 27; 
				MyVolume = 45000;
			
			}
			else if (State == State.Configure)
			{
				
				
				AddChartIndicator(SMA(Close, maFast));
    			AddChartIndicator(SMA(Close, maSlow));
			//	AddChartIndicator(SMA(Close, maFilter));
			 	AddChartIndicator(RSI(rsiPeriod,1));
				AddChartIndicator(VOL());
				
				
			}
			
		}

		protected override void OnBarUpdate()
		{
			
			
			
		    if (IsShortEntry())
		    {
				SendMail("saminoorzy1@gmail.com", "Short Position Opened", "A position has been opened.");
		        EnterShort(1);
				SetStopLoss(CalculationMode.Currency, stopLoss);
    			SetProfitTarget(CalculationMode.Currency, takeProfit);
		    }
			
			
			
		   if (Position.MarketPosition == MarketPosition.Short && Close[0] > SMA(Close, maFast)[0])
		    {
		        ExitShort();
		    }
			
			
				
		}
		
		
		protected override void OnOrderUpdate(Order order, double limitPrice, double stopPrice, int quantity, int filled, double averageFillPrice, OrderState orderState, DateTime time, ErrorCode error, string nativeError)
		{
			
			    if (order.OrderState == OrderState.Filled && order.Name == "Profit Target" )
			    {
			       SendMail("saminoorzy1@gmail.com", "Profit Target", "Profit Target");
			    }
				
				 if (order.OrderState == OrderState.Filled &&  order.Name == "Stop Loss")
			    {
			       SendMail("saminoorzy1@gmail.com", "Stop Loss", "Stop Loss");
			    }

		 
		}		
		 
		
		
		

		private bool IsShortEntry()
		{
			
			
			double priceDistance = Math.Abs(Close[0] - SMA(Close, maFast)[0]); 
		    return Close[0] < SMA(Close, maFast)[0] && SMA(Close, maFast)[0] < SMA(Close, maSlow)[0]   &&  RSI(rsiPeriod,1)[0] > lowRSI &&
				 priceDistance > minPriceDistance && CheckVolume() && CandleChck();// && IsTradeTime();
			
			
		}
		
		
		
		private bool IsTradeTime()
		{
			
		    int hour = Time[0].Hour;
		    if(hour >= 17 && hour <= 18){
				return false;
			}
			
			
			return true; 
		}
		
		
		
		
		
		private bool CheckVolume()
		{
			
			
			if(VOL()[0] < MyVolume && VOL()[1] < MyVolume){
				
				return true; 
			}
		    
			return false;
		}
		
		
		
		
		
		private bool CandleChck()
		{
		  
		    
			if (Close[0] < Close[1]){
				
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
		
		
		
		

		
	}
}
