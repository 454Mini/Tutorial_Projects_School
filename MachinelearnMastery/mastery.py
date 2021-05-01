# -*- coding: utf-8 -*-
"""
Created on Tue Apr 20 12:23:56 2021

@author: henri
"""

from keras.datasets import mnist
from matplotlib import pyplot as plt

(trainX, trainy), (testX, testy) = mnist.load_data()

print('Train X=%s, y=%s' %(trainX.shape, trainy.shape))
print('TestX=%s, y=%s' %(testX.shape, testy.shape))

for i in range(9):
    plt.subplot(330+1+i)
    plt.imshow(trainX[i], cmap=plt.get_cmap('gray'))
    plt.show()