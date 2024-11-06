using dsa.core;

namespace dsa.trees
{
    internal class CompleteBinaryTree : BinaryTree
    {
        public CompleteBinaryTree()
        {
        }

        public CompleteBinaryTree(int[] data)
        {
            Create(data);
        }

        public new void Create(int[] data)
        {
            root = CreateInternal(data);
        }

        public static TreeNode? CreateInternal(int[] arr, int index = 0, TreeNode? current = null)
        {
            if (index < arr.Length)
            {
                current = new TreeNode(arr[index]);
                current.Left = CreateInternal(arr, 2 * index + 1, current.Left);
                current.Right = CreateInternal(arr, 2 * index + 2, current.Right);
            }
            return current;
        }
    }
}
