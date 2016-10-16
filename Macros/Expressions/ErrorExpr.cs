using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Macros.Expressions
{
    public class ErrorExpr : Expr
    {
        public string Message { get; set; }

        public ErrorExpr(string message)
        {
            Message = message;
        }

        public override string ToString()
        {
            return string.Format("Error:{0}", string.IsNullOrWhiteSpace(Message) ? "Unknown" : Message);
        }
    }
}
