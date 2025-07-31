/// Problem 1: InsertTail
/// 
/// For this problem, I am to add a new value to the end of the linked list
/// I will be implementing the InsertTail(int value) method so that it correctly adds a new node at the end of the linked list.
/// Looking at the InsertTailTests class, the tests methods are:
/// 
/// Test 1: InsertTail_Empty
/// 
/*public void InsertTail_Empty()
{
    var ll = new LinkedList();

    Assert.IsTrue(ll.HeadAndTailAreNull());
    ll.InsertTail(1);
    Assert.IsTrue(ll.HeadAndTailAreNotNull());
    Assert.AreEqual("<LinkedList>{1}", ll.ToString());
}
*/
///The current output is {5, 4, 3, 2, 2, 2, 1}
/// The expected output is {5, 4, 3, 2, 2, 2, 1, 0, -1}
/// 
/// I ran the test and it returned the following:
/// 
/*  
Passed InsertTail_Empty [4 ms]
Passed InsertTail_Basic [< 1 ms]
Passed RemoveTail_Empty [< 1 ms]
*/
///This indicates the implementation is successful
/// 
/// Problem 2: RemoveTail
/// 
/// For this problem, I am to remove the last node (the tail) from the linked list
/// I will first determine the list is empty (_tail is null), if it is empty do nothing
/// If the list has only one node (_head ==_tail):
/// -set both _head and _tail to null
/// Otherwise:
/// -Move_tail to its Prev node
/// -Set new tail's Next to null to unlock the next node
///
/// I ran the test and it returned the following:
/// 
/*  
  Passed RemoveTail_Empty [5 ms]
  Passed RemoveTail_Single [< 1 ms]
  Passed RemoveTail_Basic [< 1 ms]
*/
///This indicates the implementation is successful
/// 
/// Problem 3: Remove(int value)
/// 
/// For this problem, I am to search the linked list for the first node containing value and remove that single node
/// I will start from the head and search for the first node whose Data == value
/// If the value is not found it has to do nothing
/// If the value is found:
/// If it is the head -> call RemoveHead()
/// If it is tail -> call RemoveTail()
/// Otherwise:
/// Bypass the node by setting:
/// node.Prev.Next = node.Next
/// node.Next.Prev = node.Prev
/// Return after removing the first match
///
/// I ran the test and it returned the following:
/// 
/*  
  Passed Remove_Empty [1 ms]
  Passed Remove_Single [< 1 ms]
  Passed Remove_Multiple [1 ms]
*/
///This indicates the implementation is successful
/// 
/// Problem 4: Replace
/// 
/// For this problem, I am to replace all values in the list that match oldValue with newValue
/// This is different from Remove, which only stops at the first match - Replace should go to the entire list.
/// I will start at the head of the list
/// Go through every node using a while loop
/// For each node:
/// -if node.Data == oldValue, update node.Data = newValue
/// It will continue until the end of the list
/// 
/// I ran the test and it returned the following:
/// 
/*  
  Passed Replace_NonExistant [5 ms]
  Passed Replace_Empty [< 1 ms]
  Passed Replace_Multiple [< 1 ms]
*/
///This indicates the implementation is successful
/// 
/// Problem 5: Reverse
/// 
/// For this problem, I am to implement the Reverse()method so that I can iterate background through the list - from tail to head
/// This will enable this kind of use:
/*
foreach (var item in myLinkedList.Reverse())
{
    Console.WriteLine(item);
}
*/
/// I will start from the tail of the list
/// I will use a while loop to go to backwards (using node.Prev)
/// For each node, yield return its Data
/// When the null is reached it will stop 
/// I ran the test and it returned the following:
/// 
/*  
  Passed Replace_NonExistant [7 ms]
  Passed Replace_Empty [< 1 ms]
  Passed Replace_Multiple [1 ms]
*/
///This indicates the implementation is successful
/// 

