﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace SkipList
{
    public class SkipList<T> where T : IComparable<T>
    {
        public Node<T> Head = new Node<T>(default, 1, null, null);
        public int Count { get; private set; }
        Random rand;

        public SkipList(Random rand)
        {
            this.rand = rand;
        }
        public SkipList()
            : this(new Random()) { }

        public void Add(T value)
        {
            int height = 0;
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

            Queue<Node<T>> queue = new Queue<Node<T>>();
            Node<T> curr = Head; 

            
            while(true)
            {
                while (curr.Right != null && curr.Right.Value.CompareTo(value) < 0)
                {
                    curr = curr.Right;
                }
                if (curr.Height <= node.Height)
                {
                    queue.Enqueue(curr);
                }
                if (curr.Down != null)
                {
                    curr = curr.Down;
                    if (curr.Right != null && curr.Right.Value.CompareTo(value) == 0)
                    {
                        curr.Right.Count++;
                        Node<T> t = curr.Down;
                        while(t != null)
                        {
                            t.Count++;
                            t = t.Down;
                        }
                        return;
                    }
                }
                else
                {
                    break;
                }
            }

            while (queue.Count > 0)
            {
                Node<T> temp = queue.Dequeue();
                node.Right = temp.Right;
                temp.Right = node;
            }

            //attach members from queue to new node, starting with bottom
        }
    }
}
