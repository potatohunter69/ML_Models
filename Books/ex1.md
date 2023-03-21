
# Successful Algorithmic Trading Book

<style>
    /* set line-height to 2 to create larger spaces */
    n {
        line: 5;
    }
</style>


# Backtest 

**Commision:** All strategies require some form of access to an exchange, either directly or through a brokerage intermediary ("the broker"). These services incur an incremental cost with each trade, known as commission.


**Slippage:** Slippage is the difference in price achieved between the time when a trading system decides to transact and the time when a transaction is actually carried out at an exchange.

**Spread:** When you buy an asset, you typically pay the ask price, which is higher than the bid price. Similarly, when you sell an asset, you typically receive the bid price, which is lower than the ask price. The difference between these prices is the spread, which is essentially the cost of the transaction.


**Backtesting vs Reality:** The dangers of overfitting, poor data cleansing, incorrect handling of transac- tion costs, market regime change and trading constraints often lead to a backtest performance that differs substantially from a live strategy deployment.

**Overfitting:**  overfitting occurs when a model is too complex for the amount and quality of the available training data, and it starts to memorize the training data rather than learning to generalize from it. t is typically caused by using too many features or parameters in the model. 
It is also important to use cross-validation techniques to evaluate the model's generalization performance on unseen data, and to avoid selecting a model based solely on its performance on the training data
Try to peek indicators that are more general and not specefic to the training data 


**Latency:** Decreasing latency involves minimising the "distance" between the algorithmic trading system and the ultimate exchange on which an order is being executed. This can involve shortening the geographic distance between systems (and thus reducing travel down network cabling), reducing the processing carried out in networking hardware (important in HFT strategies) or choosing a brokerage with more sophisticated infrastructure.

<br/>
<br/>
<br/>

# Sourcing Strategy Ideas
* make strategies based on being aware of your own personality
  
* The next consideration is one of time. Do you have a full time job? Do you work part time? Do you work from home or have a long commute each day? These questions will help determine the frequency of the strategy that you should seek.
* for small balance restrict yourself to lowfrequency strategies 
  
  <br/>

## Sourcing Algorithmic Trading Ideas
Academic finance journals, pre-print servers, trading blogs, trad- ing forums, weekly trading magazines and specialist texts provide thousands of trading strategies with which to base your ideas upon.

* be extremely careful not to let cognitive biases influence our decision making methodology. This could be as simple as having a preference for one asset class over another (gold and other precious metals come to mind) because they are perceived as more exotic. Our goal should always be to find consistently profitable strategies, with positive expectation. The choice of asset class should be based on other considerations, such as trading capital constraints, brokerage fees and leverage capabilities.

<br/>
<br/>

### books for how capital markets work: 
<br/>

* Financial Times Guide to the Financial Markets (about different markets)
* Trading and Exchanges: Market Microstructure for Practitioners:  how trades are carried out, the various motives of the players and how markets are regulated
  
* Algorithmic Trading and DMA: An introduction to direct access trading strate- gies by Barry Johnson[10] - Johnson’s book is geared more towards the technological side of markets. It discusses order types, optimal execution algorithms, the types of exchanges that accept algorithmic trading as well as more sophisticated strategies. As with Harris’ book above, it explains in detail how electronic trading markets work, the knowledge of which I also believe is an essential prerequisite for carrying out systematic strategies.
  
* Quantitative Trading: How to Build Your Own Algorithmic Trading Business by Ernest Chan[5] - Ernest Chan’s first book is a “beginner’s guide” to quantitative trading strategies. While it is not heavy on strategy ideas, it does present a framework for how to setup a trading business, with risk management ideas and implementation tools. This is a great book if you are completely new to algorithmic trading. The book makes use of MATLAB.
  
* Algorithmic Trading: Winning Strategies and Their Rationale by Ernest Chan[6] - Chan’s second book is very heavy on strategy ideas. It essentially begins where the previous book left off and is updated to reflect “current market conditions”. The book discusses mean reversion and momentum based strategies at the interday and intraday frequencies. it also briefly touches on high-frequency trading. As with the prior book it makes extensive use of MATLAB code.
  
* Inside The Black Box: The Simple Truth About Quantitative and High-Frequency Trading, 2nd Ed by Rishi Narang[12] - Narang’s book provides an overview of the com- ponents of a trading system employed by a quantitative hedge fund, including alpha gener- ators, risk management, portfolio optimisation and transaction costs. The second edition goes into significant detail on high-frequency trading techniques.
  
* Volatility Trading by Euan Sinclair[16] - Sinclair’s book concentrates solely on volatility modelling/forecasting and options strategies designed to take advantage of these models. If you plan to trade options in a quantitative fashion then this book will provide many research ideas.



**Internet:** most of strategies in internet is based on technical analysis which is not reliable or accurate in its ability to predict future events or outcomes. As quants with a more sophisticated mathematical and statistical toolbox at our disposal, we can easily evaluate the effectiveness of such "TA-based" strategies. This allows us to make decisions driven by data analysis and hypothesis testing, rather than base such decisions on emotional considerations or preconceptions.




