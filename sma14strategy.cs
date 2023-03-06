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
using System.Threading; 
#endregion

//This namespace holds Strategies in this folder and is required. Do not change it. 
namespace NinjaTrader.NinjaScript.Strategies
{
	
	
	public class SMA14Strategy : Strategy
		{
		    
			private SMA sma;
    		private RSI rsi;
			private bool isMarketFlat; 
			
			
			


		    protected override void OnStateChange()
		    {
		        if (State == State.SetDefaults)
		        {
		            // Set the default strategy parameters
		            Description = "Strategy based on a 20-period SMA";
		            Name = "Moving Avrega Strategy";
		            Calculate = Calculate.OnBarClose;
		            EntriesPerDirection = 1;
		            EntryHandling = EntryHandling.AllEntries;
		            IsExitOnSessionCloseStrategy = true;
		            ExitOnSessionCloseSeconds = 30;
		            IsFillLimitOnTouch = false;
		            MaximumBarsLookBack = MaximumBarsLookBack.TwoHundredFiftySix;
		            OrderFillResolution = OrderFillResolution.Standard;
		            Slippage = 0;
		            StartBehavior = StartBehavior.WaitUntilFlat;
		            TimeInForce = TimeInForce.Gtc;
		            TraceOrders = false;
		            RealtimeErrorHandling = RealtimeErrorHandling.StopCancelClose;
		            StopTargetHandling = StopTargetHandling.PerEntryExecution;
		            BarsRequiredToTrade = 1;
					
					
					smaPeriod = 50; 
					rsiPeriod = 14;
					StopLoss = 500; 
					ProfitTarget = 1000; 
					
					flatThreshold = 5; 
					isMarketFlat = false; 
		
					
	

		            // Add a plot to display the SMA on the chart
		            AddPlot(new Stroke(Brushes.Blue, 2), PlotStyle.Line, "SMA");
		        }
		        else if (State == State.DataLoaded)
		        {
		            sma = SMA(smaPeriod);
            		rsi = RSI(rsiPeriod,1);
					
		           	 AddChartIndicator(sma);
					 AddChartIndicator(rsi);
					
					
					
		        }
		    }

		    protected override void OnBarUpdate()
		    {
				
				// Do nothing until we have enough bars for indicators
       			// if (CurrentBar < Math.Max(sma.Period, rsi.Period)) return;
				 
				 
				 // Determine if we are in an uptrend or downtrend
        		bool isUptrend = Close[0] > sma[0];
				 
				 
				double sma14Diff = Math.Abs(sma[0] - sma[1]);
				
				if (sma14Diff < flatThreshold)
			    {
			        isMarketFlat = true;
			    }
			    else
				{
			        isMarketFlat = false;
				}
				 
				
				if (!isMarketFlat)
				{
					
					if (isUptrend && rsi[0] < 70)
			        {
						
			            
			            EnterLong(1);

			            SetStopLoss(CalculationMode.Currency, StopLoss);
						SetProfitTarget(CalculationMode.Currency,ProfitTarget);
						

			        }
							 
					 
					  // Check for short entry signal
			        if (!isUptrend && rsi[0] > 30)
			        {
						
						 EnterShort(1);

			            SetStopLoss(CalculationMode.Currency, StopLoss);
						SetProfitTarget(CalculationMode.Currency,ProfitTarget);
						
						
			       
			        }
				}
						


		    }
			
			
			
			
			
			#region Properties
			// Define the profit target and stop loss properties in currency
			    [Range(0, int.MaxValue), NinjaScriptProperty]
			    [Display(Name = "smaPriod", Order = 1, GroupName = "Order Settings")]
			    public int smaPeriod { get; set; } 

			    [Range(0, int.MaxValue), NinjaScriptProperty]
			    [Display(Name = "rsiPeriod", Order = 2, GroupName = "Order Settings")]
			    public int rsiPeriod { get; set; } 
				
				
				[Range(0, double.MaxValue), NinjaScriptProperty]
			    [Display(Name = "Stop Loss", Order = 6, GroupName = "Order Settings")]
			    public double StopLoss { get; set; } 
				
				[Range(0, double.MaxValue), NinjaScriptProperty]
			    [Display(Name = "Profit Target", Order = 6, GroupName = "Order Settings")]
			    public double ProfitTarget { get; set; } 
				
				
				[Range(0, int.MaxValue), NinjaScriptProperty]
			    [Display(Name = "flatThreshold", Order = 4, GroupName = "Order Settings")]
			    public double flatThreshold { get; set; } 

				
			#endregion
		}

}
