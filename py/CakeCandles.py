#%%
import functools, operator
import itertools as it
import math


def largestCandlesCount (xs: list) -> int:
    largest = max(xs)
    count = 0
    for _ in filter (lambda x: x == largest, xs):
        count += 1

    return count
# %%
