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
				
				Size = 15;
				stopLoss = 300;
				profitTarget = 1000; 
				
				
			
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
			else if(IsLongEntery() && IsTradeTime()){
				
				EnterLong(Size);
			}

			
				SetStopLoss(CalculationMode.Currency, stopLoss);
    			SetProfitTarget(CalculationMode.Currency, profitTarget);
			
		}
		
		
		
		
		
		private bool IsShortEntry()
		{

			
		    return Close[0] < SMA(Close, sma14)[0]  && Close[0] < Close[1];
				
		}
		
		
		private bool IsLongEntery()
		{

			
		    return Close[0] > SMA(Close, sma14)[0]  && Close[0] > Close[1];
				
		}
		
		
		
		
				
		private bool IsTradeTime()
		{
			//  || hour > 20 && hour < 23
		    int hour = Time[0].Hour;
		    if(hour >= 15 && hour < 20 || hour == 3  || hour == 9  || hour == 11 ){
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
		public double profitTarget
		{get; set;}
		
		
		[NinjaScriptProperty]
		[Display(ResourceType = typeof(Custom.Resource), Name = "Size", Description= "Size")]
		public int Size
		{get; set;}


	}
}
