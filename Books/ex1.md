
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

## Blogs: 


* MATLAB Trading - http://matlab-trading.blogspot.co.uk/
* Quantitative Trading (Ernest Chan) - http://epchan.blogspot.com 
* Quantivity - http://quantivity.wordpress.com
* Quantopian - http://blog.quantopian.com
* Quantpedia - http://quantpedia.com
* Quantocracy - http://www.quantocracy.com
* Quant News - http://www.quantnews.com
* Algo Trading Sub-Reddit - http://www.reddit.com/r/algotrading
* Elite Trader Forums - http://www.elitetrader.com
* Nuclear Phynance - http://www.nuclearphynance.com • QuantNet - http://www.quantnet.com
* Wealth Lab - http://www.wealth-lab.com/Forum
* Wilmott Forums - http://www.wilmott.com
  
## accadamic journals: 

* arXiv - http://arxiv.org/archive/q-fin
* SSRN - http://www.ssrn.com
* Journal of Investment Strategies - http://www.risk.net/type/journal/source/journal- of-investment-strategies
* Journal of Computational Finance - http://www.risk.net/type/journal/source/journal- of-computational-finance
* Mathematical Finance - http://onlinelibrary.wiley.com/journal/10.1111/%28ISSN%291467- 9965



## ai 
* Machine learning/artificial intelligence - Machine learning algorithms have become more prevalent in recent years in financial markets. Classifiers (such as Naive-Bayes, et al.) non-linear function matchers (neural networks) and optimisation routines (genetic algorithms) have all been used to predict asset paths or optimise trading strategies. If you have a background in this area you may have some insight into how particular algorithms might be applied to certain markets.

<br/>
<br/>

# Evaluating Trading Strategies
* Sharpe Ratio - The Sharpe ratio heuristically characterises the reward/risk ratio of the strategy. It quantifies how much return you can achieve for the level of volatility endured by the equity curve. Naturally, we need to determine the period and frequency that these returns and volatility (i.e. standard deviation) are measured over. A higher frequency strategy will require greater sampling rate of standard deviation, but a shorter overall time period of measurement, for instance.
* What is sharp ratio: The Sharpe ratio is used to evaluate the performance of a trading strategy by comparing it to a risk-free investment, such as a U.S. Treasury bond. The higher the Sharpe ratio, the better the strategy is performing on a risk-adjusted basis. A Sharpe ratio of 1 or higher is considered good, while a ratio of 2 or higher is considered excellent. However, it's important to note that the Sharpe ratio should not be the only factor used to evaluate a trading strategy, and it should be used in conjunction with other metrics and analysis.
  
* Leverage - Does the strategy require significant leverage in order to be profitable? Does the strategy necessitate the use of leveraged derivatives contracts (futures, options, swaps) in order to make a return? These leveraged contracts can have heavy volatility charac- terises and thus can easily lead to margin calls. Do you have the trading capital and the temperament for such volatility?


* Win/Loss, Average Profit/Loss - Strategies will differ in their win/loss and average profit/loss characteristics. One can have a very profitable strategy, even if the number of losing trades exceed the number of winning trades. Momentum strategies tend to have this pattern as they rely on a small number of "big hits" in order to be profitable. Mean- reversion strategies tend to have opposing profiles where more of the trades are "winners", but the losing trades can be quite severe.

* Maximum Drawdown - The maximum drawdown is the largest overall peak-to-trough percentage drop on the equity curve of the strategy. Momentum strategies are well known to suffer from periods of extended drawdowns (due to a string of many incremental losing trades). Many traders will give up in periods of extended drawdown, even if historical testing has suggested this is "business as usual" for the strategy. You will need to determine what percentage of drawdown (and over what time period) you can accept before you cease trading your strategy. This is a highly personal decision and thus must be considered carefully.
  
<br/>

* Parameters - Certain strategies (especially those found in the machine learning commu- nity) require a large quantity of parameters. Every extra parameter that a strategy requires leaves it more vulnerable to optimisation bias (also known as "curve-fitting"). You should try and target strategies with as few parameters as possible or make sure you have sufficient quantities of data with which to test your strategies on.
  
  <br>

* we have not discussed the actual returns of the strategy. Why is this? In isolation, the returns actually provide us with limited information as to the effectiveness of the strategy. They don’t give you an insight into leverage, volatility, benchmarks or capital requirements. Thus strategies are rarely judged on their returns alone. Always consider the risk attributes of a strategy before looking at the returns.



## different data: 
* News Data - News data is often qualitative in nature. It consists of articles, blog posts, microblog posts ("tweets") and editorial. Machine learning techniques such as classifiers are often used to interpret sentiment. This data is also often freely available or cheap, via subscription to media outlets. The newer "NoSQL" document storage databases are designed to store this type of unstructured, qualitative data.

<br>
<br>
<br>

## Python Environments: 
* Ubuntu Desktop Linux - The operating system
* Python - The core programming environment
* NumPy/SciPy - For fast, efficient vectorised array/matrix calculation 
* IPython - For visual interactive development with Python
* matplotlib - For graphical visualisation of data
* pandas - For data "wrangling" and time series analysis
* scikit-learn - For machine learning and artificial intelligence algorithms 
*  IbPy - To carry out trading with the Interactive Brokers API


<br>

<br/>

