using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowSharp.Core.Components
{
    public class AdderComponent : INetworkComponent
    {
        private readonly Queue<int> _TermA = new Queue<int>();
        private readonly Queue<int> _TermB = new Queue<int>();

        public AdderComponent()
        {
        }

        public string Name { get; private set; }
        public object GetFromPort(string portName)
        {
            if(_TermA == null || _TermB == null) return null;

            switch (portName)
            {
                case "OUT":
                    lock (_TermA)
                    lock(_TermB)
                    {
                        var termA = _TermA.Count > 0 ? _TermA.Dequeue() : 0;
                        var termB = _TermB.Count > 0 ? _TermB.Dequeue() : 0;
                        return termA + termB;
                    }
                default:
                    throw new ArgumentException(portName + " does not exist on this component.");
            }
        }

        public void SendToPort(object value, string portName)
        {
            var typedValue = value as int?;
            if(typedValue == null) return;

            if(_TermA == null || _TermB == null) return;

            switch (portName)
            {
                case "Term1IN":
                    lock (_TermA)
                    {
                        _TermA.Enqueue((int)typedValue);
                    }
                    break;
                case "Term2IN":
                    lock (_TermB)
                    {
                        _TermB.Enqueue((int)typedValue);
                    }
                    break;
                default:
                    throw new ArgumentException(portName + " does not exist on this component.");
            }
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