/// This concludes all the tests
/// I ran the dotnet test and it returned:
/// Passed!  - Failed:     0, Passed:    15, Skipped:     0, Total:    15, Duration: 78 ms - code.dll (net8.0)
/// This indicates that I correctly modified the program and it returned 15 Passed Test - have completed all modifications 


using System.Collections;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        // Create new node
        Node newNode = new(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, then only head will be affected.
        else
        {
            newNode.Next = _head; // Connect new node to the previous head
            _head.Prev = newNode; // Connect the previous head to the new node
            _head = newNode; // Update the head to point to the new node
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        // TODO Problem 1

        Node newNode = new(value); //create a new node with the given value

        //if the list is empty, both head and tail should point to this new node
        if (_tail is null)
        {
            _head = newNode; // first node becomes the head
            _tail = newNode; // first node also becomes the tail
        }

        else
        {
            _tail.Next = newNode; // link the current tail's Next to the new node
            newNode.Prev = _tail; // link the new node's Prev to the current tail
            _tail = newNode; //update the tail to point to the new node
        }

    }


    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        // If the list has only one item in it, then set head and tail 
        // to null resulting in an empty list.  This condition will also
        // cover an empty list.  Its okay to set to null again.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If the list has more than one item in it, then only the head
        // will be affected.
        else if (_head is not null)
        {
            _head.Next!.Prev = null; // Disconnect the second node from the first node
            _head = _head.Next; // Update the head to point to the second node
        }
    }


    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {
        // TODO Problem 2

        // If the list is empty or has one node
        if (_head == _tail)
        {
            //set both to null
            _head = null;
            _tail = null;
        }

        // if there's more than one node
        else if (_tail is not null)
        {
            _tail = _tail.Prev; // move tail to the previous node
            _tail!.Next = null; // Disconnect the old tail
        }

    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        // Search for the node that matches 'value' by starting at the 
        // head of the list.
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If the location of 'value' is at the end of the list,
                // then we can call insert_tail to add 'new_value'
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                // For any other location of 'value', need to create a 
                // new node and reconnect the links to insert.
                else
                {
                    Node newNode = new(newValue);
                    newNode.Prev = curr; // Connect new node to the node containing 'value'
                    newNode.Next = curr.Next; // Connect new node to the node after 'value'
                    curr.Next!.Prev = newNode; // Connect node after 'value' to the new node
                    curr.Next = newNode; // Connect the node containing 'value' to the new node
                }

                return; // We can exit the function after we insert
            }

            curr = curr.Next; // Go to the next node to search for 'value'
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
    {
        // TODO Problem 3
        Node? curr = _head;//start from the beginning
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                if (curr == _head)
                {
                    RemoveHead();// special case: it's the head
                }
                else if (curr == _tail)
                {
                    RemoveTail(); // special case: it's the tail
                }
                else
                {
                    //Bypass the current node in the middle
                    curr.Prev!.Next = curr.Next;
                    curr.Next!.Prev = curr.Prev;
                }
                return; // remove only the first match
            }
            curr = curr.Next; // move the next node
        }

    }

    /// <summary>
    /// Search for all instances of 'oldValue' and replace the value to 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        // TODO Problem 4
        Node? curr = _head; // Start from the head

        while (curr is not null)
        {
            if (curr.Data == oldValue)
            {
            curr.Data = newValue; // Replace value
            }

            curr = curr.Next; // Continue to next node
        }
    }

    /// <summary>
    /// Yields all values in the linked list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        // call the generic version of the method
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head; // Start at the beginning since this is a forward iteration.
        while (curr is not null)
        {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Next; // Go forward in the linked list
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    public IEnumerable Reverse()
    {
        // TODO Problem 5

        Node? curr = _tail;// I will start at the end of the list

        while (curr is not null)
        {
            yield return curr.Data; // yield each value going backward
            curr = curr.Prev; // move to the previous node
        }
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Just for testing.
    public Boolean HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    // Just for testing.
    public Boolean HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }
}

public static class IntArrayExtensionMethods {
    public static string AsString(this IEnumerable array) {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}