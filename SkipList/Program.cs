using System;

namespace SkipList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SkipList<string> skipList = new SkipList<string>(new Random(1));


            skipList.Add("head");
            skipList.Add("shoulders");
            skipList.Add("knees");
            skipList.Add("toes");
            bool areMyToesStillAttached = skipList.Remove("hair");
            Node<String> search;
            search = skipList.Search("shoulders");
        }
    }
}