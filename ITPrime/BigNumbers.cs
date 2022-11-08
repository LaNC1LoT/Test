using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPrime
{
    internal class BigNumbers
    {
        public static long[] Sum(long[] number1, long[] number2) 
        { 
            var maxLength = number1.Length > number2.Length ? number1.Length : number2.Length;
            var result = new long[maxLength + 1];
            long rest = 0;

            for (int i1 = number1.Length - 1, i2 = number2.Length - 1, r = maxLength; i1 >= 0 || i2 >= 0; i1--, i2--, r--)
            {
                var temp = (i1 < 0 ? 0 : number1[i1]) + (i2 < 0 ? 0 : number2[i2]) + rest;
                result[r] = temp % 10;
                rest = temp / 10;
            }

            result[0] = rest;

            while (result[0] == 0) 
            {
                result = result.Skip(1).ToArray();
            }

            return result;
        }

        public static long[] Sum(List<long[]> collection) 
        {
            var result = new long[] { 0 };

            collection.ForEach(i => 
            {
                result = Sum(result, i);    
            });

            return result;
        }

        public static string ToString(long[] number) 
        {
            var result = "";
            number.ToList().ForEach(i => result += i.ToString());

            return result;
        }
    }
}
