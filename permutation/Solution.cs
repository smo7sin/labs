using System;
using System.Collections.Generic;
using System.Linq;

public class Solution 
{    
    List<IList<int>> result = new();
    
    public IList<IList<int>> Permute(int[] nums) {
         
        Backtrack(nums, new HashSet<int>());
        
        return result;
    }
    
    void Backtrack(IList<int> nums, ISet<int> temp)
    {
        if (nums.Count() == temp.Count())
        {
            result.Add(temp.ToList());
        }
        foreach (var num in nums)
        {
            if (temp.Contains(num))
                continue;
            
            temp.Add(num);
            Backtrack(nums, temp);
            temp.Remove(num);
        }
    }
}
