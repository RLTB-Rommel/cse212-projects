/// I initially ran the test to see if there are issues or broken codes. It returned the following info:
/// 
/// Failed!  - Failed:    12, Passed:     2, Skipped:     0, Total:    14, Duration: 5 s
/// 
/// For Problem 1: 
/// Using recursion, I am to find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
/// For example, if n = 3, it will compute 1*1 + 2*2 + 3*3 = 14.
/// Step 1: I will first define the base case
/// If n is 1, the only square to return will be 1*1, which is 1
/* if (n=1)
    {
        return 1;
    }   */

/// Step 2: For any number greater than 1, I will apply recursion
/// I will return the square of the current number (n*n),
/// plus the result of calling this same function with (n-1)
/// This will reduces the same problem size at every step.
/// 
/// I ran the detailed dotnet test and it returned:
/*  Passed CountWaysToClimb_Small [2 ms]
    Passed CountWaysToClimb_Medium [2 ms]

    Total tests: 14
    Passed: 2
    Failed: 12
*/
/// For Problem 2:
/// It required to generate all possible permutations of a given length from the characters in a string
/// this is without repeating characters within the same permutation
/// Step 1: I will use a function that builds permutation (ordered selection of characters without repetitionf)which tracks:
/// a) the current combination being built(a string called prefix)
/// b) the remaining characters that haven't been used yet
/// c) the target length
/// Step 2: I will define the base case
/// Step 3: I will define the recursive case
/// Step 4: Start the recursion
/// 
/// I ran the detailed dotnet test and it returned:
/*  Passed SumSquaresRecursive_Small [6 ms]  
    Passed SumSquaresRecursive_Large [< 1 ms]
    Passed PermutationsChoose_3 [5 ms]       
    Passed PermutationsChoose_2 [< 1 ms]     
    Passed PermutationsChoose_1 [< 1 ms]     
    Passed CountWaysToClimb_Small [4 ms]     
    Passed CountWaysToClimb_Medium [3 ms]  

    Total tests: 14
    Passed: 7
    Failed: 7
*/
/// For Problem 3:
/// It required to return the number of distinct ways to climb a staircase with n steps, where each move can be 1, 2, or 3 steps
/// I will use BigInteger type (from System.Numerics) because the values get extremely large for high n
/// Then use a recursive strategy that follows this recurrence relation:
/// 
/* ways(n) = ways(n-1) + ways(n-2) + ways(n-3)*/
/// 
/// I ran the detailed dotnet test and it returned:
/*  Passed SumSquaresRecursive_Small [2 ms]
    Passed SumSquaresRecursive_Large [< 1 ms]
    Passed PermutationsChoose_3 [1 ms]
    Passed PermutationsChoose_2 [< 1 ms]
    Passed PermutationsChoose_1 [< 1 ms]
    Passed CountWaysToClimb_Small [2 ms]
    Passed CountWaysToClimb_Medium [< 1 ms]
    Passed CountWaysToClimb_Large [< 1 ms]

    Total tests: 14
    Passed: 8
    Failed: 6
*/
/// For Problem 4:
/// I am provided a binary string that may include wildcard characters and the task is to:
/// Generate all possible binary strings
/// Replace each * with both 0 and 1
/// Return all possible combination in a list
/// Add each full valid string to the results list
/// 
/// I ran the detailed dotnet test and it returned:
/*  Passed SumSquaresRecursive_Small [6 ms]
    Passed SumSquaresRecursive_Large [< 1 ms]
    Passed PermutationsChoose_3 [3 ms]
    Passed PermutationsChoose_2 [< 1 ms]
    Passed PermutationsChoose_1 [< 1 ms]
    Passed CountWaysToClimb_Small [5 ms]
    Passed CountWaysToClimb_Medium [< 1 ms]
    Passed CountWaysToClimb_Large [2 ms]
    Passed WildcardBinary_6_Long [1 ms]
    Passed WildcardBinary_EmptyString [< 1 ms]
    Passed WildcardBinary_NoWildcards [< 1 ms]
    Passed WildcardBinary_3_Long [< 1 ms]

    Total tests: 14
    Passed: 12
    Failed: 2
*/
/// For Problem 5:
/// I am to use recursion to explore all paths from the start (0,0) to the goal G, moving in only four directions(up,down,left,right):
/// Collect all successful paths into a List<string> result
/// Step 1: initialize the current path
/// Step 2: handle invalid moves
/// Step 3: add current to cell path
/// Step 4: check for the goal
/// Step 5: recurse in all four directions
/// 
/// I ran the detailed dotnet test and it returned:
/*  Passed SumSquaresRecursive_Small [11 ms]
    Passed SumSquaresRecursive_Large [1 ms]
    Passed PermutationsChoose_3 [5 ms]
    Passed PermutationsChoose_2 [1 ms]
    Passed PermutationsChoose_1 [< 1 ms]
    Passed CountWaysToClimb_Small [7 ms]
    Passed CountWaysToClimb_Medium [2 ms]
    Passed CountWaysToClimb_Large [4 ms]
    Passed WildcardBinary_6_Long [< 1 ms]
    Passed WildcardBinary_EmptyString [< 1 ms]
    Passed WildcardBinary_NoWildcards [< 1 ms]
    Passed WildcardBinary_3_Long [< 1 ms]
    Passed SolveMaze_Small [17 ms]
    Passed SolveMaze_Large [3 ms]

    Total tests: 14
    Passed: 14
*/
///with that final test I have completed the task.
using System.Collections;

