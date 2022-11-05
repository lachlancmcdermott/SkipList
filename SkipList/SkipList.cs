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

        public void Add(T value)
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
            //nested if statements inside loop
            //go right as far as possible, add node stopped on to queue
            //go down, then go right again, when u stop add to queue
            //continue until u run out of nodes to go down


            Node<T> temp = Head;
            for (int i = 0; i < Head.Height; i++)
            {
                int tempHeight = Head.Height;
                for (int k = 0; k < Head.Height; k++)
                {
                    if (temp.Down != null && temp.Down.Right == null)
                    {
                        temp.Down.Right = node;
                        break;
                    }
                    int comp = node.Value.CompareTo(temp.Down.Right.Value);


                    while (comp < 1)
                    {
                        if (comp == 0)
                        {
                            node.Count++;
                        }
                        node.Right = temp.Down.Right;
                        temp.Down.Right = node;

                        temp = temp.Right;
                    }
                    temp = temp.Down;
                }
            }
        }

        public void Subtract(T value)
        {

        }

        public Node<T> Search(T value)
        {
            return null;
        }
    }
}
