using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Macros.Expressions;

namespace Macros.Functions
{
    internal class OpIndexerFunctionEval : IFunctionEval
    {
        public string Name { get { return "[]"; } }

        public bool CanEval(Expr[] args)
        {
            //check that the args are an array and number
            return args != null && args.Length == 2
                && args[0].GetType() == typeof(ArrayExpr)
                && args[1].GetType() == typeof(NumberExpr);
        }

        public Expr Eval(Expr[] args)
        {
            //check args are valid else we throw exception
            if (!CanEval(args)) return new ErrorExpr("Invalid args provided to " + Name);

            //we assume the indexing starts at 1
            var arr = args[0] as ArrayExpr;
            var idx = Convert.ToInt32((args[1] as NumberExpr).Value);

            if (arr.Values == null)
                return new ErrorExpr("Array is empty");

            if (idx < 1)
                return new ErrorExpr("Index begins at 1");

            if (idx > arr.Values.Length)
                return new ErrorExpr("Index out of range");

            return arr.Values[idx - 1];
        }
    }
}
