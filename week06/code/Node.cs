public class Node
{
    public int Data { get; set; }
    public Node? Left { get; set; }
    public Node? Right { get; set; }

    public Node(int data)
    {
        Data = data;
        Left = null;
        Right = null;
    }

    // --------------------------------------------------
    // PROBLEM 1: Insert Unique Values Only
    // --------------------------------------------------
    public void Insert(int value)
    {
        // Do not allow duplicates
        if (value == Data)
        {
            return;
        }
        else if (value < Data)
        {
            if (Left == null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else // value > Data
        {
            if (Right == null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    // --------------------------------------------------
    // PROBLEM 2: Contains
    // --------------------------------------------------
    public bool Contains(int value)
    {
        if (value == Data)
            return true;
        else if (value < Data)
            return Left != null && Left.Contains(value);
        else
            return Right != null && Right.Contains(value);
    }

    // --------------------------------------------------
    // PROBLEM 4: Tree Height
    // --------------------------------------------------
    public int GetHeight()
    {
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;

        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
