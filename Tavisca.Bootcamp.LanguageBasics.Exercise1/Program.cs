using System;
using System.Text;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class FixMultiplication
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            int result = -1, defected = 2, defectedIndex = -1;
            string A, B, C;
            A = B = C = string.Empty;

            for (int i = 0; i < equation.Length; i++)
            {
                if (equation[i] == '*')
                {
                    if (C.IndexOf('?') > -1)
                    {
                        defectedIndex = C.IndexOf('?');
                        defected = 0;
                    }

                    A = C;
                    C = string.Empty;
                }
                else if (equation[i] == '=')
                {
                    if (C.IndexOf('?') > -1)
                    {
                        defectedIndex = C.IndexOf('?');
                        defected = 1;
                    }

                    B = C;
                    C = string.Empty;
                }
                else
                {
                    C += equation[i];
                }
            }

            if (defectedIndex == -1)
            {
                defectedIndex = C.IndexOf('?');
            }

            if (defected == 0)
            {
                int b = int.Parse(B);
                int c = int.Parse(C);
                int product = c / b;

                for (int i = 1; i < 10; i++)
                {
                    var str = new StringBuilder(A);
                    str.Remove(defectedIndex, 1);
                    str.Insert(defectedIndex, i);
                    A = str.ToString();
                    var tem1 = int.Parse(A);

                    if (tem1 == product)
                    {
                        result = i;
                    }
                }
            }

            if (defected == 1)
            {
                int a = int.Parse(A);
                int c = int.Parse(C);
                decimal product = (decimal)c / (decimal)a;

                for (int i = 1; i < 10; i++)
                {
                    var str = new StringBuilder(B);
                    str.Remove(defectedIndex, 1);
                    str.Insert(defectedIndex, i);
                    B = str.ToString();
                    var tem1 = decimal.Parse(B);

                    if (tem1 == product)
                    {
                        result = i;
                    }
                }
            }

            if (defected == 2)
            {
                int b = int.Parse(B);
                int a = int.Parse(A);
                int product = a * b;

                for (int i = 1; i < 10; i++)
                {
                    var str = new StringBuilder(C);
                    str.Remove(defectedIndex, 1);
                    str.Insert(defectedIndex, i);
                    C = str.ToString();
                    var tem1 = int.Parse(C);

                    if (tem1 == product)
                    {
                        result = i;
                    }
                }
            }

            return result;
        }
    }
}