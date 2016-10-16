using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Macros.Expressions;

namespace Macros.Functions
{
    internal class OpSubFunctionEval : IFunctionEval
    {
        public string Name { get { return "-"; } }

        public bool CanEval(Expr[] args)
        {
            //check that the args are only number and atleast 1
            return args != null && args.Any()
                && !args.Any(x => x.GetType() != typeof(NumberExpr));
        }

        public Expr Eval(Expr[] args)
        {
            //check args are valid else we throw exception
            if (!CanEval(args)) return new ErrorExpr("Invalid args provided to " + Name);

            return new NumberExpr(args.OfType<NumberExpr>().Select(x => x.Value).Aggregate((x, y) => x - y));
        }
    }
}
