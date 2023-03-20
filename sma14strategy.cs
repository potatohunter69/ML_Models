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
namespace NinjaTrader.NinjaScript.Strategies.mystrategies
{
	public class sma14strategy : Strategy
	{
		
		
		int sma14= 14; 
		
		
		protected override void OnStateChange()
		{
			if (State == State.SetDefaults)
			{
				Description									= @"Enter the description for your new custom Strategy here.";
				Name										= "sma14strategy";
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
				
				Size = 10;
				stopLoss = 300;
				profitTarget = 1100; 
				minPriceDistance = 35; 
				
				
			
			}
			else if (State == State.Configure)
			{
				
				
				AddChartIndicator(SMA(Close, sma14));
				AddChartIndicator(VOL());
				
				
			}
		}

		protected override void OnBarUpdate()
		{
			
			
			if(IsShortEntry() && IsTradeTime()){
				
				EnterShort(Size);
			}
			else if( IsLongEntery()  && IsTradeTime()){
				
				EnterLong(Size);
			}

			
				SetStopLoss(CalculationMode.Currency, stopLoss);
    			SetProfitTarget(CalculationMode.Currency, profitTarget);
			
		}
		
		
		
		
		
		private bool IsShortEntry()
		{

			double priceDistance = Math.Abs(Close[0] - SMA(Close, 14)[0]); 
		    return Close[0] < SMA(Close, sma14)[0] && Close[0] < Close[1]&& priceDistance > minPriceDistance ;
			return true; 
				
		}
		
		
		private bool IsLongEntery()
		{

			double priceDistance = Math.Abs(Close[0] - SMA(Close, 14)[0]); 
		    return Close[0] > SMA(Close, sma14)[0] && Close[0] > Close[1] && priceDistance > minPriceDistance ;
			return true; 
				
		}
		
		
		
		
				
		private bool IsTradeTime()
		{
			
			
			
			//  || hour > 20 && hour < 23
		    int hour = Time[0].Hour;
		    if(hour >= 1 && hour <= 24 ){
			//if(hour >= 1 && hour <= 24){ 
				return true;
			}
			
			/*
			
			DateTime currentTime = Time[0];
			
		    DateTime entryTime1 = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 15, 30, 0);
		    DateTime entryTime2 = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 16, 00, 0);
		    DateTime entryTime3 = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 16, 30, 0);
		    DateTime entryTime4 = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 17, 00, 0);

		    if (currentTime == entryTime1 || currentTime == entryTime2 || currentTime == entryTime3 || currentTime == entryTime4)
		    {
		      //  EnterLong();
				return true;
		    }
			
			*/
	
			
			return false; 
		}
		
		
		
		
		
		[NinjaScriptProperty]
		[Display(ResourceType = typeof(Custom.Resource), Name = "Stop Loss", Description= "Stop Loss")]
		public double stopLoss
		{get; set;}
		
		
		[NinjaScriptProperty]
		[Display(ResourceType = typeof(Custom.Resource), Name = "Take Profit", Description= "Take Profit")]
		public double profitTarget
		{get; set;}
		
		
		[NinjaScriptProperty]
		[Display(ResourceType = typeof(Custom.Resource), Name = "Size", Description= "Size")]
		public int Size
		{get; set;}
		
		[NinjaScriptProperty]
		[Display(ResourceType = typeof(Custom.Resource), Name = "Price Distance", Description= "Price Distance")]
		public double minPriceDistance
		{get; set;}
		
		

	}
}
