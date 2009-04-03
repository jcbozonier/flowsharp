using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowSharp.Core.Components
{
    public interface INetworkComponent : IDisposable
    {
        Dictionary<string, object> Ports { get; }
        string Name { get; }
        object GetFromPort(string portName);
        void SendToPort(object value, string portName);
    }
}
