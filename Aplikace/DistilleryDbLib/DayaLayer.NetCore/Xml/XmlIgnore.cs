namespace DataLayerNetCore.Xml
{
    [System.AttributeUsage(System.AttributeTargets.Property | System.AttributeTargets.Field, AllowMultiple = true)]
    sealed class XmlIgnoreAttribute : System.Attribute
    {
        public XmlIgnoreAttribute()
        {
        }
    }
}