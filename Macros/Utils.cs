using Macros.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Macros
{
    internal class Utils
    {
        internal static ConstantExpr ConvertToExpression(object value, Type targetType)
        {
            if (targetType == typeof(double) || targetType == typeof(int) || targetType == typeof(long) || targetType == typeof(decimal))
                return new NumberExpr(Convert.ToDouble(value));
            else if (targetType == typeof(DateTime))
                return new DateTimeExpr(Convert.ToDateTime(value));
            else if (targetType == typeof(string))
                return new StringExpr(Convert.ToString(value));
            else
                return new ObjectExpr(value);
        }
    }
}
