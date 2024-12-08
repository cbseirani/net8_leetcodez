using LeetCodeSolutions.Basics.Algorithms;
using LeetCodeSolutions.Basics.Data_Structs;
using LeetCodeSolutions.Easy;
using LeetCodeSolutions.Hard;
using LeetCodeSolutions.Medium;

Console.WriteLine("DSA coverage & LeetCode solutions!");

// DATA STRUCTS
#region DataStructs
Console.WriteLine(string.Empty);
Console.WriteLine("DATA STRUCTURES:");

// Singly Linked List
Console.WriteLine(string.Empty);
Console.WriteLine("Singly Linked List");
var singleLinkedList = new SinglyLinkedListInt();
var sampleIntData = new [] { 1, 2, 3, 4, 5 };

foreach(var num in sampleIntData)
    singleLinkedList.Insert(num);

singleLinkedList.Display();

// Binary Tree
Console.WriteLine(string.Empty);
Console.WriteLine("Binary Search Tree");
var binaryTree = new BinarySearchTreeInt();
sampleIntData = new [] { 5, 2, 3, 1, 5, 4 };
DisplayArrayInt(sampleIntData);
foreach(var num in sampleIntData)
    binaryTree.Insert(num);

binaryTree.InOrderTraversal(binaryTree.Root);
Console.WriteLine(string.Empty);

// Trie Tree
Console.WriteLine(string.Empty);
Console.WriteLine("Trie Tree");
var trieTree = new TrieTree();
var sampleStringData = new [] { "test", "all", "cheese", "please", "thank you" };
DisplayArrayStr(sampleStringData);

foreach(var str in sampleStringData)
    trieTree.Insert(str);

Console.WriteLine($"Search test: {trieTree.Search("test")}");
Console.WriteLine($"Search testy: {trieTree.Search("testy")}");
Console.WriteLine($"Search cheese: {trieTree.Search("cheese")}");
Console.WriteLine($"Starts with che: {trieTree.StartsWith("che")}");
Console.WriteLine($"Starts with tst: {trieTree.StartsWith("tst")}");

// Graph
Console.WriteLine(string.Empty);
Console.WriteLine("Graph");
var graph = new GraphInt();
var sampleVerticiesData = new [] { (1,2), (1,3), (2,4), (3,4), (4,5) };

foreach(var vert in sampleVerticiesData)
    graph.AddEdge(vert.Item1, vert.Item2);

graph.PrintGraph();

Console.WriteLine(string.Empty);
#endregion

// SORTS
#region Sorts
Console.WriteLine(string.Empty);
Console.WriteLine("SORTS:");

// Bubble Sort
Console.WriteLine(string.Empty);
Console.WriteLine("Bubble Sort");
var bubbleArray = new[] { 21, 73, 676, 3, 89, 9, 102, 203 };
DisplayArrayInt(bubbleArray);
ArraySorts.BubbleSort(bubbleArray);
DisplayArrayInt(bubbleArray);

// Selection Sort
Console.WriteLine(string.Empty);
Console.WriteLine("Selection Sort");
var selectionArray = new[] { 212, 7, 6763, 32, 894, 91, 10, 2 };
DisplayArrayInt(selectionArray);
ArraySorts.SelectionSort(selectionArray);
DisplayArrayInt(selectionArray);

// Insertion Sort
Console.WriteLine(string.Empty);
Console.WriteLine("Insertion Sort");
var insertionArray = new[] { 21, 7, 673, 32, 94, 9, 0, 2 };
DisplayArrayInt(insertionArray);
ArraySorts.InsertionSort(insertionArray);
DisplayArrayInt(insertionArray);

// Merge Sort
Console.WriteLine(string.Empty);
Console.WriteLine("Merge Sort");
var mergeArray = new[] { 13, 71, 73, 321, 914, 9, 10, 627 };
DisplayArrayInt(mergeArray);
ArraySorts.MergeSort(mergeArray);
DisplayArrayInt(mergeArray);

// Quick Sort
Console.WriteLine(string.Empty);
Console.WriteLine("Quick Sort");
var quickArray = new[] { 11, 7, 3, 31, 91, 55, 130, 67 };
DisplayArrayInt(quickArray);
ArraySorts.QuickSort(quickArray, 0, quickArray.Length-1);
DisplayArrayInt(quickArray);

// Heap Sort
Console.WriteLine(string.Empty);
Console.WriteLine("Heap Sort");
var heapArray = new[] { 111, 71, 23, 331, 1, 87, 30, 672 };
DisplayArrayInt(heapArray);
ArraySorts.HeapSort(heapArray);
DisplayArrayInt(heapArray);

// Counting Sort
Console.WriteLine(string.Empty);
Console.WriteLine("Counting Sort");
var countingArray = new[] { 21, 1, 3, 2341, 65, 7, 0, 272 };
DisplayArrayInt(countingArray);
ArraySorts.CountingSort(countingArray);
DisplayArrayInt(countingArray);

// Radix Sort
Console.WriteLine(string.Empty);
Console.WriteLine("Radix Sort");
var radixArray = new[] { 4111, 1122, 3142, 2241, 6534, 1127, 2240, 2472 };
DisplayArrayInt(radixArray);
ArraySorts.RadixSort(radixArray);
DisplayArrayInt(radixArray);

// Bucket Sort
Console.WriteLine(string.Empty);
Console.WriteLine("Bucket Sort");
var bucketArray = new[] { 41, 12, 34, 222, 65, 11, 24, 2 };
DisplayArrayInt(bucketArray);
ArraySorts.BucketSort(bucketArray);
DisplayArrayInt(bucketArray);

#endregion

// LEETCODE QUESTIONS
#region LeetCode

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

#endregion

Console.WriteLine(string.Empty);
Console.WriteLine("Thanks!");
return;


void DisplayArrayInt(int[] arr)
{
    var outputStr = "[ ";
    foreach (var num in arr)
        outputStr += $"{num}, ";

    outputStr = outputStr.Substring(0, outputStr.Length - 2) + " ]";
    Console.WriteLine(outputStr);
}

void DisplayArrayStr(string[] arr)
{
    var outputStr = "[ ";
    
    foreach (var num in arr)
        outputStr += $"{num}, ";

    outputStr = outputStr.Substring(0, outputStr.Length - 2) + " ]";
    Console.WriteLine(outputStr);
}