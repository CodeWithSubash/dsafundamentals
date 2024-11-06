using dsa.core;

namespace dsa.trees;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Tree Examples!!!");

        //int[] arr = { 12, 6, 127, 28, 9, 3, 111, 0 };
        int[] arr = { 30, 20, 40, 15, 25, 35, 50, 5, 18, 45, 60 };
        Console.WriteLine($"Input Data: {string.Join(",", arr)}");

        //RunBinaryTreeExample(arr);
        //RunBinarySearchTreeExample(arr);
        //RunCompleteBinaryTreeExample(arr);
        RunTrieExample();

        Console.ReadLine();
    }

    public static void RunTrieExample()
    {
        // Display all employee names from top-down organizational chart.
        // Also show Level of each employee (assuming root to be "1")
        Console.WriteLine("@HelloGybe Interview!!!");
        TrieNode company = ConstructSampleOrganization();
        int depth = company.FindHeightOf("Jr Umesh");
        Console.WriteLine("Height of jr. umesh is " + depth);
        company.Display();
        company.DisplayNicer();
    }
    public static void RunBinaryTreeExample(int[] arr)
    {
        // 2. Construct binary Tree example
        Console.WriteLine($"{Environment.NewLine}Binary Tree Example (Start inserting from mid, and recursively from left/right halves)");
        BinaryTree binaryTree = new BinaryTree(arr);
        binaryTree.Visualize();
        binaryTree.Traverse(TreeTraversal.InTraversal);
        binaryTree.Traverse(TreeTraversal.PreTraversal);
        binaryTree.Traverse(TreeTraversal.PostTraversal);
        binaryTree.Traverse(TreeTraversal.BFSTraversal);
    }

    public static void RunBinarySearchTreeExample(int[] arr)
    {
        // 1. Construct Binary search tree example
        Console.WriteLine($"{Environment.NewLine}Binary Search Tree Example (Start inserting following parent>left, & parent<=right)");
        BinarySearchTree binarySearchTree = new BinarySearchTree(arr);
        binarySearchTree.Visualize();
        binarySearchTree.Traverse(TreeTraversal.InTraversal);
        binarySearchTree.Traverse(TreeTraversal.PreTraversal_Iterative);
        binarySearchTree.Traverse(TreeTraversal.PostTraversal);
        binarySearchTree.Traverse(TreeTraversal.BFSTraversal);
        binarySearchTree.Traverse(TreeTraversal.BFSTraversalWithLabel);

        Console.WriteLine($"{Environment.NewLine}Search if the element {45} exists in Tree? {binarySearchTree.Search(415)}");
    }

    public static void RunCompleteBinaryTreeExample(int[] arr)
    {
        // 3. Construct complete binary tree (top-down, left-right pattern)
        Console.WriteLine($"{Environment.NewLine}Complete Binary Tree Example (Start inserting from top-down, and left-right approach)");
        CompleteBinaryTree completeBinaryTree = new CompleteBinaryTree(arr);
        completeBinaryTree.Visualize();
        completeBinaryTree.Traverse(TreeTraversal.InTraversal);
        completeBinaryTree.Traverse(TreeTraversal.PreTraversal);
        completeBinaryTree.Traverse(TreeTraversal.PostTraversal);
        completeBinaryTree.Traverse(TreeTraversal.BFSTraversal);
        completeBinaryTree.Traverse(TreeTraversal.BFSTraversalWithLabel);
    }

    public static TrieNode ConstructSampleOrganization()
    {
        var rootNode = new TrieNode("Company");
        rootNode.AddChildren(
                [
                    new TrieNode("Haris", "CEO"),
                    new TrieNode("James", "CTO"),
                    new TrieNode("Sahas", "CFO")
                ]);

        rootNode.Children[1].AddChildren(
                [
                    new TrieNode("Kul", "Security Manager"),
                    new TrieNode("Umesh", "Architect"),
                ]);
        rootNode.Children[1].Children[1].AddChildren(
                [
                    new TrieNode("Jr Umesh", "CCNA"),
                    new TrieNode("Sr Umesh", "DevSecOps"),
                ]);

        rootNode.Children[0].AddChildren(
                [
                    new TrieNode("Subash", "Manager"),
                    new TrieNode("Gita", "Marketing"),
                ]);

        return rootNode;
    }
}
