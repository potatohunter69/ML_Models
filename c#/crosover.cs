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

// period = 10 min 

namespace NinjaTrader.NinjaScript.Strategies
{
    public class MovingAverageCrossoverStrategy : Strategy
    {
        private SMA sma10;
        private SMA sma50;

        protected override void OnStateChange()
        {
            if (State == State.SetDefaults)
            {
                Description = "Moving Average Crossover Strategy";
                Name = "MovingAverageCrossoverStrategy";
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
                BarsRequiredToTrade = 50;

                // default values 
                takeProfit = 1100;                     //   (1000,500,40,63,45) good winrate
				stopLoss = 800;
                minPriceDistance = 42;
            }
            else if (State == State.Configure)
            {
                // Add the 10-period and 50-period Simple Moving Averages
                sma10 = SMA(10);
                AddChartIndicator(sma10);
                
                sma50 = SMA(50);
                AddChartIndicator(sma50);

            }
        }

        protected override void OnBarUpdate()
        {
            if (CurrentBar < BarsRequiredToTrade)
                return;

            if (isLongEntery())
            {
                // Generate a buy signal
                EnterLong();
            }
            else if (isShortEntery())
            {
                // Generate a sell signal
                EnterShort();
            }
    
            // set profit target and stop loss orders in courrency
            SetProfitTarget(CalculationMode.Currency, takeProfit);
            SetStopLoss(CalculationMode.Currency, stopLoss);
            
        }

        public bool isLongEntery(){
            //if (CrossAbove(sma10, sma50, 1) && priseDistanceOk() || Close [0] > SMA(Close, 10)[0] 
            //    && Close [0] > SMA(Close, 50)[0] && priseDistanceOk())
            //{
            if (CrossAbove(sma10, sma50, 1) && priseDistanceOk()){
                return true;
            }
            return false;
        }

        public bool isShortEntery(){
            //if (CrossBelow(sma10, sma50, 1) && priseDistanceOk() || Close [0] < SMA(Close, 10)[0] 
            //    && Close [0] < SMA(Close, 50)[0] && priseDistanceOk())
            //{
            if (CrossBelow(sma10, sma50, 1) && priseDistanceOk()){
                return true;
            }
            return false;
        }

        public bool priseDistanceOk(){
            double priceDistance = Math.Abs(Close[0] - SMA(Close, 10)[0]);
            return priceDistance > minPriceDistance;
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
        [Display(ResourceType = typeof(Custom.Resource), Name = "Minimum Price Distance", Description= "Minimum Price Distance")]
        public double minPriceDistance
        {get; set;}
    }
}

