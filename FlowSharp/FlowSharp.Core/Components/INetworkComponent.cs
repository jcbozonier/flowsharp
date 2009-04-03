using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowSharp.Core.Components
{
    public interface INetworkComponent
    {
        Dictionary<string, object> Ports { get; }
    }
}
