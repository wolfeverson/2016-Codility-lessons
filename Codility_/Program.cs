using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility_
{
    static class Program
    {
        static void Main(string[] args)
        {
            int result = TimeComplexity_TapeEquilibrium(new int[] { 3,1,2,4,3 });


        }

        static public int Iterations_BinaryGap(int N)
        {
            /*
            A binary gap within a positive integer N is any maximal sequence of consecutive zeros that is surrounded by ones at both ends in the binary representation of N
            For example, number 9 has binary representation 1001 and contains a binary gap of length 2.The number 529 has binary representation 1000010001 and contains two binary gaps: one of length 4 and one of length 3.The number 20 has binary representation 10100 and contains one binary gap of length 1.The number 15 has binary representation 1111 and has no binary gaps.
            that, given a positive integer N, returns the length of its longest binary gap.The function should return 0 if N doesn't contain a binary gap.
            For example, given N = 1041 the function should return 5, because N has binary representation 10000010001 and so its longest binary gap is of length 5.


            Assume that:
                N is an integer within the range[1..2, 147, 483, 647].
            Complexity:
                expected worst-case time complexity is O(log(N));
                expected worst-case space complexity is O(1).*/


            string binary = Convert.ToString(N, 2);
            bool started = false;
            int counter = 0, max = 0;

            foreach (char c in binary)
            {
                if (c.ToString() == "1")
                {
                    if (!started)
                    {
                        started = true;
                    }
                    else
                    {
                        max = counter > max ? counter : max;
                    }
                    counter = 0;
                }
                else
                {
                    counter++;
                }
            }
            return max;
        }

        static public int[] Arrays_CyclicRotation(int[] A, int K)
        {
            /*A zero-indexed array A consisting of N integers is given.Rotation of the array means that each element is shifted right by one index, and the last element of the array is also moved to the first place.

            that, given a zero-indexed array A consisting of N integers and an integer K, returns the array A rotated K times.

            For example, given array A = [3, 8, 9, 7, 6] and K = 3, the function should return [9, 7, 6, 3, 8].

            Assume that:
                N and K are integers within the range[0..100];
                each element of array A is an integer within the range[−1, 000..1, 000].
            In your solution, focus on correctness.The performance of your solution will not be the focus of the assessment.
            */

            int length = A.Length;
            int[] newArray = new int[length];
            for (int i=0; i< length;i++)
            {
                int newPos = i + K;
                while (newPos >= length) newPos -= length;
                newArray[newPos] = A[i];
            }
            return newArray;
        }

        static public int Arrays_OddOccurrencesInArray(int[] A)
        {
            /*A non-empty zero-indexed array A consisting of N integers is given. The array contains an odd number of elements, and each element of the array can be paired with another element that has the same value, except for one element that is left unpaired.

            that, given an array A consisting of N integers fulfilling the above conditions, returns the value of the unpaired element.

            For example, given array A such that:

              A[0] = 9  A[1] = 3  A[2] = 9
              A[3] = 3  A[4] = 9  A[5] = 7
              A[6] = 9
            the function should return 7, as explained in the example above.

            Assume that:
                N is an odd integer within the range [1..1,000,000];
                each element of array A is an integer within the range [1..1,000,000,000];
                all but one of the values in A occur an even number of times.
            Complexity:
                expected worst-case time complexity is O(N);
                expected worst-case space complexity is O(1), beyond input storage (not counting the storage required for input arguments).
            Elements of input arrays can be modified.*/



            
            Array.Sort(A);  //TODO optimize sort?  bubble?
            int counter = 0;
            int curr = 0;

            for (int i = 0; i < A.Length;i++)
            {
                if (i == A.Length - 1) return A[i]; //if we get to end - must be correct answer.

                if (A[i] == curr)
                {
                    counter++;
                }
                else
                {
                    if ((counter % 2) != 0) //if count is not even
                    {
                        return curr; 
                    }
                    curr = A[i];
                    counter = 1;
                }
            }

            return 0;
        }

        static public int TimeComplexity_TapeEquilibrium(int[] A)
        {
            /*A non-empty zero - indexed array A consisting of N integers is given.Array A represents numbers on a tape.
            Any integer P, such that 0 < P < N, splits this tape into two non-empty parts: A[0], A[1], ..., A[P − 1] and A[P], A[P + 1], ..., A[N − 1].
            The difference between the two parts is the value of: | (A[0] + A[1] + ... + A[P − 1]) − (A[P] + A[P + 1] + ... + A[N − 1]) |
            In other words, it is the absolute difference between the sum of the first part and the sum of the second part.
            For example, consider array A such that:

              A[0] = 3
              A[1] = 1
              A[2] = 2
              A[3] = 4
              A[4] = 3
            We can split this tape in four places:

            P = 1, difference = | 3 − 10 | = 7
            P = 2, difference = | 4 − 9 | = 5
            P = 3, difference = | 6 − 7 | = 1
            P = 4, difference = | 10 − 3 | = 7

            Write a function that, given a non-empty zero-indexed array A of N integers, returns the minimal difference that can be achieved.

            Assume that:
                    N is an integer within the range[2..100, 000];
                    each element of array A is an integer within the range[−1, 000..1, 000].
            Complexity:
                    expected worst-case time complexity is O(N);
                    expected worst-case space complexity is O(N), beyond input storage(not counting the storage required for input arguments).
            Elements of input arrays can be modified. */


            /*
             * This is a naive solution. It is 100% accurate, but slow.  
             * 
             * 
             * 
            int arrLength = A.Length;
            int maxSplit = arrLength - 1;
            int minValue = int.MaxValue;
            for (int i =1;i<=maxSplit;i++)
            {
                int mid = A.Length - i;

                //List<int> arr1 = A.Take(i).ToList();
                //List<int> arr2 = A.Skip(i).Take(mid).ToList();
                int[] arr1 = new int[i];
                int[] arr2 = new int[mid];
                Array.Copy(A, 0, arr1, 0, i);
                Array.Copy(A, i , arr2, 0, mid);

                int calc = Math.Abs(arr1.Sum() - arr2.Sum());
                minValue = minValue > calc ? calc : minValue;
            }

            return minValue;*/

            /*
             * 
             * This solution passes performance tests - but is not 100% accurate.  
             * 
            int LowIndex = 0, HighIndex = A.Length-1, LowCount = 0, HighCount = 0;

            for (int i= 0; i < A.Length;i++)
            {
                int newLow = LowCount + A[LowIndex];
                int newHigh = HighCount + A[HighIndex];

                if (Math.Abs(newHigh) < Math.Abs(newLow))
                {
                    //increment high
                    HighIndex--;
                    HighCount = newHigh;
                }
                else
                {
                    //increment low
                    LowIndex++;
                    LowCount = newLow;
                }
            }

            return Math.Abs(HighCount - LowCount);
            */

            List<int> results = new List<int>();
            int Left = 0;
            int Sum = A.Sum();
            foreach (int item in A)
            {
                Left += item;
                results.Add(Math.Abs((Sum - Left) - Left));
            }
            return results.Min();

        }
    }
}
