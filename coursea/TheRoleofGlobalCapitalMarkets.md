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


```
 
