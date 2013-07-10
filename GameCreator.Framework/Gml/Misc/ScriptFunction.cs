﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Framework.Gml
{
    public class ScriptFunction : BaseFunction
    {
        CodeUnit cu;
        public ScriptFunction(string name, string code) : base(name, -1)
        {
            cu = new CodeUnit(code);
        }
        public void Compile()
        {
            cu.Compile();
        }
        public override Value Execute(params Value[] parameters)
        {
            ExecutionContext.Returned = new Value();
            ExecutionContext.Enter();
            ExecutionContext.SetArguments(parameters);
            cu.Run();
            ExecutionContext.Leave();
            return ExecutionContext.Returned;
        }
        public string Code
        {
            get
            {
                return cu.Code;
            }
        }
    }
}
