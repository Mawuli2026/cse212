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
        // PLAN:
        // 1. Create an array with the size equal to 'length'.
        // 2. Loop from 0 up to (length - 1).
        // 3. For each index i:
        //    - Calculate the (i+1)th multiple of 'number' (number * (i+1)).
        //    - Store that value into the array at position i.
        // 4. After the loop finishes, return the array.
        //
        // Example: MultiplesOf(3, 5)
        // i=0 -> 3 * (0+1) = 3
        // i=1 -> 3 * (1+1) = 6
        // i=2 -> 3 * (2+1) = 9
        // i=3 -> 3 * (3+1) = 12
        // i=4 -> 3 * (4+1) = 15
        // result = {3, 6, 9, 12, 15}

        double[] result = new double[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  
    /// Example: data = {1,2,3,4,5,6,7,8,9}, amount = 3  
    /// Result = {7,8,9,1,2,3,4,5,6}  
    /// The value of amount will be in the range of 1 to data.Count, inclusive.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // PLAN:
        // 1. Get the total number of elements (n = data.Count).
        // 2. Handle special cases:
        //    - If n == 0, return immediately (nothing to rotate).
        //    - If amount == n, the list stays the same, return.
        // 3. Normalize amount = amount % n (just in case).
        // 4. Split the list into two parts:
        //    - tail = the last 'amount' elements.
        //    - head = the first 'n - amount' elements.
        // 5. Clear the original list.
        // 6. Add tail first, then head, back into the list.
        //
        // Example: data = {1,2,3,4,5,6,7,8,9}, amount=3
        // tail = {7,8,9}, head = {1,2,3,4,5,6}
        // result = {7,8,9,1,2,3,4,5,6}

        int n = data.Count;
        if (n == 0) return;

        amount = amount % n;
        if (amount == 0) return;

        List<int> tail = data.GetRange(n - amount, amount);
        List<int> head = data.GetRange(0, n - amount);

        data.Clear();
        data.AddRange(tail);
        data.AddRange(head);
    }
}
