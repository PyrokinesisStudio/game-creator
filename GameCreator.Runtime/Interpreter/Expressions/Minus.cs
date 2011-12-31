﻿using System;
namespace GameCreator.Runtime.Interpreter
{
    class Minus : Expr
    {
        Expr expr;
        public Minus(Expr e, int line, int col) : base(line, col) { expr = e; }
        public override Value Eval()
        {
            Value v = expr.Eval();
            if (!v.IsReal) Error("Wrong type of arguments to unary operator.");
            return new Value(-v.Real);
        }
    }
}