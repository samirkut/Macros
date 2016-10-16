using Macros.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Macros.Functions
{
    public class DelegateFunctionEval : IFunctionEval
    {
        private readonly Func<Expr[], Expr> _evalFunc;
        private readonly Tuple<string, bool>[] _argsDesc;

        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="argsDesc">list of tuples describing the arguments. Each tuple consists of a TypeName and a boolean flag which denotes whether the argument is optional</param>
        /// <param name="evalFunc"></param>
        public DelegateFunctionEval(string name, Tuple<string, bool>[] argsDesc, Func<Expr[], Expr> evalFunc)
        {
            Name = name;
            _argsDesc = argsDesc;
            _evalFunc = evalFunc;

            if (_argsDesc == null)
                _argsDesc = new Tuple<string, bool>[0];
        }

        public bool CanEval(Expr[] args)
        {
            if (args == null) args = new Expr[0];

            //both empty then true
            if (!args.Any() && !_argsDesc.Any())
                return true;

            //more args than this function can cope with 
            if (args.Length > _argsDesc.Length)
                return false;

            //iterate through all args and match types
            for (int i = 0; i < args.Length; i++)
                if (args[0].GetType().Name != _argsDesc[i].Item1)
                    return false;

            //if we have extra argsDesc, they need to be marked as optional
            for (int i = args.Length; i < _argsDesc.Length; i++)
                if (!_argsDesc[i].Item2)
                    return false;

            return true;
        }

        public Expr Eval(Expr[] args)
        {
            try
            {
                return _evalFunc(args);
            }
            catch (Exception ex)
            {
                return new ErrorExpr(ex.Message);
            }
        }
    }
}
