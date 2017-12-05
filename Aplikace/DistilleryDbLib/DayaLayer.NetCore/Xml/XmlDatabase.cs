using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Xml;
using System.IO;

namespace DataLayerNetCore.Xml
{
    public class XmlDatabase : IDatabase
    {
        private string xmlFile;
        private XmlDocument xmlDocument;
        private XmlNode root;
        private string rootName = "distillery/";

        public XmlDatabase(string xmlFile)
        {
            this.xmlFile = xmlFile;
            if (!File.Exists(xmlFile))
            {
                using (XmlWriter xWriter = XmlWriter.Create(xmlFile))
                {
                    xWriter.WriteStartDocument();
                    new XmlDocument().Save(xWriter);
                }

            }

            xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlFile);

            root = xmlDocument.DocumentElement;
        }

        private string GetEntitySetName<T>(T entity)
        {
            return entity.GetType().Name + "_set";
        }

        private bool XmlSetExists(string setName)
        {
            return (xmlDocument.SelectNodes(rootName + setName).Count > 0);
        }

        private int GetNextId<T>(T entity)
        {
            string entitySet = GetEntitySetName(entity);
            if (XmlSetExists(entitySet))
            {
                XmlNodeList list = root.SelectNodes(entitySet + "/" + entity.GetType().Name + "/Id");
                int max = -1;
                foreach (XmlNode node in list)
                {
                    if (int.TryParse(node.InnerText, out int id))
                    {
                        if (id > max)
                            max = id;
                    }
                }
                return max + 1;
            }
            return 0;
        }

        private void SaveXml()
        {
            xmlDocument.Save(xmlFile);
        }

        public int Insert<T>(T entity)
        {
            string xmlSet = GetEntitySetName(entity);

            XmlNode setNode;
            if (!XmlSetExists(xmlSet))
            {
                setNode = xmlDocument.CreateElement(xmlSet);
                root.AppendChild(setNode);
            }
            else
            {
                setNode = xmlDocument.SelectSingleNode(rootName + xmlSet);
            }

            setNode.AppendChild(ConstructElement(entity));

            SaveXml();
            return 1;
        }

        private XmlElement ConstructElement<T>(T entity)
        {
            XmlElement entityElement = xmlDocument.CreateElement(entity.GetType().Name);

            foreach (PropertyInfo property in entity.GetType().GetProperties())
            {
                if (IgnoreProperty(property))
                {
                    continue;
                }

                if (ForeignKey(property) is Attribute attribute)
                {
                    if (!PassForeignKeyConstraint(attribute, Convert.ToInt32(property.GetValue(entity))))
                    {
                        throw new ForeignKeyException(nameof(entity));
                    }
                }

                XmlElement propElement = xmlDocument.CreateElement(property.Name);
                if (property.Name == "Id")
                    propElement.InnerText = GetNextId(entity).ToString();
                else
                    propElement.InnerText = property.GetValue(entity)?.ToString();

                entityElement.AppendChild(propElement);
            }

            return entityElement;
        }

        private bool PassForeignKeyConstraint(Attribute attribute, int value)
        {
            if (attribute is ForeignKey fk)
            {
                string referencedSetName = fk.ReferencedEntity.Name + "_set";
                if (!XmlSetExists(referencedSetName))
                    return false;

                string query =
                    referencedSetName + "/" + fk.ReferencedEntity.Name + "[" + fk.ReferencedValue + "=" +
                    value.ToString() + "]";

                XmlNode referencedNode = root.SelectSingleNode(query);

                if (referencedNode != null)
                    return true;

            }
            return false;
        }

        private bool IgnoreProperty(PropertyInfo property)
        {
            foreach (Attribute attribute in property.GetCustomAttributes())
            {
                if (attribute is XmlIgnoreAttribute)
                {
                    return true;
                }
            }
            return false;
        }

        private Attribute ForeignKey(PropertyInfo property)
        {
            foreach (Attribute attribute in property.GetCustomAttributes())
            {
                if (attribute is ForeignKey fk)
                {
                    return attribute;
                }
            }
            return null;
        }

        public ICollection<T> SelectAll<T>(T type) where T : new()
        {
            string entitySet = GetEntitySetName(type);
            if (!XmlSetExists(entitySet))
                return new List<T>();

            XmlNodeList nodeList = root.SelectNodes(entitySet + "/" + type.GetType().Name);

            List<T> result = new List<T>();
            foreach (XmlNode node in nodeList)
            {
                result.Add(ConstructObject(type, node));
            }

            return result;
        }

        public T Select<T>(T type, int primaryKey) where T : new()
        {
            string entitySet = GetEntitySetName(type);
            if (!XmlSetExists(entitySet))
                return default(T);

            string query = entitySet + "/" + type.GetType().Name + "[Id=" + primaryKey.ToString() + "]";
            XmlNode node = root.SelectSingleNode(query);

            return ConstructObject(type, node);
        }


        private T ConstructObject<T>(T type, XmlNode node) where T : new()
        {
            if (node == null)
                return default(T);

            T obj = new T();
            foreach (PropertyInfo property in type.GetType().GetProperties())
            {
                if (IgnoreProperty(property))
                    continue;

                string value = node.SelectSingleNode(property.Name).InnerText;

                if (property.PropertyType == typeof(int))
                    property.SetValue(obj, int.Parse(value));
                else if (property.PropertyType == typeof(float))
                    property.SetValue(obj, float.Parse(value));
                else if (property.PropertyType == typeof(double))
                    property.SetValue(obj, double.Parse(value));
                else if (property.PropertyType == typeof(DateTime))
                    property.SetValue(obj, DateTime.Parse(value));
                else
                    property.SetValue(obj, value);
            }

            return obj;
        }


        public int Delete<T>(T entity)
        {
            string entitySet = GetEntitySetName(entity);
            if (!XmlSetExists(entitySet))
                return 0;

            int id = GetId(entity);

            if (id == -1)
                return 0;

            string query = entitySet + "/" + entity.GetType().Name + "[Id=" + id.ToString() + "]";
            //XmlNode node = root.SelectSingleNode(query);
            //xmlDocument.RemoveChild(node);
            int count = 0;
            XmlNode setNode = xmlDocument.SelectSingleNode(rootName + entitySet);
            foreach (XmlNode node in root.SelectNodes(query))
            {
                ++count;
                setNode.RemoveChild(node);
            }

            SaveXml();

            return count;
        }

        private int GetId<T>(T entity)
        {
            foreach (PropertyInfo property in entity.GetType().GetProperties())
            {
                if (property.Name == "Id" && property.PropertyType == typeof(int))
                    return Convert.ToInt32(property.GetValue(entity));
            }
            return -1;
        }

        public int Update<T>(T entity)
        {
            string entitySet = GetEntitySetName(entity);
            if (!XmlSetExists(entitySet))
                return 0;

            int id = GetId(entity);

            if (id == -1)
                return 0;

            string query = entitySet + "/" + entity.GetType().Name + "[Id=" + id.ToString() + "]";
            XmlNode node = root.SelectSingleNode(query);

            XmlNode setNode = xmlDocument.SelectSingleNode(rootName + entitySet);

            setNode.RemoveChild(node);
            setNode.AppendChild(ConstructElement(entity));

            SaveXml();
            return 1;
        }
    }
}
