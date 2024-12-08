namespace LeetCodeSolutions.Basics.Data_Structs;

public class SinglyLinkedListInt
{
    private Node? _head = null;

    public void Insert(int data)
    {
        var newNode = new Node(data);

        // if the list is empty aka head is null
        if (_head is null)
        {
            // create first node
            _head = newNode;
        }
        // else list has nodes
        else
        {
            // set current temp to head
            var current = _head;
            
            // while loop to find the end of the list aka current.Next = null
            while (current.Next is not null)
                current = current.Next;

            // set current.Next to new node
            current.Next = newNode;
        }
    }

    // simple traversal to display the list
    public void Display()
    {
        var current = _head;
        while (current is not null)
        {
            Console.Write(current.Data + " -> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }
    
    // internal node class
    private class Node(int data)
    {
        public int Data { get; set; } = data;
        public Node? Next { get; set; } = null;
    }
}