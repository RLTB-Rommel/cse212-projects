/// Problem 1:
/// In this problem I am asked to modify the Insert method so the BST stores only unique values (like a sorted set).
/// My approach would be:
/// 1. Compare the new value to the current node's data.
///     - if equal: it will skip the duplicates or do nothing
///     - if less: it will go to the left child (create it if null, else recurse).
///     - if greater: go to the right child (create if if null, else recurse).
/// 2. Preserve BST ordering and prevent duplicates from being added.
/// 3. Stop recursion when value == Data, will ensure the tree remains unchanged if the value already exists.
/// 
/// I ran the : dotnet test --filter "ClassName=TreeInsertTests" -v n and it returned:
/*
    A total of 1 test files matched the specified pattern.
    Passed TreeInsert_Basic [6 ms]

    Test Run Successful.
    Total tests: 1
     Passed: 1
*/
///Problem 2: 
/// In this problem I am asked to do recursive search. In that case it has to return true if 'value' exists in this subtree.
/// My approach would be: 
/// 1. Compare 'value' to this node's data.
///     - if equal: found (exist) -> return true.
///     - if less: search left, if null(not exist) -> return false.
///     - if greater: search right, if null(not exist) -> return false.
/// 2. Use recursion to follow the BST property (left<data<right)
/// 
/// I ran the : dotnet test --filter "ClassName=TreeContainsTests" -v n and it returned:
/*A total of 1 test files matched the specified pattern.
  Passed TreeContains_Basic [4 ms]

Test Run Successful.
Total tests: 1
     Passed: 1
 Total time: 4.6233 Second
 */
///Problem 4: 
/// In this problem I am asked to determine the height of the given subtree.
/// My approach would be: 
/// 1. Define height = 1+max(height of left), (height of right): an empty subtree would have a height of 0.
///     - if a child is null , its height is zero
///     - recursively get left and right heights.
///     - return 1 + the larger of the two.
/// 
/// I ran the : dotnet test --filter "ClassName=TreeGetHeightTests" -v n and it returned:
/*  A total of 1 test files matched the specified pattern.
    Passed TreeGetHeight_Basic [108 ms]
    Test Run Successful.
    Total tests: 1
     Passed: 1
    Total time: 5.5609 Seconds
 */


public class Node
{
    public int Data { get; set; } // value stored at this node
    public Node? Right { get; private set; } // reference to right child (values> data)
    public Node? Left { get; private set; } // reference to left child (values<data)

    public Node(int data) // constructor assigns initial value
    {
        this.Data = data; // set data to provided value
    }

    public void Insert(int value) // insert 'value' into BST if not already present
    {
        // TODO Start Problem 1

        if (value == Data) return; // duplicate detected -> do nothing (skip insert)

        if (value < Data) // value should go to the left subtree
        {
            // Insert to the left
            if (Left is null) // if no left child yet
                Left = new Node(value); // create new node as left child
            else
                Left.Insert(value); // otherwise recurse to the left subtree
        }
        else // value should go to the left subtree
        {
            // Insert to the right
            if (Right is null) // if no right child yet
                Right = new Node(value); // create new node as right child
            else // 
                Right.Insert(value); // otherwise recurse to the right subtree
        }
    }

    public bool Contains(int value) // returns true if value exists in this subtree
    {
        // TODO Start Problem 2

        if (value == Data) return true; // match at current node
        if (value < Data) //look to the left subtree

            return Left is not null && Left.Contains(value); // recurse left (false if no left)
        return Right is not null && Right.Contains(value); // recurse right (false if no right)
        //return false;
    }

    public int GetHeight() // return height of this subtree
    {
        // TODO Start Problem 4
        int leftHeight = (Left!= null) ? Left.GetHeight() : 0; // null left -> height 0; else recurse
        int rightHeight = (Right!= null) ? Right.GetHeight() : 0; // null left -> height 0; else recurse
        return 1 + Math.Max(leftHeight, rightHeight);
        //return 0; // Replace this line with the correct return statement(s)
    }
}