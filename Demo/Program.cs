using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Macros;

namespace TestParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var expression = GetExpression();
            var runner = new Runner();
            runner.Scope.SetVariable("x", 5);

            while (!string.IsNullOrEmpty(expression))
            {
                var result = runner.Parse(expression);

                Console.WriteLine(result.ToString());

                Console.WriteLine(runner.Evaluate(result).ToString());
                    
                expression = GetExpression();
            }
        }

        static string GetExpression()
        {
            Console.Write("Expr: ");
            return Console.ReadLine();
        }
    }
}