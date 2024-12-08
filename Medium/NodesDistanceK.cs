namespace LeetCodeSolutions.Medium;

/*
 *
 * 863. All Nodes Distance K in Binary Tree
 *
 * Given the root of a binary tree, the value of a target node target, and
 *  an integer k, return an array of the values of all nodes that have a
 *  distance k from the target node.
 *
 * You can return the answer in any order.
 *
 * Example 1:
 * Input: root = [3,5,1,6,2,0,8,null,null,7,4], target = 5, k = 2
 * Output: [7,4,1]
 * Explanation: The nodes that are a distance 2 from the target node (with value 5) have values 7, 4, and 1.
 *
 * Example 2:
 * Input: root = [1], target = 1, k = 3
 * Output: []
 *
 * Constraints:
 * The number of nodes in the tree is in the range [1, 500].
 * 0 <= Node.val <= 500
 * All the values Node.val are unique.
 * target is the value of one of the nodes in the tree.
 * 0 <= k <= 1000
 *
* Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 * 
 */
public static class NodesDistanceK
{
    public static void Run()
    {
        var root = new TreeNode(3)
        {
            left = new TreeNode(5),
            right = new TreeNode(1)
        };

        root.left.left = new TreeNode(6);
        root.left.right = new TreeNode(2);

        root.right.left = new TreeNode(0);
        root.right.right = new TreeNode(8);

        root.left.right.left = new TreeNode(7);
        root.left.right.right = new TreeNode(4);
        var result = DistanceK(root, root.left, 2);
        foreach(var num in result)
            Console.WriteLine($"DistanceK Example 1: {num}");        
        
        root = new TreeNode(1);
        result = DistanceK(root, root, 2);
        foreach(var num in result)
            Console.WriteLine($"DistanceK Example 2: {num}"); 
    }

    private static int[] DistanceK(TreeNode root, TreeNode? target, int k)
    {
        var result = new List<int>();
        var parentMap = new Dictionary<TreeNode, TreeNode>();
        
        // Step 1: DFS to populate parentMap
        PopulateParentMap(root, null, parentMap);
        
        // Step 2: BFS to find nodes at distance K
        var queue = new Queue<TreeNode>();
        var visited = new HashSet<TreeNode>();
        
        queue.Enqueue(target);
        visited.Add(target);
        
        var currentLevel = 0;
        
        while (queue.Count > 0)
        {
            var size = queue.Count;
            
            if (currentLevel == k)
            {
                foreach (var node in queue)
                    result.Add(node.val);

                return result.ToArray();
            }
            
            for (var i = 0; i < size; i++)
            {
                var node = queue.Dequeue();
                
                // Check the left child
                if (node.left is not null && !visited.Contains(node.left))
                {
                    queue.Enqueue(node.left);
                    visited.Add(node.left);
                }
                
                // Check the right child
                if (node.right is not null && !visited.Contains(node.right))
                {
                    queue.Enqueue(node.right);
                    visited.Add(node.right);
                }
                
                // Check the parent node
                if (!parentMap.ContainsKey(node) || visited.Contains(parentMap[node])) 
                    continue;
                
                queue.Enqueue(parentMap[node]);
                visited.Add(parentMap[node]);
            }
            
            currentLevel++;
        }
        
        return result.ToArray();
    }

    private static void PopulateParentMap(TreeNode? node, TreeNode? parent, Dictionary<TreeNode, TreeNode> parentMap)
    {
        if (node is null)
            return;
        
        parentMap[node] = parent;
        PopulateParentMap(node.left, node, parentMap);
        PopulateParentMap(node.right, node, parentMap);
    }

    private class TreeNode(int x)
    {
        public int val = x;
        public TreeNode? left;
        public TreeNode? right;
    }
}