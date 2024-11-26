namespace LeetCodeSolutions.Medium;

/*
 *
 * Given a string s, find the length of the longest substring without repeating
 *  characters.
 *
 * Example 1:
 * Input: s = "abcabcbb"
 * Output: 3
 * Explanation: The answer is "abc", with the length of 3.
 *
 * Example 2:
 * Input: s = "bbbbb"
 * Output: 1
 * Explanation: The answer is "b", with the length of 1.
 *
 * Example 3:
 * Input: s = "pwwkew"
 * Output: 3
 * Explanation: The answer is "wke", with the length of 3.
 * Notice that the answer must be a substring, "pwke" is a subsequence
 * and not a substring.
 *
 * Constraints:
 * 0 <= s.length <= 5 * 104
 * s consists of English letters, digits, symbols and spaces.
 *
 */
public static class LongestSubstring
{
    public static void Run()
    {
        var s1 = "abcabcbb";
        Console.WriteLine($"Input: {s1} -> Output: {LengthOfLongestSubstring(s1)}"); // Expected output: 3

        var s2 = "bbbbb";
        Console.WriteLine($"Input: {s2} -> Output: {LengthOfLongestSubstring(s2)}"); // Expected output: 1

        var s3 = "pwwkew";
        Console.WriteLine($"Input: {s3} -> Output: {LengthOfLongestSubstring(s3)}"); // Expected output: 3
    }
    
    private static int LengthOfLongestSubstring(string input)
    {
        var existing = new HashSet<char>();
        var left = 0;
        var maxLength = 0;

        for (var right = 0; right < input.Length; right++)
        {
            while (existing.Contains(input[right]))
            {
                existing.Remove(input[left]);
                left++;
            }
            existing.Add(input[right]);
            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }
}