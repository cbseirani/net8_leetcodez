namespace LeetCodeSolutions.Basics;

public static class ArraySorts
{
    /*
     * Bubble sort is a simple sorting algorithm that repeatedly steps through
     *  the list, compares adjacent elements, and swaps them if they are in
     *  the wrong order. This process continues until no swaps are needed,
     *  indicating that the list is sorted.
     *
     * Time Complexity :
     *  Best Case: O(n)  - when list is already sorted
     *  Avg Case: O(n^2)
     *  Worst Case: O(n^2)
     */
    public static void BubbleSort(int[] array)
    {
        for (var outer = 0; outer < array.Length - 1; outer++)
        {
            var max = array.Length - outer - 1;
            for (var inner = 0; inner < max; inner++)
            {
                if (array[inner] <= array[inner + 1]) 
                    continue;
                
                // Swap array[inner] and array[inner+1]
                var temp = array[inner];
                array[inner] = array[inner + 1];
                array[inner + 1] = temp;
            }
        }
    }
    
    /*
     * Selection sort is a simple comparison-based sorting algorithm that
     *  repeatedly selects the smallest (or largest) element from the
     *  unsorted portion of the list and swaps it with the first unsorted
     *  element. This process continues, moving the boundary of the
     *  sorted and unsorted sections, until the entire list is sorted.
     *
     * Time Complexity :
     *  Best Case: O(n^2)
     *  Avg Case: O(n^2)
     *  Worst Case: O(n^2)
     */
    public static void SelectionSort(int[] array)
    {
        for (var outer = 0; outer < array.Length - 1; outer++)
        {
            var minIndex = outer;
            
            for (var inner = outer + 1; inner < array.Length; inner++)
                if (array[inner] < array[minIndex])
                    minIndex = inner;
            
            // Swap array[outer] and array[minIndex]
            int temp = array[minIndex];
            array[minIndex] = array[outer];
            array[outer] = temp;
        }
    }
    
    /*
     * Insertion sort is a straightforward sorting algorithm that builds the
     *  final sorted array one element at a time, by repeatedly picking the
     *  next element and inserting it into its correct position among the
     *  previously sorted elements. This process continues until the entire
     *  list is sorted, effectively creating a growing sorted portion on the
     *  left side of the list.
     *
     * Time Complexity :
     *  Best Case: O(n) - when list is already sorted
     *  Avg Case: O(n^2)
     *  Worst Case: O(n^2)
     */
    public static void InsertionSort(int[] array)
    {
        for (var outer = 1; outer < array.Length; outer++)
        {
            var key = array[outer];
            var inner = outer - 1;

            // Move elements of array[0..i-1] that are greater than key to one position ahead
            while (inner >= 0 && array[inner] > key)
            {
                array[inner + 1] = array[inner];
                inner--;
            }
            array[inner + 1] = key;
        }
    }
    
    public static void MergeSort(int[] array)
    {
        if (array.Length <= 1)
        {
            return;
        }

        int mid = array.Length / 2;
        int[] left = new int[mid];
        int[] right = new int[array.Length - mid];

        Array.Copy(array, 0, left, 0, mid);
        Array.Copy(array, mid, right, 0, array.Length - mid);

        MergeSort(left);
        MergeSort(right);
        Merge(array, left, right);
    }

    private static void Merge(int[] array, int[] left, int[] right)
    {
        int i = 0, j = 0, k = 0;
        while (i < left.Length && j < right.Length)
        {
            if (left[i] <= right[j])
            {
                array[k++] = left[i++];
            }
            else
            {
                array[k++] = right[j++];
            }
        }

        while (i < left.Length)
        {
            array[k++] = left[i++];
        }

        while (j < right.Length)
        {
            array[k++] = right[j++];
        }
    }
}