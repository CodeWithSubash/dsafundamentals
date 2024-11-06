using dsa.core;

namespace dsa.trees
{
    internal class BinaryTree
    {
        protected TreeNode? root;
        public BinaryTree()
        {
            root = null;
        }

        public BinaryTree(int[] arr)
        {
            Create(arr);
        }

        public void Visualize()
        {
            root?.PrintNice();
        }

        public void Print()
        {
            root?.Print();
        }

        public void Traverse(TreeTraversal direction = TreeTraversal.InTraversal)
        {
            if (root == null) return;
            TreeTraversalHelper.Traverse(root, direction);
        }

        /// <summary>
        /// Creates Binary Tree from array, root at middle and splitting recursively in two halves
        /// </summary>
        /// <returns></returns>
        public void Create(int[] arr)
        {
            root = arr.Length == 0 ? null : CreateInternal(arr, 0, arr.Length);
        }

        public bool Search(int value)
        {
            throw new NotImplementedException();
        }

        private static TreeNode? CreateInternal(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;
                var root = new TreeNode(arr[mid]);
                root.Left = CreateInternal(arr, left, mid);
                root.Right = CreateInternal(arr, mid + 1, right);
                return root;
            }
            return null;
        }
    }
}
