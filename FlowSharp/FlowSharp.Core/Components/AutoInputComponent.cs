using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowSharp.Core.Components
{
    public class AutoInputComponent : INetworkComponent
    {
        public AutoInputComponent(string name)
        {
            Name = name;
        }

        public string Name
        {
            get; private set;
        }

        private int _Counter;
        public object GetFromPort(string portName)
        {
            return _Counter++;
        }

        public void SendToPort(object value, string portName)
        {
            
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