# More of backtesting 
* if the strategy looks good in training data but looks bad in out of sample deta, don't try to improve it, if you keep improving you can finally make it look good but just turned a out of sample data in to training data! 
* There is a general approach to trading strategy construction that can min- imize data-snooping bias: make the model as simple as possible, with as few parameters as possible. Many traders appreciate the second edict, but fail to realize that a model with few parameters but lots of complicated trading rules are just as susceptible to data-snooping bias. Both edicts lead to the conclusion that nonlinear models are more susceptib
* for high frequancy trading, backtesting is not enough, you have consider other factors such as order execution and leverage 




## Bollinger bands: 

 Bollinger Bands are a technical analysis tool that consists of two lines plotted two standard deviations away from a simple moving average (SMA) of a security's price. The upper and lower bands represent the price volatility of a security. When the price of a security moves toward the upper band, it is considered overbought, and when it moves toward the lower band, it is considered oversold.

* For short-term traders, such as day traders or scalpers, Bollinger Bands  with a period of 10 or 20 and a timeframe of 1-minute, 5-minutes or 15-minutes are often used.

* For swing traders, who hold positions for several days or weeks, Bollinger Bands with a period of 20 or 50 and a timeframe of 1-hour, 4-hours or daily charts may be used.

* For long-term traders or investors, who hold positions for months or even years, Bollinger Bands with a longer period, such as 100 or 200, and a timeframe of weekly or monthly charts are often used.

<br>
<br>
<br>





# Mean Reversion

 Alas, most price series are not mean reverting, Those few price series that are found to be mean reverting are called stationary. we can often combine two or more individual price series that are not mean reverting into a portfolio whose net market value (i.e., price) is mean reverting (called cointegrating).

<br>
The mathematical description of a mean-reverting price series is that the change of the price series in the next period is proportional to the difference between the mean price and the current price. This gives rise to the ADF test, which tests whether we can reject the null hypothesis that the propor- tionality constant is zero.

<br>

## how to test if a data series follow Mean reversion

* Augmented Dickey-FullerTest: it tests the stationarity and determines if a data series follow mean reversio or not Code: 
```python
import yfinance as yf 
import datetime as dt 
import matplotlib.pyplot as plt 

from statsmodels.tsa.stattools import adfuller

start = "2021-06-01"
end = "2023-03-20"

sympol = '^IXIC'
data = yf.download(sympol,start, end,interval="1h") # "Valid intervals: [1m, 2m, 5m, 15m, 30m, 60m, 90m, 1h, 1d, 5d, 1wk, 1mo, 3mo]"


plt.plot(data["Close"])
plt.title("Nasdaq daily price")
plt.xlabel("Date")
plt.ylabel("Price")
#plt.show()

result = adfuller(data["Close"])
print(f'ADF Statistic: {result[0]}')
print(f'n_lags: {result[1]}')
print(f'p-value: {result[1]}')
for key, value in result[4].items():
    print('Critial Values:')
    print(f'   {key}, {value}') 

  # in this exemple we get a p-value of 0.7 and adf score of -1.12 which is not enough to pass the test for 90% confident level it has to be less than -2.56 for higher confident levels it has to be even lower 

```


* Hurst Exponent andVariance RatioTest to see if the data series follow mean reversion, It is calculated by analyzing the range of values in different time windows of a time series, a stationary series should have a constant mean, variance, and autocovariance structure over time.
 
If the Hurst exponent is less than 0.5 (i.e., between 0.4 and 0.6), the series is said to be characterized by short-term dependencies and is considered stationary. If the Hurst exponent is significantly greater than 0.5 (i.e., above 0.6), the series is said to be characterized by long-term dependencies and is considered non-stationary. It is better if the value is less than 0.5 code: 
```python

import yfinance as yf 
import datetime as dt 
import matplotlib.pyplot as plt 
from hurst import compute_Hc

from statsmodels.tsa.stattools import adfuller

start = "2023-03-01"
end = "2023-03-20"

sympol = '^IXIC'
data = yf.download(sympol,start, end,interval="1h") # "Valid intervals: [1m, 2m, 5m, 15m, 30m, 60m, 90m, 1h, 1d, 5d, 1wk, 1mo, 3mo]"


H, c, data = compute_Hc(data["Close"], kind='price', simplified=True)


print("Hurst exponent for Nasdaq close price: {}".format(H))
# we get the value 0.54 which is very close the mean reversion but not really 

```

<br/>
<br/>
<br/>




* Half-Life of Mean Reversion: The half-life of mean reversion refers to the time it takes for a series or process to revert halfway back to its long-term mean or average. 
  
This connection between a regression coefficient λ and the half-life of mean reversion is very useful to traders. First, if we find that λ is positive, this means the price series is not at all mean reverting, and we shouldn’t even attempt to write a mean- reverting strategy to trade it. Second, if λ is very close to zero, this means the half-life will be very long, and a mean-reverting trading strategy will not be very profitable because we won’t be able to complete many round-trip trades in a given time period. Third, this λ also determines a natural time scale for many parameters in our strategy. For example, if the half life is 20 days, we shouldn’t use a look-back of 5 days to compute a moving average or standard deviation for a mean-reversion strategy. Often, setting the look- back to equal a small multiple of the half-life is close to optimal, and doing so will allow us to avoid brute-force optimization of a free parameter based on the performance of a trading strategy.We will demonstrate how to com- pute half-life in Example 2.4.

<br>
In general, a shorter half-life value indicates a faster rate of mean reversion, which may be desirable for short-term trading strategies that aim to capture small price movements. On the other hand, a longer half-life value may be more appropriate for longer-term investments or portfolios that aim to capture larger trends and avoid overreacting to short-term market fluctuations.