public static class Recursion // calculates the sum of squares from 1 to n recursively
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.  Remember to both express the solution 
    /// in terms of recursive call on a smaller problem and 
    /// to identify a base case (terminating case).  If the value of
    /// n <= 0, just return 0.   A loop should not be used.
    /// </summary>
    public static int SumSquaresRecursive(int n) // base case: if n is 1, I return 1 since 1 squared is 1
    {
        // TODO Start Problem 1
        if (n == 1)
        {
            return 1; // stops the recursion
        }

        return n*n + SumSquaresRecursive(n-1); // recursive case: square the current number and add the result of the function called with (n-1)
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.  This function
    /// should assume that each letter is unique (i.e. the 
    /// function does not need to find unique permutations).
    ///
    /// In mathematics, we can calculate the number of permutations
    /// using the formula: len(letters)! / (len(letters) - size)!
    ///
    /// For example, if letters was [A,B,C] and size was 2 then
    /// the following would the contents of the results array after the function ran: AB, AC, BA, BC, CA, CB (might be in 
    /// a different order).
    ///
    /// You can assume that the size specified is always valid (between 1 
    /// and the length of the letters list).
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // TODO Start Problem 2
        if (word.Length == size) //base case: if the word is long enough
        {
            results.Add(word); //add the word to the results list
            return; //no further recursion is needed
        }

        for (int i = 0; i < letters.Length; i++) // try every remaining letter
        {
            char currentChar = letters[i]; // pick a letter to add next
            string remaining = letters.Remove(i, 1); // remove that letter from the pool (avoid reuse)
            PermutationsChoose(results, remaining, size, word + currentChar);//recurse with updated word and remaining letters
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Imagine that there was a staircase with 's' stairs.  
    /// We want to count how many ways there are to climb 
    /// the stairs.  If the person could only climb one 
    /// stair at a time, then the total would be just one.  
    /// However, if the person could choose to climb either 
    /// one, two, or three stairs at a time (in any order), 
    /// then the total possibilities become much more 
    /// complicated.  If there were just three stairs,
    /// the possible ways to climb would be four as follows:
    ///
    ///     1 step, 1 step, 1 step
    ///     1 step, 2 step
    ///     2 step, 1 step
    ///     3 step
    ///
    /// With just one step to go, the ways to get
    /// to the top of 's' stairs is to either:
    ///
    /// - take a single step from the second to last step, 
    /// - take a double step from the third to last step, 
    /// - take a triple step from the fourth to last step
    ///
    /// We don't need to think about scenarios like taking two 
    /// single steps from the third to last step because this
    /// is already part of the first scenario (taking a single
    /// step from the second to last step).
    ///
    /// These final leaps give us a sum:
    ///
    /// CountWaysToClimb(s) = CountWaysToClimb(s-1) + 
    ///                       CountWaysToClimb(s-2) +
    ///                       CountWaysToClimb(s-3)
    ///
    /// To run this function for larger values of 's', you will need
    /// to update this function to use memoization.  The parameter
    /// 'remember' has already been added as an input parameter to 
    /// the function for you to complete this task.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {

        if (remember == null) //if no memo dictionary is provided, initialize it
            remember = new Dictionary<int, decimal>();

        if (remember.ContainsKey(s))
            return remember[s]; // return cached result if already computed

        // Base Cases
        if (s < 0)
            return 0; // no way to climb negative stairs
        if (s == 0)
            return 1; // one way to do nohing at step 0
        if (s == 1)
            return 1; // only one way to climb 1 step
        if (s == 2)
            return 2; // two ways : 2
        if (s == 3)
            return 4; // four ways: 1+1+1, 1+2, 2+1, 3

        // TODO Start Problem 3

        // Solve using recursion
        decimal ways = CountWaysToClimb(s - 1,remember) + CountWaysToClimb(s - 2,remember) + CountWaysToClimb(s - 3,remember); // check (s-1), (s-2), (s-3) using the same memo dictionary
        remember[s] = ways; // store the result in 'remember' for future use
        return ways; // return the total number of ways
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// A binary string is a string consisting of just 1's and 0's.  For example, 1010111 is 
    /// a binary string.  If we introduce a wildcard symbol * into the string, we can say that 
    /// this is now a pattern for multiple binary strings.  For example, 101*1 could be used 
    /// to represent 10101 and 10111.  A pattern can have more than one * wildcard.  For example, 
    /// 1**1 would result in 4 different binary strings: 1001, 1011, 1101, and 1111.
    ///	
    /// Using recursion, insert all possible binary strings for a given pattern into the results list.  You might find 
    /// some of the string functions like IndexOf and [..X] / [X..] to be useful in solving this problem.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    //main method to generate all binary strings by replacing '?' with '0' and '1'
    {
        // TODO Start Problem 4
        void Generate(string current, int index) // current is the string being built then 'current' is the string being built and 'index' is the current position in the input pattern 
        //helper recursive function to build binary combinations
        {
            if (index == pattern.Length)
            {
                results.Add(current); // base case: full string is built, add to results
                return; // exit this branch of recursion
            }
            if (pattern[index] == '*')
            {
                Generate(current + "0", index + 1); // recurse with '?' replaced by '0'
                Generate(current + "1", index + 1); // recurse with '?' replaced by '1'
            }
            else
            {
                Generate(current + pattern[index], index + 1); // recurse by keeping the current digit ('0' or '1')
            }
        }
        Generate("", 0); // start recursion with empty current string and index 0
    }

    /// <summary>
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<(int, int)>? currPath = null)
    {
        // If this is the first time running the function, then we need
        // to initialize the currPath list.
        if (currPath == null)
        {
            currPath = new List<(int, int)>(); // initialize path on first call
        }

        // TODO Start Problem 5
        // ADD CODE HERE
        if (!maze.IsValidMove(currPath,x, y))
        {
            return;
        }
        
        currPath.Add((x, y)); // add the current position to the path

        if (maze.IsEnd(x, y)) //if goal is reached, save the path and return   
        {
            results.Add(currPath.AsString());// Use this to add your path to the results array keeping track of complete maze solutions when you find the solution.
            return; //no need to continue exploring
        }
        //explore all four directions, passing a new copy of the current path
        SolveMaze(results, maze, x + 1, y, new List<(int, int)>(currPath));//down
        SolveMaze(results, maze, x - 1, y, new List<(int, int)>(currPath));//up
        SolveMaze(results, maze, x, y + 1, new List<(int, int)>(currPath));//right
        SolveMaze(results, maze, x, y - 1, new List<(int, int)>(currPath));//left

        currPath.RemoveAt(currPath.Count - 1); // remove the last step when backtracking
    }
}