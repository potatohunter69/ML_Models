import matplotlib.pyplot as plt 

fig, ax= plt.subplots()

x_data = [1,2,3,4,5]
y_data = [0,4,6,2,1]


ax.plot(x_data,y_data)

ax.set_xlabel('X Label')
ax.set_ylabel('Y Label')
ax.set_title('Title')


ax.plot(x_data, y_data, color= 'red',  linestyle='dashed', marker='o', markersize=10)


plt.show()


