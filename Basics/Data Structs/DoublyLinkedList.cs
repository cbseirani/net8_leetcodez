namespace LeetCodeSolutions.Basics.Data_Structs;

/*
 * A doubly linked list is a linear data structure where each node
 *  contains a reference to both the next and the previous node,
 *  allowing traversal in both directions.
 */
public class DoublyLinkedList
{
    private Node? _head;

    public void Insert(int data)
    {
        var newNode = new Node(data);

        if (_head is null)
            _head = newNode;
        else
        {
            var current = _head;
            while (current.Next is not null)
                current = current.Next;

            newNode.Previous = current;
            current.Next = newNode;
        }
    }

    public void ForwardDisplay()
    {
        var current = _head;
        while (current is not null)
        {
            Console.Write(current.Data + " -> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }

    public void ReverseDisplay()
    {
        var current = _head;
        if (current is null)
        {
            Console.WriteLine("null");
            return;
        }

        while (current.Next is not null)
            current = current.Next;
        
        while (current is not null)
        {
            Console.Write(current.Data + " <- ");
            current = current.Previous;
        }
        Console.WriteLine("null");
    }
    
    private class Node(int data)
    {
        public int Data { get; set; } = data;
        public Node? Next { get; set; } = null;
        public Node? Previous { get; set; } = null;
    }
}