using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Macros.Expressions;

namespace Macros.Functions
{
    internal class OpAddFunctionEval : IFunctionEval
    {
        public string Name { get { return "+"; } }

        public bool CanEval(Expr[] args)
        {
            //as long as args of same type we can eval.
            //also check that the args are only string/number/array
            return args != null && args.Any()
                && args.Select(x => x.GetType().Name).Distinct().Count() == 1
                && !args.Any(x => x.GetType() != typeof(StringExpr)
                                    && x.GetType() != typeof(NumberExpr)
                                    && x.GetType() != typeof(ArrayExpr));
        }

        public Expr Eval(Expr[] args)
        {
            //check args are valid else we throw exception
            if (!CanEval(args)) return new ErrorExpr("Invalid args provided to " + Name);

            if (args.Any(x => x.GetType() == typeof(StringExpr)))
            {
                return new StringExpr(args.OfType<StringExpr>().Select(x => x.Value).Aggregate((x, y) => x + y));
            }
            else if (args.Any(x => x.GetType() == typeof(NumberExpr)))
            {
                return new NumberExpr(args.OfType<NumberExpr>().Select(x => x.Value).Aggregate((x, y) => x + y));
            }
            else if (args.Any(x => x.GetType() == typeof(ArrayExpr)))
            {
                return new ArrayExpr(args.OfType<ArrayExpr>().Select(x => x.Values).Aggregate((x, y) =>
                {
                    var ret = x.ToList();
                    ret.AddRange(y);
                    return ret.ToArray();
                }));
            }

            return new ErrorExpr("Unsupported args provided to " + Name);
        }
    }

}
