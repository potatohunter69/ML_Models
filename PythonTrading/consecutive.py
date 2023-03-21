import yfinance as yf
import pandas as pd
import matplotlib.pyplot as plt
import numpy as np
from scipy.stats import norm
import seaborn as sns
sns.set()

# Define the ticker symbol for NASDAQ
ticker_symbol = '^IXIC'

# Download the daily historical data for NASDAQ from Yahoo Finance
nasdaq_data = yf.download(ticker_symbol, start='2020-01-01', end='2023-03-18')

# Calculate the daily returns of NASDAQ
nasdaq_data['Returns'] = nasdaq_data['Close'].pct_change()

# Calculate the number of consecutive up/down days
nasdaq_data['Direction'] = nasdaq_data['Returns'].apply(lambda x: 1 if x > 0 else -1)
nasdaq_data['Consecutive'] = (nasdaq_data['Direction'] != nasdaq_data['Direction'].shift(1)).cumsum()

# Count the number of consecutive wins and losses
win_counts = nasdaq_data[nasdaq_data['Direction'] == 1]['Consecutive'].value_counts().sort_index()
lose_counts = nasdaq_data[nasdaq_data['Direction'] == -1]['Consecutive'].value_counts().sort_index()

# Plot the distribution of consecutive wins and losses
plt.figure(figsize=(12,6))
plt.bar(win_counts.index, win_counts.values, label='Consecutive Wins')
plt.bar(lose_counts.index, lose_counts.values, label='Consecutive Losses')
plt.title('Distribution of Consecutive Wins and Losses')
plt.xlabel('Consecutive Days')
plt.ylabel('Frequency')
plt.legend()
plt.show()

# Make a prediction for the next day based on the distribution of consecutive wins and losses
n_days = 1  # number of days to predict
win_prob = len(nasdaq_data[nasdaq_data['Direction'] == 1]) / len(nasdaq_data['Direction'])  # probability of a win
lose_prob = 1 - win_prob  # probability of a loss
win_mean = win_counts.mean()  # mean of consecutive wins
win_std = win_counts.std()  # standard deviation of consecutive wins
lose_mean = lose_counts.mean()  # mean of consecutive losses
lose_std = lose_counts.std()  # standard deviation of consecutive losses

# Generate a normal distribution for the number of consecutive wins and losses
win_dist = norm(loc=win_mean, scale=win_std)
lose_dist = norm(loc=lose_mean, scale=lose_std)

# Calculate the probability of winning and losing n_days in a row
win_n_days = win_dist.cdf(n_days) - win_dist.cdf(0)
lose_n_days = lose_dist.cdf(n_days) - lose_dist.cdf(0)

# Make a prediction for the next day based on the probabilities
#if win_n_days > lose_n_days:
print(f'Prediction: The NASDAQ will go up for the next {n_days} day(s) with a probability of {win_n_days:.2f}.')
#else:
print(f'Prediction: The NASDAQ will go down for the next {n_days} day(s) with a probability of {lose_n_days:.2f}.')


