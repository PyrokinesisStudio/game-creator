﻿using System;
using System.Collections.Generic;

namespace GameCreator.Framework
{
    public class IndexedResource
    {
        public int Index { get; set; }
        public string Name { get; set; }
        protected internal IndexedResource(string name) { Name = name;  }
    }
}
