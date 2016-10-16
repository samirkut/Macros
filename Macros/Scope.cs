using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Macros.Expressions;
using Macros.Functions;

namespace Macros
{
    public class Scope
    {
        private IList<IFunctionEval> _builtInFunctions;
       
        public IDictionary<string, Expr> Variables { get; set; }

        public IList<IFunctionEval> Functions { get; set; }

        public Scope()
        {
            Variables = new Dictionary<string, Expr>(StringComparer.OrdinalIgnoreCase);
            Functions = new List<IFunctionEval>();

            //register the built in functions
            _builtInFunctions = new IFunctionEval[]
            {
                new OpAddFunctionEval(),
                new OpSubFunctionEval(),
                new OpMulFunctionEval(),
                new OpDivFunctionEval(),
                new OpPowFunctionEval(),
                new OpIndexerFunctionEval(),
                new OpGetPropertyFunctionEval()
            };

            //register some default variables
            Variables["__MACROS_START_TIME"] = new DateTimeExpr(DateTime.UtcNow);
            Variables["__MACROS_VERSION"] = new NumberExpr(0.1);
        }

        public IFunctionEval GetMatchingFunction(FunctionExpr expr)
        {
            //check in Functions, otherwise check in _builtInFunctions
            var fn = Functions.FirstOrDefault(x => string.Equals(x.Name, expr.Name, StringComparison.OrdinalIgnoreCase) && x.CanEval(expr.Arguments));
            if (fn != null) return fn;

            fn = _builtInFunctions.FirstOrDefault(x => string.Equals(x.Name, expr.Name, StringComparison.OrdinalIgnoreCase) && x.CanEval(expr.Arguments));
            return fn;
        }

        public void RegisterFunction(IFunctionEval func)
        {
            Functions.Add(func);
        }

        public void SetVariable<T>(string name, T value)
        {
            Variables[name] = Utils.ConvertToExpression(value, typeof(T));
        }
    }
}
