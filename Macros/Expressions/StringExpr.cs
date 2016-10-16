using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Macros.Expressions
{
    public class StringExpr : ConstantExpr
    {
        public string Value { get; set; }

        public StringExpr(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value == null ? string.Empty : Value.ToString();
        }
    }
}
