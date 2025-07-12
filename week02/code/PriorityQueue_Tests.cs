using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_1()
    {
    var queue = new PriorityQueue();
    queue.Enqueue("A", 2);
    queue.Enqueue("B", 3);
    queue.Enqueue("C", 1);
    
    string result = queue.Dequeue();
    Assert.AreEqual("B", result); // Highest priority
    }

    /*{
        var priorityQueue = new PriorityQueue();
        Assert.Fail("Implement the test case and then remove this.");
    }*/

    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
    {
        /*var priorityQueue = new PriorityQueue();
        Assert.Fail("Implement the test case and then remove this.");*/

         var queue = new PriorityQueue();
         queue.Enqueue("X", 5);
         queue.Enqueue("Y", 3);
         queue.Enqueue("Z", 5);

         string result = queue.Dequeue();
         Assert.AreEqual("X", result); // "X" comes first among items with priority 5
    }

    // Add more test cases as needed below.
}