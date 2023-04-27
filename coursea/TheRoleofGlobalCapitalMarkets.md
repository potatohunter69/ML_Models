# machine learning in trading 

<br>
<br>
<br>


# leason 1 
* if you have a long position one risk manegment you can do is to have a sell order bullow the current price 
* buy apple if microsoft goes dowon 5% "assuming microsoft loss may benefit apple ", buy apple if "us unemployment rate decrease", if apple beat the market buy apple, these are called exogenous trade meaning you dont only look at the price but also consider other factors 
* endogenouse on the other hand only focuses on the chart and pirce data 
* exogenouse trading rules: 
  
  * are based on extra variable 
  * provides a better prediction 
  * with ai we can use extra variable to make a better prediction
* endogenouse is mostly based on technical analysis 
* 300 points = 3% 

<br>
<br>


# tesorflow 
Open source library for numerical computation

* for large data, vectors, matrix is not enough, we need a n-dimention aray of data which is called tensor and a flow of them(many of them). 
* tensorflow graphs are portable and can run in differnet language and device 
* tenserflow provides on-device interface of model, you can train the model with a lot of data on the cloud and then downlaod the model on a device, e.g. google translate use this to translate ofline, 


<br>
<br>

# tenserflow code : 
```python
              Rank        exemple                         shape 
varible:      0         x= tf.constant(3)                     ()
vector:       1         x= tf.constant([1,2,3])              (3,)
matrix:       2         x= tf.constant([[1,2,3],              (2,3)
                                       [1,2,3]])               
3d tensor     3       x= tf.constant([[[1,2,3], [1,2,3]        (2,2,3)
                                       [1,2,3], [1,2,3]]])    

# you can also do this instead 
x1= tf.constant([1,2,3]) 
x2 = tf.stack([x1,x1])
x3 = tf.stack([x2,x2])
x4 = tf.stack([x3,x3]) # 4d tensor 


# tf.constant and tf.varialbe 
tf.constant: creates variable that are constant 
tf.variable; creats varaible that can be modified   


# variable 
x = tf.variable(2.0, dtpe = tf.float32, name= 'my_variable")

x.assign(45.9)

# multiplying two matrix w * x

w = tf.variable([[1.],[2.]])
x = tf.variable([[3.],[4.]])
tf.matmul(w,x)

```


## lab 1
The main difference is that instances of tf.Variable have methods allowing us to change their values while tensors constructed with tf.constant don't have these methods, and therefore their values can not be changed. When you want to change the value of a tf.Variable x use one of the following method:
* x.assign(new_value)
* x.assign_add(value_to_be_added)
* x.assign_sub(value_to_be_subtracted) 
```python 
import numpy as np
from matplotlib import pyplot as plt
import tensorflow as tf

x = tf.constant([2, 3, 4])
print(x)
# tf.Tensor([2 3 4], shape=(3,), dtype=int32)


## varaible 
x = tf.Variable(2.0, dtype=tf.float32, name='my_variable') 
# 2.0 is the intial value, name is the name of the variable 
x.assign(45.8) # assigns the value 45.0 
x.assign_add(4)  # adds 4 to the assigned value 
x.assign_sub(3) 

```

## Point-wise operations 
*  add the components of a tensor
* ws us to multiply the components of a tensor
* w us to substract the components of a tensor
* ns the usual math operations to be applied on the components  
  
```python 
# TODO 1a
a = tf.constant(2) # TODO -- Your code here.
b = tf.constant(3) # TODO -- Your code here.
c = tf.add(a,b) # TODO -- Your code here.
d = a + b # TODO -- Your code here.

print("c:", c)
print("d:", d)


# TODO 1b
a = tf.constant(3) # TODO -- Your code here.
b = tf.constant(4) # TODO -- Your code here.
c = tf.multiply(a,b)# TODO -- Your code here.
d = a*b# TODO -- Your code here.

print("c:", c)
print("d:", d)



# TODO 1c
# tf.math.exp expects floats so we need to explicitly give the type
a = tf.constant([1,2,3], dtype=tf.float32)# TODO -- Your code here.
b = tf.math.exp(a)# TODO -- Your code here.

print("b:", b) # exp, take e^x 

```

