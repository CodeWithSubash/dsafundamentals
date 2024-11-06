using dsa.core;

namespace dsa.trees
{
    //Ref: https://iq.opengenus.org/binary-tree-traversals-inorder-preorder-postorder/
    public static class TreeTraversalHelper
    {
        public static void Traverse(TreeNode node, TreeTraversal direction = TreeTraversal.InTraversal)
        {
            Console.Write($"\n{direction}:\n");
            switch (direction)
            {
                case TreeTraversal.PreTraversal:
                    PreTraversal(node);
                    break;
                case TreeTraversal.PreTraversal_Iterative:
                    PreTraversalIterative(node);
                    break;
                case TreeTraversal.PostTraversal:
                    PostTraversal(node);
                    break;
                case TreeTraversal.BFSTraversal:
                    BFSTraversal(node);
                    break;
                case TreeTraversal.BFSTraversalWithLabel:
                    BFSTraversalWithLevel(node);
                    break;
                default:
                    InTraversal(node);
                    break;
            }
        }

        public static void InTraversal(TreeNode? node)
        {
            if (node == null)
            {
                return;
            }
            InTraversal(node.Left);
            Visit(node);
            InTraversal(node.Right);
        }

        public static void PreTraversal(TreeNode? node)
        {
            if (node == null)
            {
                return;
            }
            Visit(node);
            PreTraversal(node.Left);
            PreTraversal(node.Right);
        }

        public static void PostTraversal(TreeNode? node)
        {
            if (node == null)
            {
                return;
            }
            PostTraversal(node.Left);
            PostTraversal(node.Right);
            Visit(node);
        }

        private static void PreTraversalIterative(TreeNode? node)
        {
            if (node == null)
            {
                return;
            }
            var stack = new Stack<TreeNode>();
            stack.Push(node);
            while (stack.Count > 0)
            {
                TreeNode current = stack.Pop();
                Visit(current);
                if (current.Right != null)
                    stack.Push(current.Right);
                if (current.Left != null)
                    stack.Push(current.Left);
            }
        }

        private static void BFSTraversal(TreeNode root)
        {
            var q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                TreeNode current = q.Dequeue();
                Visit(current);
                if (current.Left != null)
                {
                    q.Enqueue(current.Left);
                }
                if (current.Right != null)
                {
                    q.Enqueue(current.Right);
                }
            }
        }

        private static void BFSTraversalWithLevel(TreeNode root)
        {
            root.SetLevels(1);
            var q = new Queue<TreeNode>();
            q.Enqueue(root);
            int currentLevel = 1;
            while (q.Count > 0)
            {
                TreeNode current = q.Dequeue();
                if (current.Level > currentLevel)
                {
                    Console.WriteLine();
                    currentLevel++;
                }
                Visit(current);
                if (current.Left != null)
                {
                    q.Enqueue(current.Left);
                }
                if (current.Right != null)
                {
                    q.Enqueue(current.Right);
                }
            }
        }

        private static void Visit(TreeNode root)
        {
            Console.Write(root.Value + "-");
        }

    }
}
