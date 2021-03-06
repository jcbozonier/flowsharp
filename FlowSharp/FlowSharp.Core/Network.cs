﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using FlowSharp.Core.Components;

namespace FlowSharp.Core
{
    public class Network
    {
        private readonly Dictionary<string, INetworkComponent> _ComponentDictionary;
        private readonly List<NetworkConnection> _Connections;
        private bool _Done;

        public Network()
        {
            _ComponentDictionary = new Dictionary<string, INetworkComponent>();
            _Connections = new List<NetworkConnection>();
        }

        public void Connect(string ComponentFrom, string PortFrom, string ComponentTo, string PortTo)
        {
            if(!_ComponentDictionary.ContainsKey(ComponentFrom))
                throw new ArgumentException("This component has not been added to the network.", ComponentFrom);
            if(!_ComponentDictionary.ContainsKey(ComponentTo))
                throw new ArgumentException("This component has not been added to the network.", ComponentFrom);

            var connection = new NetworkConnection(ComponentFrom, PortFrom, ComponentTo, PortTo);

            if(_Connections.Contains(connection))
                throw new InvalidOperationException("This connection has already been made! You can't do it twice!");

            _Connections.Add(connection);
        }

        public void Start()
        {
            foreach(var component in _ComponentDictionary.Values)
            {
                // All connections that originate from my component
                var componentConnections = _Connections.Where(connection => connection.FromName == component.Name).ToArray();

                if(componentConnections.Count() == 0)
                    return;

                new Thread(
                    theComponent => _RunComponents(theComponent, componentConnections.ToArray()))
                    .Start(component);
            }
        }

        private void _RunComponents(object theComponent, NetworkConnection[] componentConnections)
        {
            var runningComponent = theComponent as INetworkComponent;

            if (runningComponent == null) return;
            
            while (!_Done)
            {
                _ProcessConnections(runningComponent, componentConnections);
                Thread.Sleep(20);
            }

            foreach (var pair in _ComponentDictionary)
            {
                pair.Value.Dispose();
            }
        }

        private void _ProcessConnections(INetworkComponent runningComponent, NetworkConnection[] componentConnections)
        {
            foreach (var connection in componentConnections)
            {
                var output = runningComponent.GetFromPort(connection.FromPortName);
                var toComponent = _ComponentDictionary[connection.ToName];
                toComponent.SendToPort(output, connection.ToPortName);
            }
        }

        public void Stop()
        {
            _Done = true;
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
                new object[]{name});

            _ComponentDictionary.Add(name, instance);
        }
    }
}
