using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using FlowSharp.Core.Components;

namespace FlowSharp.Core
{
    public class Network
    {
        private readonly Dictionary<string, INetworkComponent> _ComponentDictionary;

        public Network()
        {
            _ComponentDictionary = new Dictionary<string, INetworkComponent>();
        }

        public void AddComponent(Type type, string name)
        {
            throw new NotImplementedException();
        }

        public void Connect(string ComponentFrom, string PortFrom, string ComponentTo, string PortTo)
        {
            if(!_ComponentDictionary.ContainsKey(ComponentFrom))
                throw new ArgumentException("This component has not been added to the network.", ComponentFrom);
            if(!_ComponentDictionary.ContainsKey(ComponentTo))
                throw new ArgumentException("This component has not been added to the network.", ComponentFrom);

            var from = _ComponentDictionary[ComponentFrom];
            var to = _ComponentDictionary[ComponentTo];


        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void AddComponent<T>(string name)
            where T : class, INetworkComponent
        {
            if(_ComponentDictionary.ContainsKey(name))
                throw new InvalidOperationException("This component already exists! You can't add the same component twice!");

            var instance = (T)typeof(T).InvokeMember(
                typeof(T).Name, 
                BindingFlags.CreateInstance, 
                null, 
                null, 
                null);

            _ComponentDictionary.Add(name, instance);
        }
    }
}
