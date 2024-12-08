namespace LeetCodeSolutions.Basics.Algorithms;

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
    
    /*
     * Merge sort is a divide-and-conquer algorithm that recursively
     *  divides the array into smaller subarrays until each subarray
     *  contains a single element, then merges these subarrays back
     *  together in sorted order. This merging process ensures that
     *  the entire array is sorted by combining smaller sorted arrays
     *  into larger ones.
     *
     * Time Complexity :
     *  Best Case: O(n log n)
     *  Avg Case: O(n log n)
     *  Worst Case: O(n log n)
     */
    #region MergeSort
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
    #endregion
    
    /*
     * QuickSort is a highly efficient, divide-and-conquer sorting
     *  algorithm that works by selecting a "pivot" element from the
     *  array and partitioning the other elements into two subarrays,
     *  according to whether they are less than or greater than the
     *  pivot. The process is recursively applied to the subarrays,
     *  and this results in the elements being sorted in-place.
     *
     * Time Complexity :
     *  Best Case: O(n log n) - Occurs when the pivot divides the array into
     *      two nearly equal halves each time.
     *  Avg Case: O(n log n)
     *  Worst Case: O(n^2) - Happens when the pivot is the smallest or largest
     *      element repeatedly, leading to highly unbalanced partitions.
     */
    #region QuickSort
    public static void QuickSort(int[] array, int low, int high)
    {
        if (low >= high) 
            return;
        
        var pi = Partition(array, low, high);
        QuickSort(array, low, pi - 1);
        QuickSort(array, pi + 1, high);
    }

    private static int Partition(int[] array, int low, int high)
    {
        var pivot = array[high];
        var i = low - 1;
        
        for (var j = low; j < high; j++)
        {
            if (array[j] >= pivot) 
                continue;
            
            i++;
            
            // Swap array[i] and array[j]
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        
        // Swap array[i + 1] and array[high]
        var temp1 = array[i + 1];
        array[i + 1] = array[high];
        array[high] = temp1;
        
        return i + 1;
    }
    #endregion

    /*
     * Heap Sort is a comparison-based sorting algorithm that builds
     *  a binary heap from the input data, then repeatedly extracts the
     *  maximum element from the heap and rebuilds the heap until all
     *  elements are sorted. This ensures that the largest elements are
     *  moved to their correct positions in the array from the end
     *  towards the beginning.
     *
     * Time Complexity :
     *  Best Case: O(n log n)
     *  Avg Case: O(n log n)
     *  Worst Case: O(n log n)
     */
    #region HeapSort
    public static void HeapSort(int[] array)
    {
        // Build heap
        for (var i = array.Length / 2 - 1; i >= 0; i--)
            Heapify(array, array.Length, i);

        // Extract elements from heap one by one
        for (var i = array.Length - 1; i >= 0; i--)
        {
            // Move current root to end
            int temp = array[0];
            array[0] = array[i];
            array[i] = temp;

            // Call heapify on the reduced heap
            Heapify(array, i, 0);
        }
    }

    private static void Heapify(int[] array, int n, int i)
    {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if (left < n && array[left] > array[largest])
        {
            largest = left;
        }

        if (right < n && array[right] > array[largest])
        {
            largest = right;
        }

        if (largest != i)
        {
            int swap = array[i];
            array[i] = array[largest];
            array[largest] = swap;

            Heapify(array, n, largest);
        }
    }
    #endregion
    
    /*
     * Counting Sort is a non-comparison-based sorting algorithm that
     *  works by counting the occurrences of each distinct element in
     *  the input array, then using this count to place the elements
     *  in their correct positions. It's particularly efficient for
     *  sorting integers within a limited range.
     *
     * Time Complexity :
     *  Best Case: O(n + k)
     *  Avg Case: O(n + k)
     *  Worst Case: O(n log n)
     * 
     *      where 𝑛 is the number of elements in the array,
     *      and 𝑘 is the range of the input values.
     * 
     * This makes Counting Sort efficient for scenarios where the
     *  range 𝑘 is not significantly larger than the number of
     *  elements 𝑛.
     */
    public static void CountingSort(int[] array)
    {
        var max = array.Max();
        var min = array.Min();
        var range = max - min + 1;

        var count = new int[range];
        var output = new int[array.Length];

        foreach (var num in array)
            count[num - min]++;

        for (var i = 1; i < count.Length; i++)
            count[i] += count[i - 1];

        for (var i = array.Length - 1; i >= 0; i--)
        {
            output[count[array[i] - min] - 1] = array[i];
            count[array[i] - min]--;
        }

        for (var i = 0; i < array.Length; i++)
            array[i] = output[i];
    }
    
    /*
     * Radix Sort is a non-comparison-based sorting algorithm that
     *  sorts integers by processing individual digits, starting
     *  from the least significant digit to the most significant digit,
     *  using a stable subroutine like Counting Sort. This process
     *  ensures the integers are sorted correctly by repeatedly
     *  grouping and ordering them based on their digit values.
     *
     * Time Complexity :
     *  Best Case: O(n * k)
     *  Avg Case: O(n * k)
     *  Worst Case: O(n * k)
     *
     *      where 𝑛 is the number of elements in the array, and
     *      k is the number of digits in the largest number.
     *
     * This makes Radix Sort efficient for sorting large lists of
     *  integers with a fixed digit length.
     */
    #region RadixSort
    public static void RadixSort(int[] array)
    {
        var max = array.Max();
        
        for (var exp = 1; max / exp > 0; exp *= 10)
            CountingSortByDigit(array, exp);
    }

    private static void CountingSortByDigit(int[] array, int exp)
    {
        var n = array.Length;
        var output = new int[n];
        var count = new int[10];

        for (var i = 0; i < n; i++)
            count[(array[i] / exp) % 10]++;

        for (var i = 1; i < 10; i++)
            count[i] += count[i - 1];

        for (var i = n - 1; i >= 0; i--)
        {
            output[count[(array[i] / exp) % 10] - 1] = array[i];
            count[(array[i] / exp) % 10]--;
        }

        for (var i = 0; i < n; i++)
            array[i] = output[i];
    }
    #endregion
    
    /*
     * Bucket Sort is a distribution sorting algorithm that divides
     *  the input array into several buckets, then sorts each bucket
     *  individually using a sorting algorithm like insertion sort,
     *  and finally concatenates the sorted buckets to produce the
     *  sorted array. This approach is especially efficient for
     *  uniformly distributed data.
     *
     * Time Complexity :
     *  Best Case: O(n + k)
     *  Avg Case: O(n + k)
     *  Worst Case: O(n^2) - Occurs when all elements fall into a
     *      single bucket, causing the need for sorting within that bucket.
     *
     *  where 𝑛 is the number of elements in the array, and
     *  𝑘 is the number of buckets. The overall efficiency depends on
     *  the distribution of elements across the buckets.
     */
    public static void BucketSort(int[] array)
    {
        //int n = array.Length;
        if (array.Length <= 0)
            return;

        var buckets = new List<int>[array.Length];

        for (var i = 0; i < array.Length; i++)
            buckets[i] = [];

        foreach (var value in array)
        {
            var bucketIndex = value * array.Length;
            bucketIndex = Math.Min(bucketIndex, array.Length - 1);
            buckets[bucketIndex].Add(value);
        }

        for (var i = 0; i < array.Length; i++)
            buckets[i].Sort();

        var index = 0;
        for (var i = 0; i < array.Length; i++)
            foreach (var value in buckets[i])
                array[index++] = value;
    }
}