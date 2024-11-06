namespace dsa.core
{
    public class TrieNode
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public TrieNode? Parent { get; set; }
        public List<TrieNode> Children { get; set; }

        public TrieNode(string name, string title = null)
        {
            Name = name;
            Title = title;
            Parent = null;
            Children = new List<TrieNode>();
        }

        public int FindHeightOf(string v)
        {
            Queue<TrieNode> queue = new Queue<TrieNode>();
            queue.Enqueue(this);
            int height = 0;
            while (queue.Count > 0)
            {
                Queue<TrieNode> childQueue = new Queue<TrieNode>();
                foreach (TrieNode t in queue)
                {
                    if (t.Name.Equals(v))
                    {
                        return height;
                    }
                    foreach (TrieNode ch in t.Children)
                    {
                        childQueue.Enqueue(ch);
                    }
                }
                queue = childQueue;
                height++;
            }
            return -1;
        }

        public void AddChildren(List<TrieNode> childs)
        {
            foreach (var child in childs)
            {
                child.Parent = this;
                Children.Add(child);
            }
        }

        public void Display()
        {
            TrieNode first = this;
            Queue<TrieNode> names = new Queue<TrieNode>();
            names.Enqueue(first);

            int level = 0;
            while (names.Count > 0)
            {
                int childAtThisLevel = names.Count;
                while (childAtThisLevel-- != 0)
                {
                    TrieNode current = names.Dequeue();
                    Console.WriteLine($"{new string(' ', level * 4)}L{level + 1}:{current.Name}");
                    current?.Children?.ForEach(c => names.Enqueue(c));
                }
                level++;
            }
        }

        public void DisplayNicer()
        {
            DisplayNicerInternal(this, "", true);
        }

        private void DisplayNicerInternal(TrieNode node, string prefix, bool isLast)
        {
            Console.WriteLine($"{prefix}{(isLast ? "└── " : "├── ")}{node.Name}{(string.IsNullOrEmpty(node.Title) ? "" : $" ({node.Title})")}");

            for (int i = 0; i < node.Children.Count; i++)
            {
                DisplayNicerInternal(node.Children[i], prefix + (isLast ? "    " : "│   "), i == node.Children.Count - 1);
            }
        }
    }
}
