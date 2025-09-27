using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items (A pri:1, B pri:3, C pri:2), then Dequeue once.
    // Expected Result: B should be removed (highest priority = 3).
    // Defect(s) Found: Original loop missed the last element during scan, causing wrong item removal.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 2);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("B", result);
    }

    [TestMethod]
    // Scenario: Enqueue items with equal highest priority (A pri:5, B pri:5). 
    // Expected Result: A should be removed first (FIFO among equals).
    // Defect(s) Found: Original code used >= instead of >, which incorrectly picked the last highest instead of the first.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 5);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("A", result);
    }

    [TestMethod]
    // Scenario: Attempt to Dequeue from empty queue.
    // Expected Result: InvalidOperationException("The queue is empty.") should be thrown.
    // Defect(s) Found: None (exception was implemented correctly).
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

    [TestMethod]
    // Scenario: Enqueue A(1), B(3), C(2). Dequeue twice.
    // Expected Result: First dequeue = B (pri:3), second dequeue = C (pri:2).
    // Defect(s) Found: Original code never removed dequeued item from _queue, so same element could be returned again.
    public void TestPriorityQueue_MultipleDequeues()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 2);

        var first = priorityQueue.Dequeue();
        var second = priorityQueue.Dequeue();

        Assert.AreEqual("B", first);
        Assert.AreEqual("C", second);
    }
}
