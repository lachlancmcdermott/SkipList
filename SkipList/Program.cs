using System;

namespace SkipList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SkipList<int> skipList = new SkipList<int>();

            skipList.InsertNode(1);
        }
    }
}