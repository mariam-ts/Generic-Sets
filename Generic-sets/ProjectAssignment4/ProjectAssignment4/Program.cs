using System;
using ProjectAssignment4.COMPE361;

namespace ProjectAssignment4
{
    class Program
    {
        static void Main(string[] args)
        {
            Set<int> set1 = new Set<int>();
            Console.WriteLine($"is set1 empty? {set1.IsEmpty}"); //outputs true
            foreach (var i in set1)
            {
                Console.Write($"{i} ");
            }

            int[] array1 = new int[] { 1, 3, 5, 7, 9, 1 };
            Set<int> set2 = new Set<int>(array1);
            
            Console.WriteLine($"is set2 empty?{set2.IsEmpty}"); //outputs false
            foreach(var i in set2)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();
            Console.WriteLine($"is 10 added to set1? {set1.Add(10)}");//outputs true 
            Console.WriteLine($"length of set1 {set1.Count}"); //outputs 1
            Console.WriteLine($"does set1 contains 10? {set1.Contains(10)}\n"); //outputs true

            Set<int> set3 = set1 + set2;  //check operator + overload
            Console.WriteLine($"does set3 contains 10? {set3.Contains(10)}");  //true
            Console.WriteLine($"does set3 contains 1? {set3.Contains(1)}");   //true
            Console.WriteLine($"does set3 contains 2? {set3.Contains(2)}");   //false
            Console.WriteLine($"does set3 contains 3? {set3.Contains(3)}");   //true
            Console.WriteLine($"does set3 contains 4? {set3.Contains(4)}");   //false
            Console.WriteLine($"does set3 contains 5? {set3.Contains(5)}");   //true

            Console.WriteLine($"does 10 removed from set3? {set3.Remove(10)}"); //true
            Console.WriteLine($"does set3 contains 10? {set3.Contains(10)}");  //true
            Console.WriteLine($"does 10 removed from set3? {set3.Remove(10)}"); //false
            Console.WriteLine($"does set3 contains 10? {set3.Contains(10)}");  //false

            // if passed value is greater 5 return true otherwise false 
            bool filter(int elt)
            {
                if(elt> 5)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            //filter set3, left only numbers greater then 5
            Set<int> set4 = set3.Filter(filter);
            Console.WriteLine($"\nlength of filtered set3 is {set4.Count}"); //output should be 2 (numbers: 7, 9)
            Console.WriteLine($"does filtered set3 contains 7? {set3.Contains(7)}");   //true
            Console.WriteLine($"does filtered set3 contains 9? {set3.Contains(9)}\n");   //true


            int[] array3 = new int[] { 100, 3, 500, 9, 7, 1 };
            var sortedset = new SortedSet<int>(array3);
            Console.WriteLine("sortedset contains: ");
            foreach(var i in sortedset)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine($"is 99 added to sortedset? {sortedset.Add(99)}");
            foreach (var i in sortedset)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
            Console.WriteLine($"is 99 removed from the sorted list? {sortedset.Remove(99)}"); //true
            Console.WriteLine($"is 199 removed from the sorted list? {sortedset.Remove(199)}"); //false
            foreach (var i in sortedset)
            {
                Console.WriteLine(i);
            }

            int[] array4 = new int[] { 1, 3, 89, 55, 26, 1 };
            int[] array5 = new int[] { 12, 17, 82, 61, 49, 1 };
            var sortedset1 = new SortedSet<int>(array4);
            var sortedset2 = new SortedSet<int>(array5);
            var sortedset3 = sortedset2 + sortedset1;
            Console.WriteLine($"sortedset3 = sortedset2+sortedset1, so sortedset3 contains: ");
            
            foreach(var i in sortedset3)
            {
                Console.WriteLine(i);
            }

        }
    }
}
