using System;
using System.Collections.Generic;

namespace tree
{
    class Program
    {
        static void Main(string[] args)
        {
            // Display all employee names from top-down organizational chart.
            // Also show Level of each employee (assuming root to be "1")
            //Console.WriteLine("@HelloGybe Interview!!!");
            //TrieNode company = CreateCompanyTree();
            //int depth = company.FindHeightOf("Jr Umesh");
            //Console.WriteLine("Height of jr. umesh is " + depth);
            //company.ShowAll();

            Console.WriteLine("@IBM Interview!!!");
            //int[] arr = { 12, 6, 127, 28, 9, 3, 111, 0 };
            //Ref: https://iq.opengenus.org/binary-tree-traversals-inorder-preorder-postorder/
            int[] arr = { 30, 20, 40, 15, 25, 35, 50, 5, 18, 45, 60 };
            VariousTreeOperations(arr);

            Console.Read();
        }

        public static void VariousTreeOperations(int[] arr)
        {
            // 0. Original Source Array
            Console.WriteLine($"{Environment.NewLine}Source Array Data: {string.Join(",", arr)}");

            // 1. Construct Binary search tree example
            Console.WriteLine($"{Environment.NewLine}Binary Search Tree Example (Start inserting following parent>left, & parent<=right)");
            Node binarySearchTree = TreeHelper.CreateBinarySearchTree(arr);
            binarySearchTree.Visualize();

            Console.WriteLine($"{Environment.NewLine}BST Traversals");
            binarySearchTree.Traverse(TreeTraversal.InTraversal);
            binarySearchTree.Traverse(TreeTraversal.PreTraversal_Iterative);
            binarySearchTree.Traverse(TreeTraversal.PostTraversal);
            binarySearchTree.Traverse(TreeTraversal.BFSTraversal);
            binarySearchTree.Traverse(TreeTraversal.BFSTraversalWithLabel);

            // 2. Construct binary Tree example
            Console.WriteLine($"{Environment.NewLine}Binary Tree Example (Start inserting from mid, and recursively from left/right halves)");
            Node binaryTree = TreeHelper.CreateBinaryTree(arr);
            binaryTree.Visualize();
            //binaryTree.Traverse(TreeTraversal.InTraversal);
            //binaryTree.Traverse(TreeTraversal.PreTraversal);
            //binaryTree.Traverse(TreeTraversal.PostTraversal);
            //binaryTree.Traverse(TreeTraversal.BFSTraversal);

            // 3. Construct complete binary tree (top-down, left-right pattern)
            Console.WriteLine($"{Environment.NewLine}Complete Binary Tree Example (Start inserting from top-down, and left-right approach)");
            Node tree = TreeHelper.CreateCompleteBinaryTree(arr);
            tree.Visualize();
            //tree.Traverse(TreeTraversal.InTraversal);
            //tree.Traverse(TreeTraversal.PreTraversal);
            //tree.Traverse(TreeTraversal.PostTraversal);
            //tree.Traverse(TreeTraversal.BFSTraversal);
            //tree.Traverse(TreeTraversal.BFSTraversalWithLabel);

            //Console.WriteLine($"{Environment.NewLine}Search if the element {45} exists in Tree? {TreeHelper.Search(tree, 415)}");
        }

        public static TrieNode CreateCompanyTree()
        {
            TrieNode rootNode = new TrieNode("Company");
            rootNode.AddChildren(new List<TrieNode>
                {
                    new TrieNode("Haris", "CEO"),
                    new TrieNode("James", "CTO"),
                    new TrieNode("Sahas", "CFO")
                });

            rootNode.Children[1].AddChildren(new List<TrieNode>
                {
                    new TrieNode("Kul", "Security Manager"),
                    new TrieNode("Umesh", "Architect"),
                });
            rootNode.Children[1].Children[1].AddChildren(new List<TrieNode>
                {
                    new TrieNode("Jr Umesh", "CCNA"),
                    new TrieNode("Sr Umesh", "DevSecOps"),
                });

            rootNode.Children[0].AddChildren(new List<TrieNode>
                {
                    new TrieNode("Subash", "Manager"),
                    new TrieNode("Gita", "Marketing"),
                });

            return rootNode;
        }
    }
}
