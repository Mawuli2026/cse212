public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    /// <summary>
    /// Problem 1: Insert unique values only
    /// </summary>
    public void Insert(int value)
    {
        // Skip duplicates (no duplicate nodes in BST)
        if (value == Data)
            return;

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else // value > Data
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    /// <summary>
    /// Problem 2: Check if a value exists in the tree
    /// </summary>
    public bool Contains(int value)
    {
        if (value == Data)
            return true;
        else if (value < Data && Left is not null)
            return Left.Contains(value);
        else if (value > Data && Right is not null)
            return Right.Contains(value);
        else
            return false;
    }

    /// <summary>
    /// Problem 4: Compute the height of the tree
    /// </summary>
    public int GetHeight()
    {
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
