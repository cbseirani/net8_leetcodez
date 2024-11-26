namespace LeetCodeSolutions.Medium;

/*
 *
 * 2. Add Two Numbers
 *
 * You are given two non-empty linked lists representing two non-negative integers.
 * The digits are stored in reverse order, and each of their nodes contains a single digit.
 * Add the two numbers and return the sum as a linked list.
 *
 * You may assume the two numbers do not contain any leading zero,
 * except the number 0 itself.
 *
 * Example 1:
 * Input: l1 = [2,4,3], l2 = [5,6,4]
 * Output: [7,0,8]
 * Explanation: 342 + 465 = 807.
 *
 * Example 2:
 * Input: l1 = [0], l2 = [0]
 * Output: [0]
 *
 * Example 3:
 * Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
 * Output: [8,9,9,9,0,0,0,1]
 *
 * Constraints:
 * The number of nodes in each linked list is in the range [1, 100].
 * 0 <= Node.val <= 9
 * It is guaranteed that the list represents a number that does not have leading zeros.
 * 
 */
public static class AddTwoNumbers
{
    public static void Run()
    {
        var l1 = new ListNode(2, new ListNode(4, new ListNode(3)));
        var l2 = new ListNode(5, new ListNode(6, new ListNode(4)));

        var result = AddTwoNums(l1, l2);

        while (result is not null)
        {
            Console.WriteLine($"AddTwoNums result: {result.Value}");
            result = result.Next;
        }
    }

    private static ListNode? AddTwoNums(ListNode? l1, ListNode? l2)
    {
        var result = new ListNode(0);
        var current = result;
        var carry = 0;

        //traverse each list
        while (l1 is not null || l2 is not null)
        {
            var l1Val = l1?.Value ?? 0;
            var l2Val = l2?.Value ?? 0;
            
            var sum = carry + l1Val + l2Val;
            carry = sum / 10;
            current.Next = new ListNode(sum % 10);
            current = current.Next;

            l1 = l1?.Next;
            l2 = l2?.Next;
        }
        
        // Add remaining carry as a new node if any
        if (carry > 0)
            current.Next = new ListNode(carry);
        
        // return without first 0 val
        return result.Next;
    }

    private class ListNode(int val = 0, ListNode? next = null)
    {
        public int Value = val;
        public ListNode? Next = next;
    }
}