using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Macros.Expressions;

namespace Macros
{
    public interface IFunctionEval
    {
        string Name { get; }
        bool CanEval(Expr[] args);
        Expr Eval(Expr[] args);
    }
}
