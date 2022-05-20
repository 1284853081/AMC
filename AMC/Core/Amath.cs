using AMC.Core.DataStruct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMC.Core
{
    public static class Amath
    {
        public static long GCD(long left, long right)
        {
            if (left * right == 0) return 0;
            else if (left * right < 0) return -1;
            else
            {
                long max = Math.Max(left, right);
                long min = Math.Min(left, right);
                long remainder = max % min;
                while (remainder != 0)
                {
                    max = min;
                    min = remainder;
                    remainder = max % min;
                };
                return min;
            }
        }
        public static long LCM(long left, long right)
        {
            return left * right / GCD(left, right);
        }
        public static Fraction Max(Fraction left, Fraction right)
        {
            if (left < right) return right;
            else if (left > right) return left;
            else return left;
        }
        public static Fraction Min(Fraction left, Fraction right)
        {
            if (left < right) return left;
            else if (left > right) return right;
            else return left;
        }
        public static Fraction Reciprocal(long num)
        {
            if (num == 0) return new Fraction(long.MaxValue, 1);
            else return new Fraction(1, num);
        }
        public static Fraction Pow(Fraction fraction, int times)
        {
            if (fraction == 0) return 0;
            else
            {
                Fraction sum = 1;
                if (times == 0) return 1;
                else
                {
                    for (int i = 0; i < Math.Abs(times); i++)
                        sum *= fraction;
                    if (times > 0) return sum;
                    else return sum.Reciprocal();
                }
            }
        }
        public static long Factorial(long n)
        {
            long sum = 1;
            for (int i = 1; i <= n; i++)
                sum *= i;
            return sum;
        }
        /// <summary>
        /// 返回n!/t!的值
        /// </summary>
        public static long Factorial(long n, long t)
        {
            long sum = 1;
            if (t > n / 2)
                t = n - t;
            for (int i = 0; i < t; i++)
                sum *= (n - i);
            return sum;
        }
    }
}
