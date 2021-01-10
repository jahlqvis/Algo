using System;
using System.Diagnostics;
using System.Numerics;

namespace Multiplication
{

    public static class multiplicator
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
                for (int j = alen - 1; j >= 0; j--)
                {
                    Debug.Print($"i: {i}, j: {j}, i+j {i + j + 1}, i - blen - 1 {i - blen - 1}");

                    temp[i + j + 1] = tempcarry + a[j] * b[i];
                    product[i + j + 1] += carry + a[j] * b[i];

                    tempcarry = temp[i + j + 1] / 10;
                    carry = product[i + j + 1] / 10;

                    temp[i + j + 1] = temp[i + j + 1] % 10;
                    product[i + j + 1] = product[i + j + 1] % 10;
                }
                product[(i - blen - 1) + alen] = carry;
                temp[(i - blen - 1) + alen] = tempcarry;

                Debug.Write($"Temp: ");
                for (int k = 0; k < productlen; k++)
                    Debug.Write($"{temp[k]}");
                Debug.WriteLine("");

                Debug.Write($"Product: ");
                for (int k = 0; k < productlen; k++)
                    Debug.Write($"{product[k]}");
                Debug.WriteLine("");
            }

            return product.ToString();
        }

    }

}
