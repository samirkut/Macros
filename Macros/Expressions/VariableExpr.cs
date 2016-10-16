using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Macros.Expressions
{
    public class VariableExpr : Expr
    {
        public string Name { get; set; }

        public VariableExpr(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
