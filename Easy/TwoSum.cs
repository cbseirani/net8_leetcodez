namespace LeetCodeSolutions.Easy;

/*
 *
 * 1. Two Sum
 * 
 * Given an array of integers nums and an integer target, return
 *  indices of the two numbers such that they add up to target.
 *
 * You may assume that each input would have exactly one solution,
 *  and you may not use the same element twice.
 *
 * You can return the answer in any order.
 *
 * Example 1:
 * Input: nums = [2,7,11,15], target = 9
 * Output: [0,1]
 * Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
 *
 * Example 2:
 * Input: nums = [3,2,4], target = 6
 * Output: [1,2]
 *
 * Example 3:
 * Input: nums = [3,3], target = 6
 * Output: [0,1]
 *
 * Constraints:
 * 2 <= nums.length <= 104
 * -109 <= nums[i] <= 109
 * -109 <= target <= 109
 *
 * Only one valid answer exists.
 *
 * Follow-up: Can you come up with an algorithm that is less than O(n^2) time complexity?
 * 
 */
public static class TwoSum
{
    public static void Run()
    {
        int[] arr = [2,7,11,15];
        var target = 9;
        var result = TwoSums(arr, target);
        Console.WriteLine($"TwoSum result: {result[0]}, {result[1]}");
        
        result = TwoSumsOptimized(arr, target);
        Console.WriteLine($"TwoSum optimized result: {result[0]}, {result[1]}");
    }

    private static int[] TwoSums(int[] nums, int target)
    {
        for (var i = 0; i < nums.Length; i++)
        {
            for (var j = 0; j < nums.Length; j++)
            {
                if (i == j)
                    continue;

                if (nums[i] + nums[j] == target)
                    return [i, j];
            }
        }

        throw new Exception("Did not find result!");
    }

    private static int[] TwoSumsOptimized(int[] nums, int target)
    {
        var numIndices = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            var complement = target - nums[i];

            if (numIndices.TryGetValue(complement, out var j))
                return [i, j];

            numIndices[nums[i]] = i;
        }

        throw new Exception("Did not find result!");
    }
}