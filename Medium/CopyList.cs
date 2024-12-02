namespace LeetCodeSolutions.Medium;

/*
 *
 * 138. Copy List with Random Pointer
 *
 * A linked list of length n is given such that each node contains an additional random
 *  pointer, which could point to any node in the list, or null.
 *
 * Construct a deep copy of the list. The deep copy should consist of exactly n brand new nodes,
 *  where each new node has its value set to the value of its corresponding original node.
 *  Both the next and random pointer of the new nodes should point to new nodes in the copied
 *  list such that the pointers in the original list and copied list represent the same list state.
 *  None of the pointers in the new list should point to nodes in the original list.
 *
 * For example, if there are two nodes X and Y in the original list, where X.random --> Y, then for
 *  the corresponding two nodes x and y in the copied list, x.random --> y.
 *
 * Return the head of the copied linked list.
 *
 * The linked list is represented in the input/output as a list of n nodes. Each node is represented
 *  as a pair of [val, random_index] where:
 *
 * val: an integer representing Node.val
 * random_index: the index of the node (range from 0 to n-1) that the random pointer points to,
 *  or null if it does not point to any node.
 *
 * Your code will only be given the head of the original linked list.
 *
 * Example 1:
 * Input: head = [[7,null],[13,0],[11,4],[10,2],[1,0]]
 * Output: [[7,null],[13,0],[11,4],[10,2],[1,0]]
 *
 * Example 2:
 * Input: head = [[1,1],[2,1]]
 * Output: [[1,1],[2,1]]
 *
 * Example 3:
 * Input: head = [[3,null],[3,0],[3,null]]
 * Output: [[3,null],[3,0],[3,null]]
 *
 *
 * Constraints:
 * 0 <= n <= 1000
 * -104 <= Node.val <= 104
 * Node.random is null or is pointing to some node in the linked list.
 * 
 */
public static class CopyList
{
    public static void Run()
    {
        // Example 1
        var node1 = new Node(7);
        var node2 = new Node(13);
        var node3 = new Node(11);
        var node4 = new Node(10);
        var node5 = new Node(1);
        node1.next = node2;
        node2.next = node3;
        node3.next = node4;
        node4.next = node5;
        node1.random_index = null;
        node2.random_index = 0; // Points to node1
        node3.random_index = 4; // Points to node5
        node4.random_index = 2; // Points to node3
        node5.random_index = 0; // Points to node1
        var copiedHead1 = CopyRandomList(node1);
        PrintList(copiedHead1);

        // Example 2
        var node6 = new Node(1);
        var node7 = new Node(2);
        node6.next = node7;
        node6.random_index = 1; // Points to node7
        node7.random_index = 1; // Points to node7
        var copiedHead2 = CopyRandomList(node6);
        PrintList(copiedHead2);

        // Example 3
        var node8 = new Node(3);
        var node9 = new Node(3);
        var node10 = new Node(3);
        node8.next = node9;
        node9.next = node10;
        node8.random_index = null;
        node9.random_index = 0; // Points to node8
        node10.random_index = null;
        var copiedHead3 = CopyRandomList(node8);
        PrintList(copiedHead3);
    }
    
    private static void PrintList(Node? head)
    {
        while (head != null)
        {
            Console.Write($"[{head.val},{head.random_index?.ToString() ?? "null"}] ");
            head = head.next;
        }
        Console.WriteLine();
    }

    private static Node? CopyRandomList(Node? head)
    {
        if (head is null)
            return null;
        
        // Step 1: Create a copy of each node and link them side by side in the list
        var current = head;
        while (current is not null)
        {
            var copy = new Node(current.val)
            {
                next = current.next
            };
            
            current.next = copy;
            current = copy.next;
        }

        // Step 2: Assign random pointers for the copied nodes
        current = head;
        while (current is not null)
        {
            if (current.random_index.HasValue)
                current.next.random_index = current.random_index;
            
            current = current.next?.next;
        }

        // Step 3: Restore the original list and extract the copied list
        current = head;
        var copiedHead = head.next;
        var copyCurrent = copiedHead;
        while (current is not null)
        {
            current.next = copyCurrent.next;
            current = current.next;
            
            if (current is null) 
                continue;
            
            copyCurrent.next = current.next;
            copyCurrent = copyCurrent.next;
        }

        return copiedHead;
    }

    private class Node(int _val, Node? _next = null, int? _random = null)
    {
        public int val = _val;
        public Node? next = _next;
        public int? random_index = _random;
    }
}