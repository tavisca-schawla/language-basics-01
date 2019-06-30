using System;
using System.Text;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class FixMultiplication
    {
        static int Defected, DefectedIndex;
        static string[] EquationComponents;
        static string OperandA;
        static string OperandB;
        static string ProductC;
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

        public static void ExtractEquationComponents(string equation)
        {
            EquationComponents = equation.Split(new[] { '*', '=' }, StringSplitOptions.RemoveEmptyEntries);
            OperandA = EquationComponents[0];
            OperandB = EquationComponents[1];
            ProductC = EquationComponents[2];
        }

        public static void GetDefectedValue()
        {
            foreach (var comp in EquationComponents)
            {
                if (comp.IndexOf('?') > -1)
                {
                    SetDefectedIndex(comp);
                    Defected = Array.IndexOf(EquationComponents, comp);
                    break;
                }
            }
        }

        public static void SetDefectedIndex(string defectedValue)
        {
            DefectedIndex = defectedValue.IndexOf('?');
        }
        public static int FindDigit(string equation)
        {
            ExtractEquationComponents(equation);
            GetDefectedValue();
            return DetermineMissingDigit();
        }
        public static int DetermineMissingDigit()
        {
            int b = (Defected != 1) ? int.Parse(OperandB) : int.Parse(OperandA);
            int c = (Defected != 2) ? int.Parse(ProductC) : int.Parse(OperandA);

            try
            {
                decimal product = (Defected == 2) ? b * c : (decimal)c / (decimal)b;
                if (EquationComponents[Defected].Length != product.ToString().Length)
                {
                    return -1;
                }

                return (int)char.GetNumericValue(product.ToString()[DefectedIndex]);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("{0}", ex);
                return -1;
            }
        }
    }
}