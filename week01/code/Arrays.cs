using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Plan to generate an array of multiples:
        // - First, make an array that can store 'length' number of elements.
        // - Loop from 0 up to one less than the length.
        // - For each position, place the value of 'number' multiplied by (index + 1).
        //   Example: index 0 → number*1, index 1 → number*2, and so on.
        // - Once the loop ends, return the filled array.

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Plan to rotate the list to the right:
        // - The idea is to move the last 'amount' of items to the front of the list.
        // - Compute where that last part starts: total count minus the shift amount.
        // - Take out that portion of the list using GetRange.
        // - Remove those items from the end of the original list.
        // - Then insert the removed items back to the beginning of the list using InsertRange.

        int n = data.Count;
        int splitIndex = n - amount;

        List<int> tail = data.GetRange(splitIndex, amount);
        data.RemoveRange(splitIndex, amount);
        data.InsertRange(0, tail);
    }
}