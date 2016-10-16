using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;
using Macros.Expressions;

namespace Macros.Grammar
{
    public class ExprVisitor : ExprBaseVisitor<Expr>
    {
        public override Expr VisitProperty([NotNull] ExprParser.PropertyContext context)
        {
            return new FunctionExpr(".")
            {
                Arguments = new[]
                {
                    Visit(context.expr()),
                    new VariableExpr(context.VARIABLE().GetText())
                }
            };
        }

        public override Expr VisitIndexer([NotNull] ExprParser.IndexerContext context)
        {
            return new FunctionExpr("[]")
            {
                Arguments = context.expr().Select(Visit).ToArray()
            };
        }

        public override Expr VisitFunction([NotNull] ExprParser.FunctionContext context)
        {
            //function name has an extra (. Need to remove it
            return new FunctionExpr(context.FUNCTION().GetText().TrimEnd("(".ToCharArray()))
            {
                Arguments = context.expr().Select(Visit).ToArray()
            };
        }

        public override Expr VisitMulDiv([NotNull] ExprParser.MulDivContext context)
        {
            return new FunctionExpr(context.op.Type == ExprParser.MUL ? "*" : "/")
            {
                Arguments = context.expr().Select(Visit).ToArray()
            };
        }

        public override Expr VisitAddSub([NotNull] ExprParser.AddSubContext context)
        {
            return new FunctionExpr(context.op.Type == ExprParser.PLUS ? "+" : "-")
            {
                Arguments = context.expr().Select(Visit).ToArray()
            };
        }

        public override Expr VisitUnaryAddSub([NotNull] ExprParser.UnaryAddSubContext context)
        {
            return new FunctionExpr(context.op.Type == ExprParser.PLUS ? "+" : "-")
            {
                Arguments = new[] { Visit(context.expr()) }
            };
        }

        public override Expr VisitPower([NotNull] ExprParser.PowerContext context)
        {
            return new FunctionExpr("^")
            {
                Arguments = context.expr().Select(Visit).ToArray()
            };
        }

        public override Expr VisitVariable([NotNull] ExprParser.VariableContext context)
        {
            return new VariableExpr(context.VARIABLE().GetText());
        }

        public override Expr VisitNumber([NotNull] ExprParser.NumberContext context)
        {
            return new NumberExpr(double.Parse(context.NUMBER().GetText()));
        }

        public override Expr VisitString([NotNull] ExprParser.StringContext context)
        {
            return new StringExpr(context.STRING().GetText());
        }

        public override Expr VisitParens([NotNull] ExprParser.ParensContext context)
        {
            return Visit(context.expr());
        }
    }
}
