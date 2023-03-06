# TradingBots


1- Defining the trading strategy and program 

2- Backtesting the strategy: Once the strategy is defined, the next step is to backtest it using historical data

3- Optimization: After backtesting the strategy, it is important to optimize it by testing different parameter values to determine the optimal combination. The optimization period should be between 6month to 2years 


4- Walk-forward testing: Once the strategy is optimized, it is important to perform walk-forward testing to evaluate its performance on out-of-sample data. This involves dividing the historical data into two parts, a training set and a testing set. The training set is used to optimize the strategy, while the testing set is used to evaluate its performance. The walk-forward period should much longer than
optimization period and you shouldn't include the omptimization period in walkforward. 

- The strategy's performance should be consistent across the different walk-forward periods. If the strategy performs well during the         optimization period but poorly during the walk-forward periods, then it may be overfitting 
-all the futueres and parameters should be added during the optimization period. 
- if the walk forward is negative then move on and fine a new strategy 


