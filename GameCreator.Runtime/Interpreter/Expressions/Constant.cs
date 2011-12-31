﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Runtime.Interpreter
{
    class Constant : Expr
    {
        Value v;
        public Constant(string s, int line, int col) : base(line, col) { v = new Value(s); }
        public Constant(double d, int line, int col) : base(line, col) { v = new Value(d); }
        public override Value Eval()
        {
            return v;
        }
        public override string ToString()
        {
            return v.ToString();
        }
    }
}
