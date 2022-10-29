using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkipList
{
    public class Node<T>
    {
        public T Value;
        public int Height;
        public Node<T> Right;
        public Node<T> Down;


        public Node(T value, int height, Node<T> right, Node<T> down)
        {
            Value = value;
            Height = height;
            Right = right;
            Down = down;
        }
    }
}
