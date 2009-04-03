using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace FlowSharp.Core.Components
{
    public class OutputterComponent : INetworkComponent
    {
        public OutputterComponent(string name)
        {
            Name = name;
        }

        public string Name
        {
            get; private set;
        }

        public object GetFromPort(string portName)
        {
            return null;
        }

        public void SendToPort(object value, string portName)
        {
            var typedValue = value as int?;
            if (typedValue == null) return;

            Debug.WriteLine(typedValue);
        }

        public Dictionary<string, object> Ports
        {
            get; private set;
        }

        public void Dispose()
        {
            
        }
    }
}
