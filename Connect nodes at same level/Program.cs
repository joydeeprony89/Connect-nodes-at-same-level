using System;

namespace Connect_nodes_at_same_level
{
    class Program
    {
        // Definition for a Node.
        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node next;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, Node _left, Node _right, Node _next)
            {
                val = _val;
                left = _left;
                right = _right;
                next = _next;
            }
        }
        static void Main(string[] args)
        {
            Node root = new Node(1);
            root.left = new Node(2);
            root.right = new Node(3);
            root.left.left = new Node(4);
            root.left.right = new Node(5);
            root.right.left = new Node(6);
            root.right.right = new Node(7);
            Connect(root);
        }

        static Node Connect(Node root)
        {
            if (root == null) return root;
            Node prev = root;
            Node cur = null;
            while (prev != null && prev.left != null)
            {
                cur = prev;
                while (cur != null)
                {
                    cur.left.next = cur.right;
                    if (cur.next != null) cur.right.next = cur.next.left;
                    cur = cur.next;
                }
                prev = prev.left;
            }
            return root;
        }
    }
}
