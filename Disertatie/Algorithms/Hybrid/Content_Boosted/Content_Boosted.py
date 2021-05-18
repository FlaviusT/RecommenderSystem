# Installs(if needed)
# pip install pandas
# pip install surprise

#Inports
import pandas as pd
import numpy as np
import math

# Read the data from files
users = pd.read_csv('./users.csv')
movies = pd.read_csv('./movies.csv')
ratings = pd.read_csv('./ratings.csv')

ratings_matrix = ratings.pivot(index='movieId',columns='userId',values='rating')

ratings_matrix.head(5)

for _row in range(1,ratings_matrix.shape[0]):
    for _column in range(1,ratings_matrix.shape[1]):
        if(ratings_matrix[_row][_column] != ratings_matrix[_row][_column]):
            print('fd')