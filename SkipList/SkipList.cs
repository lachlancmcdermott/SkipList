using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace SkipList
{
    public class SkipList<Toe> where Toe : IComparable<Toe>
    {
        public Node<Toe> Head = new Node<Toe>(default, 1, null, null);
        public int Count { get; private set; }
        Random rand;

        public SkipList(Random rand)
        {
            this.rand = rand;
        }
        public SkipList()
            : this(new Random()) { }

        public void Add(Toe value)
        {
            int height = 0;
            Node<Toe> node = null;
            Node<Toe> newHead = null;

            do
            {
                height++;
                node = new Node<Toe>(value, height, null, node);
                if (Head.Height < height)
                {
                    Head = new Node<Toe>(default, height, default, Head);
                    break;
                }
            }
            while (rand.Next(2) != 0);

            Queue<Node<Toe>> queue = new Queue<Node<Toe>>();
            Node<Toe> curr = Head;

            while (true)
            {
                while (curr.Right != null && curr.Right.Value.CompareTo(value) < 0)
                {
                    curr = curr.Right;
                }
                if (curr.Height <= node.Height)
                {
                    queue.Enqueue(curr);
                }
                if (curr.Right != null && curr.Right.Value.CompareTo(value) == 0)
                {
                    curr.Right.Count++;
                    Node<Toe> t = curr.Down;
                    while (t != null)
                    {
                        t.Count++;
                        t = t.Down;
                    }
                    return;
                }
                if (curr.Down != null)
                {
                    curr = curr.Down;
                }
                else
                {
                    break;
                }
            }

            while (queue.Count > 0)
            {
                Node<Toe> temp = queue.Dequeue();
                node.Right = temp.Right;
                temp.Right = node;
                node = node.Down;
            }
        }

        public bool Remove(Toe searchVal)
        {
            Queue<Node<Toe>> queue = new Queue<Node<Toe>>();
            Node<Toe> curr = Head;

            while (curr != null)
            {
                while (curr.Right != null && curr.Right.Value.CompareTo(searchVal) < 0)
                {
                    curr = curr.Right;
                }
                if (curr.Right != null && curr.Right.Value.CompareTo(searchVal) == 0)
                {
                    queue.Enqueue(curr);

                    if (curr.Right.Count > 1)
                    {
                        
                        Node<Toe> t = curr;
                        while (t != null)
                        {
                            t.Count++;
                            t = t.Down;
                        }
                        return true;
                    }
                }
                curr = curr.Down;
            }

            while (queue.Count > 0)
            {
                Node<Toe> temp = queue.Dequeue();
                temp.Right = temp.Right.Right;
            }
            return queue.Count != 0;
        }

        public Node<Toe> Search(Toe searchVal)
        {
            Queue<Node<Toe>> queue = new Queue<Node<Toe>>();
            Node<Toe> curr = Head;

            while (curr != null)
            {
                while (curr.Right != null && curr.Right.Value.CompareTo(searchVal) < 0)
                {
                    curr = curr.Right;
                }
                if (curr.Right != null && curr.Right.Value.CompareTo(searchVal) == 0)
                {
                    return curr.Right;
                }
                curr = curr.Down;
            }

            return null;
        }
    }
}
