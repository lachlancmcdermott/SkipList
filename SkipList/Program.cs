﻿using System;

namespace SkipList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SkipList<int> skipList = new SkipList<int>();

            skipList.Add(1);
            skipList.Add(3);
            skipList.Add(2);
        }
    }
}