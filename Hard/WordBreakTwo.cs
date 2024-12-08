namespace LeetCodeSolutions.Hard;

/*
 *
 * 140. Word Break II
 *
 * Given a string s and a dictionary of strings wordDict, add spaces in s to
 *  construct a sentence where each word is a valid dictionary word.
 *  Return all such possible sentences in any order.
 *
 * Note that the same word in the dictionary may be reused multiple
 *  times in the segmentation.
 *
 * Example 1:
 * Input: s = "catsanddog", wordDict = ["cat","cats","and","sand","dog"]
 * Output: ["cats and dog","cat sand dog"]
 *
 * Example 2:
 * Input: s = "pineapplepenapple", wordDict = ["apple","pen","applepen","pine","pineapple"]
 * Output: ["pine apple pen apple","pineapple pen apple","pine applepen apple"]
 * Explanation: Note that you are allowed to reuse a dictionary word.
 *
 * Example 3:
 * Input: s = "catsandog", wordDict = ["cats","dog","sand","and","cat"]
 * Output: []
 *
 * Constraints:
 * 1 <= s.length <= 20
 * 1 <= wordDict.length <= 1000
 * 1 <= wordDict[i].length <= 10
 * s and wordDict[i] consist of only lowercase English letters.
 * All the strings of wordDict are unique.
 * Input is generated in a way that the length of the answer doesn't exceed 105.
 * 
 */
public static class WordBreakTwo
{
    public static void Run()
    {
        var result = WordBreak("catsanddog", ["cat", "cats", "and", "sand", "dog"]);
        foreach(var res in result)
            Console.WriteLine($"WordBreakTwo Example1 : {res}");
        
        result = WordBreak("pineapplepenapple", ["apple","pen","applepen","pine","pineapple"]);
        foreach(var res in result)
            Console.WriteLine($"WordBreakTwo Example2 : {res}");
        
        result = WordBreak("catsandog", ["cats","dog","sand","and","cat"]);
        foreach(var res in result)
            Console.WriteLine($"WordBreakTwo Example3 : {res}");
    }

    private static string[] WordBreak(string s, IList<string> wordDict)
    {
        // Initialize a dictionary for memoization
        var memo = new Dictionary<string, List<string>>();
        
        // Call the helper function
        return WbHelper(s, new HashSet<string>(wordDict), memo).ToArray();
    }

    private static List<string> WbHelper(string s, HashSet<string> wordDict, Dictionary<string, List<string>> memo)
    {
        // If the result is already computed, return it
        if (memo.TryGetValue(s, out var value))
            return value;

        var result = new List<string>();

        // If the string is empty, add an empty string to the result
        if (s.Length is 0)
        {
            result.Add("");
            return result;
        }

        // Try every prefix of the string
        for (var i = 1; i <= s.Length; i++)
        {
            var word = s.Substring(0, i);

            if (!wordDict.TryGetValue(word, out var val)) 
                continue;
            
            var subResult = WbHelper(s.Substring(i), wordDict, memo);
                
            foreach(var str in subResult)
                result.Add(word + (str.Length is 0 ? "" : " " + str));
        }

        // Store the result in the memoization dictionary
        memo[s] = result;
        return result;
    }
}