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
            }
            root = new TreeNode(data[0]);
            for (int i = 1; i < data.Length; i++)
            {
                InsertInBST(root, data[i]);
            }
        }

        private static void InsertInBST(TreeNode node, int data)
        {
            if (data > node.Value)
            {
                if (node.Right != null)
                {
                    InsertInBST(node.Right, data);
                }
                else
                {
                    node.Right = new TreeNode(data);
                }
            }
            else
            {
                if (node.Left != null)
                {
                    InsertInBST(node.Left, data);
                }
                else
                {
                    node.Left = new TreeNode(data);
                }
            }
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
