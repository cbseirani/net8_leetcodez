using LeetCodeSolutions.Basics;
using LeetCodeSolutions.Easy;
using LeetCodeSolutions.Hard;
using LeetCodeSolutions.Medium;

Console.WriteLine("Leetcode Solutions!");

// BASICS:

// Singly Linked List with normal traversal
Console.WriteLine("Singly Linked List");
var singleLinkedList = new SinglyLinkedListInt();
var sampleData = new [] { 1, 2, 3, 4, 5 };

foreach(var num in sampleData)
    singleLinkedList.Insert(num);

singleLinkedList.Display();
Console.WriteLine(string.Empty);

// Bubble Sort
Console.WriteLine("BubbleSort");
var bubbleArray = new[] { 21, 73, 676, 3, 89, 9, 102, 203 };
DisplayArray(bubbleArray);
ArraySorts.BubbleSort(bubbleArray);
DisplayArray(bubbleArray);

// Selection Sort
Console.WriteLine("SelectionSort");
var selectionArray = new[] { 212, 7, 6763, 32, 894, 91, 10, 2 };
DisplayArray(selectionArray);
ArraySorts.SelectionSort(selectionArray);
DisplayArray(selectionArray);

// Insertion Sort
Console.WriteLine("InsertionSort");
var insertionArray = new[] { 21, 7, 673, 32, 94, 9, 0, 2 };
DisplayArray(insertionArray);
ArraySorts.InsertionSort(insertionArray);
DisplayArray(insertionArray);

// // 1. Two Sum
// TwoSum.Run();
//
// // 2. Add Two Numbers 
// AddTwoNumbers.Run();
//
// // 3. Longest Substring Without Repeating Characters
// LongestSubstring.Run();




// // AMAZON QUESTIONS
// // 2357. Make Array Zero by Subtracting Equal Amounts
// MakeArrayZero.Run();
//
// // 138. Copy List with Random Pointer
// CopyList.Run();
//
// // 767. Reorganize String
// ReorgString.Run();

// 140. Word Break II
// WordBreakTwo.Run();

// 863. All Nodes Distance K in Binary Tree
// NodesDistanceK.Run();


Console.WriteLine(string.Empty);
Console.WriteLine("Thanks!");
return;


void DisplayArray(int[] arr)
{
    foreach (var num in arr)
        Console.Write($"{num} -> ");

    Console.WriteLine("");
}