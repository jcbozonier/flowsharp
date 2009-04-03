using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowSharp.Core
{
    public class NetworkConnection
    {
        public string FromName
        { get; private set; }
        public string FromPortName
        { get; private set; }
        public string ToName
        { get; private set; }
        public string ToPortName
        { get; private set; }

        public NetworkConnection(
            string fromName, 
            string fromPortName, 
            string toName, 
            string toPortName)
        {
            FromName = fromName;
            FromPortName = fromPortName;
            ToName = toName;
            ToPortName = toPortName;
        }

        public bool Equals(NetworkConnection obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj.FromName, FromName) && Equals(obj.FromPortName, FromPortName) && Equals(obj.ToName, ToName) && Equals(obj.ToPortName, ToPortName);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var result = (FromName != null ? FromName.GetHashCode() : 0);
                result = (result*397) ^ (FromPortName != null ? FromPortName.GetHashCode() : 0);
                result = (result*397) ^ (ToName != null ? ToName.GetHashCode() : 0);
                result = (result*397) ^ (ToPortName != null ? ToPortName.GetHashCode() : 0);
                return result;
            }
        }
    }
}
