using Antlr4.Runtime;
using Macros.Expressions;
using Macros.Grammar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macros
{
    public class Runner
    {
        public Scope Scope { get; private set; }

        public Runner()
        {
            Scope = new Scope();
        }

        public Expr Evaluate(Expr expr)
        {
            if (expr == null)
                throw new ArgumentNullException("expr");

            throw new NotImplementedException();

            //first we iterate and set all variables. If some variable is not found we throw error

            //now we eval all functions. If some function is not found we throw an error

            //return the result
        }

        public Expr Parse(string expression)
        {
            var input = new AntlrInputStream(expression);
            var lexer = new ExprLexer(input);
            var tokens = new CommonTokenStream(lexer);
            var parser = new ExprParser(tokens);

            var visitor = new ExprVisitor();
            return visitor.Visit(parser.expr());
        }
    }
}
