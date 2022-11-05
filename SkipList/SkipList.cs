using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SkipList
{
    public class SkipList<T> where T : IComparable<T>
    {
        public Node<T> Head = new Node<T>(default, 1, null, null);
        public int Count { get; private set; }

        public void Insert(T value)
        {
            int height = 0;
            Random rand = new Random();
            Node<T> node = null;
            Node<T> newHead = null;

            do
            {
                height++;
                node = new Node<T>(value, height, null, node);
            }
            while (rand.Next(2) != 0);

            if (Head.Height < height)
            {
                height = Head.Height + 1;
                Head = new Node<T>(default, height, default, Head);
            }

            for (int i = 0; i < Head.Height; i++)
            {
                if (node.Height == Head.Height) //figure out what node is largest/smallest and where to insert in the list
                {
                    Head.Right = node;
                }
                else
                {
                    int tempHeight = Head.Height;
                    Node<T> temp = Head;
                    for (int k = 0; k < Head.Height; k++)
                    {
                        if(temp.Down.Right.Value == null)
                        {
                            temp.Down.Right = node;
                            break;
                        }
                        int comp = node.Value.CompareTo(temp.Down.Right.Value);
                        if (comp < 1)
                        {
                            if(comp == 0)
                            {
                                node.Count++;
                            }
                            node.Right = temp.Down.Right;
                            temp.Down.Right = node;

                            temp = temp.Down;
                        }
                    }
                }
            }
        }
    }
}
