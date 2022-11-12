using System;

namespace SkipList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SkipList<string> skipList = new SkipList<string>(new Random(1));

            skipList.Add("shoulders");
            skipList.Add("Knees");
            skipList.Add("&");
            skipList.Add("toes");
            skipList.Add("Knees");
        }
    }
}