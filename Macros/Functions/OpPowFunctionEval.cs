using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Macros.Expressions;

namespace Macros.Functions
{
    internal class OpPowFunctionEval : IFunctionEval
    {
        public string Name { get { return "^"; } }

        public bool CanEval(Expr[] args)
        {
            //check that the args are only number and atleast 2
            return args != null && args.Length > 1
                && !args.Any(x => x.GetType() != typeof(NumberExpr));
        }

        public Expr Eval(Expr[] args)
        {
            //check args are valid else we throw exception
            if (!CanEval(args)) return new ErrorExpr("Invalid args provided to " + Name);

            return new NumberExpr(args.OfType<NumberExpr>().Select(x => x.Value).Aggregate((x, y) => Math.Pow(x, y)));
        }
    }
}
