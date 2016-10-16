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

        public Expr Evaluate(string expression)
        {
            return Evaluate(Parse(expression));
        }

        public Expr Evaluate(Expr expr)
        {
            if (expr == null)
                throw new ArgumentNullException("expr");

            if (expr is ErrorExpr)
                return expr;
            else if (expr is ConstantExpr)
                return expr;
            else if(expr is VariableExpr)
            {
                var name = (expr as VariableExpr).Name;
                if (!Scope.Variables.ContainsKey(name))
                    return new ErrorExpr("Unknown variable " + name);
                return Scope.Variables[name];                
            }
            else if (expr is FunctionExpr)
            {
                var fnExpr = expr as FunctionExpr;
                
                //first we evaluate all the arguments and then the fucntion itself
                var argResult = fnExpr.Arguments.Select(Evaluate).ToArray();
                if (argResult.OfType<ErrorExpr>().Any())
                    return new ErrorExpr("Unable to eval " + fnExpr.Name + " (" + argResult.OfType<ErrorExpr>().First().Message + ")");
                fnExpr.Arguments = argResult;

                var fnEval = Scope.GetMatchingFunction(fnExpr);
                if (fnEval == null)
                    return new ErrorExpr("Unknown function: " + fnExpr.Name);

                return fnEval.Eval(argResult);
            }
            else
                return new ErrorExpr("Unknown type of expression encountered: " + expr.GetType().Name);
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
