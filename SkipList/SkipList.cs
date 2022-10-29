using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SkipList
{
    public class SkipList<T>
    {
        public Node<T> Head = new Node<T>(default, 1, null, null);
        public int Count { get; private set; }

        public void InsertNode(T value)
        {
            int height = 0;
            Random rand = new Random();
            Node<T> node = null;

            do
            {
                height++;
                node = new Node<T>(value, height, null, node);
            }
            while (rand.Next(2) != 0);

            ConnectNode(node, value, height);
        }

        public void ConnectNode(Node<T> node, T value, int height)
        {
            //if the height of the node matches, then bind it to other nodes that have the same height
            //use icomparable to create connections of the nodes that are of the same height, from left to right based on what value is larger
            //make Unit tests for skiplist, add icomparable to node and skiplist classes
            if (Head.Height < height)
            {
                if (Head.Right == null)
                {
                    Node<T> tNode = new Node<T>(value, Head.Height + 1, null, null);
                    Head.Right = tNode;
                    return;
                }
                Node<T> node = new Node<T>(value, Head.Height + 1, null, null);
                Node<T> newHead = new Node<T>(default, Head.Height + 1, node, Head);
            }
        }
        
        public void AddNConnect(int newHeight, T val)
        {

        }

    }
}
