using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowSharp.Core.Components
{
    public class AdderComponent : INetworkComponent
    {
        private List<int> _TermA;
        private List<int> _TermB;

        public AdderComponent()
        {
            // These need to be thread safe queues. meh on doing that right now.
            // me needs sum studying on how to do that.
            _TermA = new List<int>();
            _TermB = new List<int>();
        }

        public string Name { get; private set; }
        public object GetFromPort(string portName)
        {
            throw new System.NotImplementedException();
        }

        public void SendToPort(object value, string portName)
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, object> Ports
        {
            get; private set;
        }

        public AdderComponent(string name)
        {
            Name = name;
        }

        public void Dispose()
        {
            
        }
    }
}
