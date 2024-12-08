namespace LeetCodeSolutions.Basics.Data_Structs;

/*
 * Trie:
 *
 * A Trie is a tree-like data structure used to store a
 *  dynamic set of strings, where keys are usually strings.
 *  Tries are commonly used for prefix-based searches.
 */
public class TrieTree
{
    private readonly TrieNode _root = new TrieNode();
    
    // Insert a word into the trie
    public void Insert(string word)
    {
        var node = _root;
        
        foreach (var ch in word)
        {
            if (!node.Children.ContainsKey(ch))
                node.Children[ch] = new TrieNode();
            
            node = node.Children[ch];
        }
        
        node.IsEndOfWord = true;
    }
    
    // Search for a word in the trie
    public bool Search(string word)
    {
        var node = _root;
        
        foreach (var ch in word)
        {
            if (!node.Children.TryGetValue(ch, out var child))
                return false;

            node = child;
        }
        
        return node.IsEndOfWord;
    }
    
    // Check if there is any word in the trie that starts with the given prefix
    public bool StartsWith(string prefix)
    {
        var node = _root;
        
        foreach (var ch in prefix)
        {
            if (!node.Children.TryGetValue(ch, out var child))
                return false;
            
            node = child;
        }
        
        return true;
    }
    
    public class TrieNode
    {
        public Dictionary<char, TrieNode> Children  = new ();
        public bool IsEndOfWord;
    }
}