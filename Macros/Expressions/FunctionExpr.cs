using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Macros.Expressions
{
    public class FunctionExpr : Expr
    {
        public string Name { get; set; }

        public Expr[] Arguments { get; set; }

        public FunctionExpr(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(Name)) return string.Empty;

            var argStr = Arguments == null ? string.Empty
                : Arguments.Select(x => x.ToString()).DefaultIfEmpty().Aggregate((x, y) => string.Format("{0}, {1}", x, y));
            return string.Format("{0}({1})", Name, argStr);
        }
    }
}
