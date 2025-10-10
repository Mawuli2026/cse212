using System.Collections;

public class BinarySearchTree : IEnumerable<int>
{
    private Node? _root;

    /// <summary>
    /// Insert a new node in the BST.
    /// </summary>
    public void Insert(int value)
    {
        // Create new node
        Node newNode = new(value);
        // If the tree is empty, make the new node the root
        if (_root is null)
        {
            _root = newNode;
        }
        // Otherwise, insert recursively starting at the root
        else
        {
            _root.Insert(value);
        }
    }

    /// <summary>
    /// Check to see if the tree contains a certain value.
    /// </summary>
    public bool Contains(int value)
    {
        return _root != null && _root.Contains(value);
    }

    /// <summary>
    /// Enables "foreach" iteration through the tree (ascending order).
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the BST (smallest → largest).
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var numbers = new List<int>();
        TraverseForward(_root, numbers);
        foreach (var number in numbers)
        {
            yield return number;
        }
    }

    /// <summary>
    /// Recursive helper for forward (ascending) traversal.
    /// </summary>
    private void TraverseForward(Node? node, List<int> values)
    {
        if (node is not null)
        {
            TraverseForward(node.Left, values);
            values.Add(node.Data);
            TraverseForward(node.Right, values);
        }
    }

    /// <summary>
    /// Iterate backward through the BST (largest → smallest).
    /// </summary>
    public IEnumerable Reverse()
    {
        var numbers = new List<int>();
        TraverseBackward(_root, numbers);
        foreach (var number in numbers)
        {
            yield return number;
        }
    }

    /// <summary>
    /// Recursive helper for backward (descending) traversal.
    /// </summary>
    private void TraverseBackward(Node? node, List<int> values)
    {
        // Base case: stop when null
        if (node is null)
            return;

        // Visit right subtree first for descending order
        TraverseBackward(node.Right, values);

        // Then visit current node
        values.Add(node.Data);

        // Finally visit left subtree
        TraverseBackward(node.Left, values);
    }

    /// <summary>
    /// Get the height of the tree.
    /// </summary>
    public int GetHeight()
    {
        if (_root is null)
            return 0;
        return _root.GetHeight();
    }

    /// <summary>
    /// Converts the BST contents to a readable string.
    /// </summary>
    public override string ToString()
    {
        return "<Bst>{" + string.Join(", ", this) + "}";
    }
}

/// <summary>
/// Small helper extension for testing or debug display.
/// </summary>
public static class IntArrayExtensionMethods
{
    public static string AsString(this IEnumerable array)
    {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}
