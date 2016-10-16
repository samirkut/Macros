using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Macros.Expressions;

namespace Macros.Functions
{
    internal class OpGetPropertyFunctionEval : IFunctionEval
    {
        public string Name { get { return "."; } }

        public bool CanEval(Expr[] args)
        {
            //check that the args are an object and variable
            return args != null && args.Length == 2
                && args[0].GetType() == typeof(ObjectExpr)
                && args[1].GetType() == typeof(VariableExpr);
        }

        public Expr Eval(Expr[] args)
        {
            //check args are valid else we throw exception
            if (!CanEval(args)) return new ErrorExpr("Invalid args provided to " + Name);

            var obj = args[0] as ObjectExpr;
            var prop = (args[1] as VariableExpr).Name;

            if (obj.Value == null)
                return new ErrorExpr("Object is null");

            var objProps = obj.Value.GetType().GetProperties(BindingFlags.Public);

            if (string.IsNullOrWhiteSpace(prop) || !objProps.Any(x => x.Name == prop))
                return new ErrorExpr("Invalid property " + prop);

            var propInfo = objProps.First(x => x.Name == prop);
            var propVal = propInfo.GetValue(obj.Value, null);

            return Utils.ConvertToExpression(propVal, propInfo.PropertyType);
        }
    }
}
