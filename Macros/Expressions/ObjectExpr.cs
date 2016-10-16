using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Macros.Expressions
{
    public class ObjectExpr : ConstantExpr
    {
        public object Value { get; set; }

        public ObjectExpr(object value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value == null ? string.Empty : Value.ToString();
        }
    }
}
