using System;
using System.Collections.Generic;
using System.Text;

namespace search
{
    public class BinarySearch
    {
        int[] arr;
        public BinarySearch(int[] a)
        {
            arr = a;
        }
        public bool Search(int x)
        {
            return SearchIterative(x, 0, arr.Length-1);
        }

        public bool SearchRecursive(int x, int min, int max)
        {
            if(min>=max)
            {
                return false;
            }

            int midIndex = (min + max) / 2;
            int mid = arr[midIndex];
            if (mid == x)
            {
                return true;
            }
            else if (mid > x)
            {
                return SearchRecursive(x, min, midIndex);
            }
            else
            {
                return SearchRecursive(x, midIndex+1, max);   //NOTE: the midIndex for the top part is incremented by 1
            }
        }

        public bool SearchIterative(int x, int left, int right)
        {
            while(left<=right)
            {
                var mid = left + (right-left) / 2;
                if (mid == x) { return true;}
                if(mid<x)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
             
            }
            return false;
        }
    }
}
