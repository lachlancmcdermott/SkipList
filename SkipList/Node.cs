using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkipList
{
    public class Node<T> where T : IComparable<T>
    {
        public T Value;
        public int Height;
        public Node<T> Right;
        public Node<T> Down;
        public int Count = 1;


        public Node(T value, int height, Node<T> right, Node<T> down)
        {
            Value = value;
            Height = height;
            Right = right;
            Down = down;
        }
    }
}
