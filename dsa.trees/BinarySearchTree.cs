using dsa.core;

namespace dsa.trees
{
    internal class BinarySearchTree : BinaryTree
    {
        /// <summary>
        /// Create Binary Search Tree (starting from root as array[0])
        /// </summary>
        /// <returns></returns>
        public BinarySearchTree(int[] arr)
        {
            Create(arr);
        }

        // Asked on ("@IBM Interview!!!");
        public new void Create(int[] data)
        {
            if (data.Length < 1)
            {
                root = null;
                return;
            }
            root = null;
            for (int i = 0; i < data.Length; i++)
            {
                root = InsertInBST(root, data[i]);
            }
        }

        private static TreeNode InsertInBST(TreeNode? node, int data)
        {
            if (node == null)
            {
                return new TreeNode(data);
            }
            if (data < node.Value)
            {
                node.Left = InsertInBST(node.Left, data);
            }
            else
            {
                node.Right = InsertInBST(node.Right, data);
            }
            return node;
        }

        public new bool Search(int value)
        {
            return SearchInternal(root, value);
        }

        private static bool SearchInternal(TreeNode? tree, int val)
        {
            if (tree == null)
            {
                return false;
            }
            if (tree.Value == val)
            {
                return true;
            }
            else if (val > tree.Value)
            {
                SearchInternal(tree.Right, val);
            }
            else
            {
                SearchInternal(tree.Left, val);
            }
            return false;
        }
    }
}
