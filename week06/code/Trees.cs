/// For Problem 5: The task is create tree from sorted list (balanced build)
/// My approach will be:
/// 1. Base case: if first>last -> empty range means it need to stop.
/// 2. Compute mid = (first + last)/2.
/// 3. Insert sortedNumbers[mid]into BST.
/// 4. Recurse left range: [first, mid -1].
/// 5. Recurse right range: [mid + 1,last].
/// I will be using indeces so there will be no subslicing since we do not create sublist.
/// 
/// I ran the : dotnet test --filter "ClassName=CreateTreeFromSortedListTests" -v n and it returned:
/*  A total of 1 test files matched the specified pattern.
    Passed CreateTreeFromSortedList_CountBy10s [7 ms]
    Passed CreateTreeFromSortedList_127Nodes [5 ms]
    Passed CreateTreeFromSortedList_128Nodes [< 1 ms]
    Passed CreateTreeFromSortedList_Single [< 1 ms]
    Passed CreateTreeFromSortedList_Empty [< 1 ms]

    Test Run Successful.
    Total tests: 5
     Passed: 5
    Total time: 3.3107 Seconds
 */ 


using System;
using System.Collections.Generic;

public static class Trees
{
    /// <summary>
    /// Given a sorted list (sorted_list), create a balanced BST.  If the values in the
    /// sortedNumbers were inserted in order from left to right into the BST, then it
    /// would resemble a linked list (unbalanced). To get a balanced BST, the
    /// InsertMiddle function is called to find the middle item in the list to add
    /// first to the BST. The InsertMiddle function takes the whole list but also takes
    /// a range (first to last) to consider.  For the first call, the full range of 0 to
    /// Length-1 used.
    /// </summary>
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree(); // Create an empty BST to start with 
        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        return bst;
    }

    /// <summary>
    /// This function will attempt to insert the item in the middle of 'sortedNumbers' into
    /// the 'bst' tree. The middle is determined by using indices represented by 'first' and
    /// 'last'.
    /// For example, if the function was called on:
    ///
    /// sortedNumbers = new[]{10, 20, 30, 40, 50, 60};
    /// first = 0;
    /// last = 5;
    /// 
    /// then the value 30 (index 2 which is the middle) would be added 
    /// to the 'bst' (the insert function in the <see cref="BinarySearchTree"/> can be used
    /// to do this).   
    ///
    /// Subsequent recursive calls are made to insert the middle from the values 
    /// before 30 and the values after 30.  If done correctly, the order
    /// in which values are added (which results in a balanced bst) will be:
    /// 
    /// 30, 10, 20, 50, 40, 60
    /// 
    /// This function is intended to be called the first time by CreateTreeFromSortedList.
    ///
    /// The purpose for having the first and last parameters is so that we do 
    /// not need to create new sub-lists when we make recursive calls.  Avoid 
    /// using list slicing to create sub-lists to solve this problem.    
    /// </summary>
    /// <param name="sortedNumbers">input numbers that are already sorted</param>
    /// <param name="first">the first index in the sortedNumbers to insert</param>
    /// <param name="last">the last index in the sortedNumbers to insert</param>
    /// <param name="bst">the BinarySearchTree in which to insert the values</param>
    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        // TODO Start Problem 5
        if (first > last) // base case: no items in this range
            return;

        int mid = (first + last) / 2; //pick the middle index
        bst.Insert(sortedNumbers[mid]); // insert the middle value first

        //recursively insert left and right subranges
        InsertMiddle(sortedNumbers, first, mid - 1, bst); //build left half
        InsertMiddle(sortedNumbers, mid + 1, last, bst); //build right half

    }
}

/// with this final task
/// I ran the full test : dotnet test -v n and it returned:
/*  A total of 1 test files matched the specified pattern.
    Passed TreeInsert_Basic [10 ms]
    Passed TreeContains_Basic [< 1 ms]
    Passed TreeReverse_Basic [2 ms]
    Passed TreeGetHeight_Basic [1 ms]
    Passed CreateTreeFromSortedList_CountBy10s [< 1 ms]
    Passed CreateTreeFromSortedList_127Nodes [9 ms]
    Passed CreateTreeFromSortedList_128Nodes [< 1 ms]
    Passed CreateTreeFromSortedList_Single [< 1 ms]
    Passed CreateTreeFromSortedList_Empty [< 1 ms]

    Test Run Successful.
    Total tests: 9
     Passed: 9
    Total time: 3.4595 Seconds
 */ 