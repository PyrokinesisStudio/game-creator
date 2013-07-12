﻿using System;
namespace GameCreator.Framework.Gml
{
    public class Minus : UnaryExpression
    {
        public Minus(Expression operand, int line, int col)
            : base(operand, line, col) { }

        public override ExpressionKind Kind
        {
            get { return ExpressionKind.Minus; }
        }
        public override Expression Reduce()
        {
            return Fold(Operand, v => -v);
        }
    }
}