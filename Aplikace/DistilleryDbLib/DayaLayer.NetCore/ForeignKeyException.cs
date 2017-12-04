using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayerNetCore
{

    [Serializable]
    public class ForeignKeyException : Exception
    {
        public ForeignKeyException() { }
        public ForeignKeyException(string message) : base(message) { }
        public ForeignKeyException(string message, Exception inner) : base(message, inner) { }
        protected ForeignKeyException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
