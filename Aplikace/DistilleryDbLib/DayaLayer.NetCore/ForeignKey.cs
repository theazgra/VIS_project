using System;

namespace DataLayerNetCore
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class ForeignKey : Attribute
    {
        public Type ReferencedEntity { get; private set; }
        public string ReferencedValue { get; private set; }

        public ForeignKey(Type entity, string referencedValue)
        {
            ReferencedEntity = entity;
            ReferencedValue = referencedValue;
        }
    }
}
