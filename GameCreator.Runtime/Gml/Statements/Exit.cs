﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    class Exit : Stmt
    {
        public Exit(int l, int c) : base(l, c) { }
        protected override void run()
        {
            ProgramFlow = FlowType.Exit;
        }
        public override string ToString()
        {
            return "exit";
        }
    }
}
