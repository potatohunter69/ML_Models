#ex1 

"""

-- advantages of algo trading : 
- backtesting 
- effecent 
- better for risk manegement 
- no fear and greed 
- high frequnciy, some of the most profitable strategies are based on high frequenciy trading





1- Identify a Trading Idea: Start by identifying a trading idea or hypothesis that you want to test. This could be based on a 
particular market inefficiency, a technical indicator, or a fundamental analysis of a particular stock or market.

2- Collect Data: Once you have identified a trading idea, you need to collect data to test your hypothesis. 
This could include historical market data, economic indicators, company financial statements, or other relevant data sources.

3- Backtesting: Use the collected data to backtest your trading idea. This involves running simulations of your trading strategy using 
historical data to see how it would have performed in the past.


4- Analyze Results: Analyze the backtesting results to determine if your trading idea is viable. Look at metrics such as profitability, 
risk, and drawdowns to assess the performance of your strategy.

5- Optimize Strategy: Based on the results of your backtesting, you may need to optimize your strategy by tweaking parameters or 
adjusting trading rules to improve performance.

6- after optimizing do walkforwad to validate your strategy in new environments 
    - Overall, while walk forward analysis without parameter optimization may not provide as much insight into the optimal 
    parameter settings for a trading strategy, it can still be a useful tool for validating the performance and robustness of 
    the strategy over time.

7- Paper Trading: Once you have optimized your strategy, test it out in a simulated or paper trading environment. This 
will help you determine how your strategy performs in real-time market conditions without risking real capital.

8- Live Trading: Finally, if your paper trading results are favorable, you may want to start trading your strategy with real 
capital. However, it is important to continue monitoring your strategy and making adjustments as needed to ensure continued success.





--- FIX backtesting bias

-- Optimisation bais(overfit): it involves adjusting or introduing additional tradign paramaters utill the strategy perfomance on the 
backtest data set is attractive. Since the its overoptimized it can perfom totaly different in live market
- Optimisation bias can be minmised by 
    - keeping the number of paramters to a minmum 
    - increase the quantity of data in backtest.
    - test the data in out-of sample data 
    - use sensetivity analysis: means varying the parameter incremetnly and plotting the performance, if the you have 
    very jummpy performance plott, it indicates overfiteing 


-- Look-ahead bias: the testing period uses information which is not avaliable when runing the strategy live
- only use information that is avaliable both in the past and in the real time 





--- Survivorship Bais 
- it occurs when strategies are tested on datasets that do not include the ful universe of prior assts and only include 
the those that have survived to the current time. 
- ex. consider testing a strategy on a random selection of companies before and after 2001 market crash, som tech stocks went bankrupt, 
while other managed to sruvive, if we strict the strategy to those who survived then promote survivship bias    
- in testing dont only peek the survivouse, in that case you over estimating, consider the losers too and the ration between losers 
and winners
- use more recnet data , after 3-4 year you normaly will have a solid suvivshiop-bias free data 




-- cognative bais 
- if you see a drawdownw that exceeds your limit, "EXPECT THE DRAWDOWN TO OCCURE IN THE FUTURE TOO", its better to solve it 
before runing in real time market. thiese periods of drawdown are psychologically difficult to endure
- the reason why we call it bias is because sometimes strategies may be realy good, but because of their bad drawdown in real time 
we stopp them, it's better to handle those darawdonw instead 





--- order types: 

- market order : executes a trade immeditely, aggrasive order order irrespective of availabel price 

- limit orders: A limit order is an order to buy or sell a security at a specified price or better. This means that the 
trade will only be executed if the market price reaches the specified limit price or better.

- Stop Order: A stop order is an order to buy or sell a security at a specified price, but only after the market 
has reached that price

-- prices in ninjatrader 
    Last Price: High-frequency traders may use the last traded price to capture momentum in the market and react 
    quickly to changes in price.

    Bid Price: Traders may use the bid price to execute trades quickly and at a lower cost, especially if they are looking to sell 
    a security.

    Ask Price: Traders may use the ask price to execute trades quickly and at a higher price, especially if they are looking to 
    buy a security.

    

--- transaction costs :

    - commision: is the price you have to pay to the broker every time you make a trade
    
    - Slippage: the difference in price achived between the time when the strategy decides to make a transiction and the 
    time when the transaction is actually done!. this can impact the strategy alot 

        - instruments with high volitility experince slippage a lot 


        

-- latency 
- for high frequancy trading latency matters, decreasing latency involves minimising the distance between the system and exchange 
    





"""