## NumPy Interoperability
In addition to native TF tensors, tensorflow operations can take native python types and NumPy arrays as operands.
```python

# native python list
a_py = [1, 2] 
b_py = [3, 4] 

tf.add(a_py, b_py)
# <tf.Tensor: shape=(2,), dtype=int32, numpy=array([4, 6], dtype=int32)>


# native TF tensor
a_tf = tf.constant([1, 2])
b_tf = tf.constant([3, 4])

tf.add(a_tf, b_tf)
# <tf.Tensor: shape=(2,), dtype=int32, numpy=array([4, 6], dtype=int32)>


# You can convert a native TF tensor to a NumPy array using .numpy()
a_tf.numpy()

# the range generates an array from 0 to 
X = tf.constant(range(10), dtype=tf.float32)
print(X.numpy())
print(X[1].numpy())
```
## Linear Regression
We'll model the following function:  **𝑦= 2𝑥+10**

```python 
X = tf.constant(range(0,10), dtype=tf.float32)
Y = 2 * X + 10 # takes every variable in the X 
Z = 2 * X[1] + 10

print("X:{}".format(X))
print("Y:{}".format(Y))
print("Z:{}".format(Z))


y_mean = Y.mean() # this wont work since Y is tensor 
y_mean = Y.numpy().mean() # this works since the numpy converts the tensor to numpy array and then we can calculate the mann 




## here you basically predict the value of inputs 
y_mean = Y.numpy().mean()

print(y_mean)

def predict_mean(X):
    y_hat = [y_mean] * len(X) #The function predict_mean simply returns a list y_hat containing the predicted values for each element in X, which are all equal to the value of y_mean. This is known as a "mean prediction
    return y_hat # we simply say the mean value from training data is the same for all future values 

Y_hat = predict_mean(X_test)

print(Y_hat)



# here we calculate the standard error: 

errors = (Y_hat - Y)**2
print(errors) 

loss = tf.reduce_mean(errors) # = errors.numpy().mean()
loss.numpy()

```

### This values for the MSE loss above will give us a baseline to compare how a more complex model is doing. we can see the standard error is 33 which is indicating the model is not doing good, first we predicted the value of each Y by using training data, then we compare the predicted value and compare with the actual value error 


```python

def loss_mse(X, Y, w0, w1):
    Y_hat = w0 * X + w1 # here instead of predicting by just using the man, we predict the values with a better model and calculation method 
    errors = (Y_hat - Y)**2
    return tf.reduce_mean(errors)

```

<br>
<br>

## Gradiant function 
describes the rate of change of a function with respect to its input variables. n other words, the gradient tells us which direction to move the input variables to increase or decrease the value of the function the most.

```python 

# here we define a function to predict 
def loss_mse(X, Y, w0, w1):
    Y_hat = w0 * X + w1
    errors = (Y_hat - Y)**2
    return tf.reduce_mean(errors)


# our prediction function was dependent on two variables w0 and w1, in this function we compute the gradient which tell us in which direction our prediction result goint with respect to w0 and w1 
def compute_gradients(X, Y, w0, w1):
    with tf.GradientTape() as tape: 
        loss = loss_mse(X,Y,w0, w1)
        return tape.gradient(loss,[w0,w1]) # this is good one


w0 = tf.Variable(0.0)
w1 = tf.Variable(0.0)

# tape.gradient(loss,[w0,w1]): this function returns the sensetivity for w0 and w1, 
# if we have w0= 0, w1 = 0 we get dw0 = -204 and dw0= 38, this tell us the prediction function is more sensetiv to w0(204 > 38) and - means we should increase w0 to get more pricies prediction 
dw0, dw1 = compute_gradients(X, Y, w0, w1)

```

## training 
```python 
# in this program we train the model 
STEPS = 1000
LEARNING_RATE = .02
MSG = "STEP {step} - loss: {loss}, w0: {w0}, w1: {w1}\n"


w0 = tf.Variable(0.0)
w1 = tf.Variable(0.0)


for step in range(0, STEPS + 1):

    dw0, dw1 = compute_gradients(X, Y, w0, w1)
    
    w0.assign_sub(LEARNING_RATE*dw0)  # this is the actual training, in every step the gradient function tell the model in which direction move the variables, e.g. we start with 4.08 0.76, then 3.372 0.7552(the - and + in gradient tells wheter add or subtract, assign_sub, subtracts but somtimes we the direction is - which means it adds e.g from 3.372 0.7552 to 3.4719841 0.878032, both increases since the gradient tells the direction)
    w1.assign_sub(LEARNING_RATE*dw1) 

    if step % 100 == 0:
        loss = loss_mse(X,Y,w0, w1)# TODO -- Your code here.
        print(MSG.format(step=step, loss=loss, w0=w0.numpy(), w1=w1.numpy()))




#  here we get a much smaller loss then before from 1554 to 2.4563633e-08
loss = loss_mse(X_test, Y_test, w0, w1)
loss.numpy()

```