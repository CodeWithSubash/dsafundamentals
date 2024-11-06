namespace dsa.core
{
    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode? Left { get; set; }
        public TreeNode? Right { get; set; }
        public int Level { get; set; }

        public TreeNode(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }

        public void PrintNice()
        {
            PrintNiceInternal(this, "", true);
        }

        private static void PrintNiceInternal(TreeNode? node, string prefix, bool isLeft)
        {
            if (node == null)
                return;

            Console.WriteLine($"{prefix}{(isLeft ? "└── " : "├── ")}{node.Value}");

            string childPrefix = prefix + (isLeft ? "    " : "│   ");

            PrintNiceInternal(node.Right, childPrefix, false);
            PrintNiceInternal(node.Left, childPrefix, true);
        }

        public void Print(int indent = 0, char child = '0')
        {
            // Print me
            Console.WriteLine($"{new string(' ', indent * 2)}{child}:{Value}");
            if (Left != null)
            {
                Left.Print(indent + 1, 'L');
            }
            if (Right != null)
            {
                Right.Print(indent + 1, 'R');
            }
        }
        public override string ToString()
        {
            return $"Value: {Value}, Left: {Left?.Value}, Right: {Right?.Value}";
        }

        public void SetLevels(int i)
        {
            if (this == null)
                return;
            Level = i;
            Left?.SetLevels(i + 1);
            Right?.SetLevels(i + 1);
        }
    }
}
