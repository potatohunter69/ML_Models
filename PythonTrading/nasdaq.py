import yfinance as yf
import numpy as np
import matplotlib.pyplot as plt

from sklearn.pipeline import make_pipeline
from sklearn.preprocessing import StandardScaler
from sklearn.model_selection import GridSearchCV
from sklearn.svm import SVR

ticker_symbol = '^IXIC'
nasdaq_data = yf.download(ticker_symbol, '2005-01-01', '2023-03-17')

#sklearn.kernel_approximation.Nystroem


X = np.arange(nasdaq_data["Close"].shape[0]).reshape(-1, 1)
y = np.array(nasdaq_data["Close"])



X_scaler = StandardScaler()
y_scaler = StandardScaler()

X = X_scaler.fit_transform(X)
y = y_scaler.fit_transform(y.reshape(-1, 1)).reshape(-1)

parameters = {
    'kernel':('linear', 'rbf', "poly"), 
    'C':[0.5, 1, 3, 5, 7, 10],
    "degree": [1, 2, 3, 4]
}

clf = GridSearchCV(SVR(), parameters, cv=5, verbose=1)
clf.fit(X, y)

reg = clf.best_estimator_
reg.score(X, y)





X_pred = X_scaler.transform(np.arange(nasdaq_data["Close"].shape[0]*2).reshape(-1, 1))

y_pred = y_scaler.inverse_transform(reg.predict(X_pred).reshape(-1, 1)).reshape(-1)

plt.plot(np.arange(nasdaq_data["Close"].shape[0]*2), y_pred)
plt.plot(np.arange(nasdaq_data["Close"].shape[0]), nasdaq_data["Close"])
plt.show()