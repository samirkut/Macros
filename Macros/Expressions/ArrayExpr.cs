using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Macros.Expressions
{
    public class ArrayExpr : ConstantExpr
    {
        public ConstantExpr[] Values { get; set; }

        public ArrayExpr(ConstantExpr[] values)
        {
            Values = values;
        }

        public override string ToString()
        {
            return Values == null ? string.Empty : Values.Select(x => x.ToString()).DefaultIfEmpty().Aggregate((x, y) => string.Format("{0};{1}", x, y));
        }
    }
}
