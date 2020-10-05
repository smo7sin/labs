

#%%
import itertools as it

#%%
def minSum(xs):
    return sum(it.islice(xs, 4))

#%%
def maxSum(xs):
    return sum(it.islice(xs, 1, None))

#%%
def minMaxSum(nums):
    xs = sorted(nums)
    print (minSum(xs), maxSum(xs))

# %%
nums = list(range(1,6))
