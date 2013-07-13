﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    public class CallStatement : Statement
    {
        public Call Call { get; set; }

        public CallStatement(BaseFunction func, Expression[] expressions, int l, int c)
            : base(l, c)
        {
            this.Call = new Call(func, expressions, l, c);
        }

        public override StatementKind Kind
        {
            get { return StatementKind.Call; }
        }

        public override void Optimize()
        {
            Call = (Call)Call.Reduce();
        }

        internal override void Write(System.CodeDom.Compiler.IndentedTextWriter writer, GmlFormatter formatter)
        {
            Call.Write(writer, formatter);
            writer.WriteLine(";");
        }
    }
}
