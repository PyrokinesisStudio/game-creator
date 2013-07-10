﻿using System;
namespace GameCreator.Framework.Gml
{
    class Multiply : Expr
    {
        Expr expr1, expr2;
        public Multiply(Expr e1, Expr e2, int l, int c) : base(l, c) { expr1 = e1; expr2 = e2; }
        public override Value Eval()
        {
            Value v1 = expr1.Eval(), v2 = expr2.Eval();
            if (v1.IsReal && v2.IsReal)
                return new Value(v1.Real * v2.Real);
            else if (v1.IsReal && v2.IsString)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < (int)System.Math.Round(v1.Real); i++)
                    sb.Append(v2.String);
                return new Value(sb.ToString());
            }
            else
                return Error("Wrong type of arguments to *.");
        }
    }
}