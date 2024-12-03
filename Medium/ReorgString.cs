namespace LeetCodeSolutions.Medium;

/*
 *
 * 767. Reorganize String
 *
 * Given a string s, rearrange the characters of s so that any two adjacent
 *  characters are not the same.
 *
 * Return any possible rearrangement of s or return "" if not possible.
 *
 * Example 1:
 * Input: s = "aab"
 * Output: "aba"
 *
 * Example 2:
 * Input: s = "aaab"
 * Output: ""
 *
 * Constraints:
 * 1 <= s.length <= 500
 * s consists of lowercase English letters.
 * 
 */
public class ReorgString
{
    public static void Run()
    {
        var s = "aab";
        Console.WriteLine($"Reorg String {s}: {ReorganizeString(s)}");
        
        s = "aaab";
        Console.WriteLine($"Reorg String {s}: {ReorganizeString(s)}");
        
        s = "vvvlo";
        Console.WriteLine($"Reorg String {s}: {ReorganizeString(s)}");
    }
    
    private static string ReorganizeString(string s)
    {
        // create a frequency dictionary
        var freqDict = new Dictionary<char, int>();
        foreach (var c in s.ToCharArray())
        {
            if (!freqDict.TryGetValue(c, out var count))
                freqDict.Add(c, 1);
            else
                freqDict[c] = count + 1;
        }

        // check if any frequencies are greater than n+1/2
        // if so, return empty string
        if (freqDict.Any(x => x.Value > (s.Length + 1) / 2))
            return string.Empty;

        // sort dictionary based on their frequencies
        var sortedChars = freqDict
            .OrderByDescending(x => x.Value) 
            .SelectMany(x => Enumerable.Repeat(x.Key, x.Value)) 
            .ToList();
        
        // Alternate placement of characters to ensure no two adjacent are the same
        var result = new char[s.Length]; 
        var index = 0;
        
        foreach (var c in sortedChars) 
        { 
            result[index] = c; 
            index += 2; 
            
            // Move to odd indices after filling even indices
            if (index >= s.Length)
                index = 1;
        }

        return new string(result);
    }
}