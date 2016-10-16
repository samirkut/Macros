using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Macros.Expressions
{
    public class DateTimeExpr : ConstantExpr
    {
        public DateTime Value { get; set; }

        public DateTimeExpr(DateTime value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
