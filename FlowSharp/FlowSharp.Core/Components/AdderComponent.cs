using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowSharp.Core.Components
{
    public class AdderComponent : INetworkComponent
    {
        public string Test;
        public Dictionary<string, object> Ports
        {
            get; private set;
        }
    }
}
