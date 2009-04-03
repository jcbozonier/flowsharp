﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowSharp.Core.Components
{
    public class AutoInputComponent : INetworkComponent
    {
        public Dictionary<string, object> Ports
        {
            get; private set;
        }
    }
}