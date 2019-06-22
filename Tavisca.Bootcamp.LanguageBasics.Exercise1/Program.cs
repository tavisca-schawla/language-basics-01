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
            int result = -1, defected, defectedIndex;
            defected = defectedIndex = default(int);
            string[] components = equation.Split(new[] { '*', '=' }, StringSplitOptions.RemoveEmptyEntries);
            //storing equation components in separate variables for readibility.
            string A = components[0];
            string B = components[1];
            string C = components[2];

            //Determining the defected component index and missing digit index
            foreach (var comp in components)
            {
                if (comp.IndexOf('?') > -1)
                {
                    defectedIndex = comp.IndexOf('?');
                    defected = Array.IndexOf(components, comp);
                    break;
                }
            }

            //Determining expected value of the defected.
            int b = (defected != 1) ? int.Parse(B) : int.Parse(A);
            int c = (defected != 2) ? int.Parse(C) : int.Parse(A);
            decimal product = (defected == 2) ? b * c : (decimal)c / (decimal)b;

            for (int i = 1; i < 10; i++)
            {
                var str = new StringBuilder(components[defected]);
                str.Remove(defectedIndex, 1);
                str.Insert(defectedIndex, i);
                var tem1 = int.Parse(str.ToString());
                if (tem1 == product)
                {
                    result = i;
                }
            }

            return result;
        }
    }
}