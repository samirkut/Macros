using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macros.Expressions
{
    public abstract class Expr { }

    public abstract class ConstantExpr : Expr { }

    public class NumberExpr : ConstantExpr
    {
        public double Value { get; set; }

        public NumberExpr(double value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }

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

    public class NullExpr : ConstantExpr
    {
        public override string ToString()
        {
            return "NULL";
        }
    }

    public class ErrorExpr :Expr
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
                : Arguments.Select(x=>x.ToString()).DefaultIfEmpty().Aggregate((x, y) => string.Format("{0}, {1}", x, y));
            return string.Format("{0}({1})", Name, argStr);
        }
    }

}
