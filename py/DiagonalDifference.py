#%%
import itertools as it

def diagonalDifference(arr):
    left, right = (0, 0)
    seq = range(len(arr))
    for (i, j) in zip(seq, reversed(seq)):
        left += arr[i][i]
        right += arr[i][j]
        
    return abs(right - left)
# %%
matrix = ((1, 2, 3),(4, 5, 6),(9, 8, 9))
# %%
