using System;
using System.Diagnostics;

namespace Multiplication
{

    public static class Multiplicator
    {        
        public static string GradeSchool(string multiplicand, string multiplier)
        {
            int[] product;
            int[] temp;

            int alen = 0;
            int blen = 0;
            int productlen = 0;

            alen = multiplicand.Length;
            blen = multiplier.Length;

            int[] a = new int[alen];
            int[] b = new int[blen];

            for (int i = 0; i < alen; i++)
                a[i] = int.Parse(new string(multiplicand[i], 1));
            for (int i = 0; i < blen; i++)
                b[i] = int.Parse(new string(multiplier[i], 1));

            productlen = alen + blen;
            product = new int[productlen];
            temp = new int[productlen];

            for (int i = blen - 1; i >= 0; i--)
            {
                int carry = 0;
                int tempcarry = 0;

                for (int k = 0; k < productlen; k++)
                    temp[k] = 0;

                for (int j = alen - 1; j >= 0; j--)
                {
                    //Debug.Print($"i: {i}, j: {j}, i+j: {i+j+1}");

                    temp[i + j + 1] = tempcarry + a[j] * b[i];
                    product[i + j + 1] += carry + a[j] * b[i];

                    tempcarry = temp[i + j + 1] / 10;
                    carry = product[i + j + 1] / 10;
                    
                    temp[i + j + 1] = temp[i + j + 1] % 10;
                    product[i + j + 1] = product[i + j + 1] % 10;
                }
                product[i] = carry;
                temp[i] = tempcarry;

                //Debug.Write($"Temp: ");
                //for (int k = 0; k < productlen; k++)
                //    Debug.Write($"{temp[k]}");
                //Debug.WriteLine("");

                //Debug.Write($"Product: ");
                //for (int k = 0; k < productlen; k++)
                //    Debug.Write($"{product[k]}");
                //Debug.WriteLine("");
            }


            return string.Join("", product);
        }
        
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Divide and Conquer, Sorting and Searching, and Randomized Algorithms");
            Console.WriteLine("Programming Assignment #1");

            Console.WriteLine("Grade School Multiplication implementation");

            string a = "3141592653589793238462643383279502884197169399375105820974944592";
            string b = "2718281828459045235360287471352662497757247093699959574966967627";

            Console.WriteLine($"Multiplying \n{a} with \n{b}...");

            Stopwatch sw = new Stopwatch();
            sw.Start();

            string product = Multiplicator.GradeSchool(a, b);

            sw.Stop();

            Console.Write($"product is {product}\n");
            Console.WriteLine($"Performance was {sw.ElapsedMilliseconds} ms");

        }
    }
}
