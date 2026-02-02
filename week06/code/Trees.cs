public static class Trees
{
    /// <summary>
    /// Given a sorted list, create a balanced BST.
    /// </summary>
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree();
        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        return bst;
    }

    /// <summary>
    /// Recursively inserts middle values to create a balanced BST.
    /// </summary>
    private static void InsertMiddle(
        int[] sortedNumbers,
        int first,
        int last,
        BinarySearchTree bst)
    {
        // Base case
        if (first > last)
            return;

        // Find middle index
        int middle = (first + last) / 2;

        // Insert middle value
        bst.Insert(sortedNumbers[middle]);

        // Insert left half
        InsertMiddle(sortedNumbers, first, middle - 1, bst);

        // Insert right half
        InsertMiddle(sortedNumbers, middle + 1, last, bst);
    }
}
