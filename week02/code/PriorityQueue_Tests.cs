using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities and dequeue once.
    // Items: A (priority 2), B (priority 3), C (priority 1)
    // Expected Result: "B" should be dequeued first (highest priority).
    // Defect(s) Found: Priority comparison was incorrect before fix.
    // Test Result: Passed. "B" was correctly dequeued after fixing the priority logic.
    public void TestPriorityQueue_1()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("A", 2);
        queue.Enqueue("B", 3);
        queue.Enqueue("C", 1);

        string result = queue.Dequeue();
        Assert.AreEqual("B", result); // Highest priority
    }

    [TestMethod]
    // Scenario: Two items have the same highest priority (5), and were inserted in order X, Y, Z.
    // Items: X (priority 5), Y (priority 3), Z (priority 5)
    // Expected Result: "X" should be dequeued first since it was added before Z.
    // Defect(s) Found: None after fix. Order is preserved among equal-priority items.
    // Test Result: Passed. "X" was correctly dequeued before Z as expected.
    public void TestPriorityQueue_2()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("X", 5);
        queue.Enqueue("Y", 3);
        queue.Enqueue("Z", 5);

        string result = queue.Dequeue();
        Assert.AreEqual("X", result); // "X" comes first among items with priority 5
    }

    // Add more test cases as needed below.
}