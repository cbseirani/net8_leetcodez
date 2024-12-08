namespace LeetCodeSolutions.Basics.Data_Structs;

/*
 * Binary Tree:
 *
 * A Binary Tree is a tree data structure in which each node
 *  has at most two children, referred to as the left child
 *  and the right child.
 */
public class BinarySearchTreeInt
{
    public TreeNode? Root = null;
    
    // Insert a value into the binary tree
    public void Insert(int value)
    {
        Root = InsertRecursively(Root, value);
    }
    
    private static TreeNode InsertRecursively(TreeNode? root, int value)
    {
        if (root is null)
            return new TreeNode(value);

        if (value < root.Value)
            root.Left = InsertRecursively(root.Left, value);
        else if (value > root.Value)
            root.Right = InsertRecursively(root.Right, value);

        return root;
    }
    
    // In-order traversal of the binary tree
    public void InOrderTraversal(TreeNode? node)
    {
        if (node is null) 
            return;
        
        InOrderTraversal(node.Left);
        Console.Write(node.Value + " ");
        InOrderTraversal(node.Right);
    }
    
    public class TreeNode(int val)
    {
        public int Value = val;
        public TreeNode? Left = null;
        public TreeNode? Right = null;
    }
}