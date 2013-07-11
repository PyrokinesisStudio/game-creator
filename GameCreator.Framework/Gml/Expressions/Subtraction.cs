﻿using System;
namespace GameCreator.Framework.Gml
{
    class Subtraction : Expression
    {
        Expression expr1, expr2;
        public Subtraction(Expression e1, Expression e2, int l, int c) : base(l, c) { expr1 = e1; expr2 = e2; }
        public override Value Eval()
        {
            Value v1 = expr1.Eval(), v2 = expr2.Eval();
            if (!(v1.IsReal && v2.IsReal)) Error("Wrong type of arguments to -.");
            return new Value(v1.Real - v2.Real);
        }

        public override ExpressionKind Kind
        {
            get { return ExpressionKind.Subtraction; }
        }
    }
}