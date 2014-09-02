using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace SteamProject.Utils
{
    public static class XmlUtils
    {
        public static string GetAttributeXML(XmlNode xmlNode, string xmlPath, string nameAttribute)
        {
            XmlNode node;

            if (!string.IsNullOrEmpty(xmlPath))
                node = xmlNode.SelectSingleNode(xmlPath);
            else
                node = xmlNode;

            if (node != null && node.InnerText != null)
            {
                if (node.Attributes[nameAttribute] != null)
                    return node.Attributes[nameAttribute].InnerText;
                else
                    return "";
            }
            else
                return "";
        }

        public static string GetAttributeXML(XmlNode xmlNode, string nameAttribute)
        {
            if (xmlNode != null && xmlNode.InnerText != null)
            {
                if (xmlNode.Attributes[nameAttribute] != null)
                    return xmlNode.Attributes[nameAttribute].InnerText;
                else
                    return "";
            }
            else
                return "";
        }

        public static string GetAttributeXML(XmlNode xmlNode, string xmlPath, string nameAttribute, XmlNamespaceManager nsmgr)
        {
            XmlNode node;

            if (!string.IsNullOrEmpty(xmlPath))
                node = xmlNode.SelectSingleNode(xmlPath, nsmgr);
            else
                node = xmlNode;

            if (node != null && node.InnerText != null)
            {
                if (node.Attributes[nameAttribute] != null)
                    return node.Attributes[nameAttribute].InnerText;
                else
                    return "";
            }
            else
                return "";
        }

        public static string GetInnerValue(XmlNode xmlNode)
        {
            if (xmlNode != null && xmlNode.InnerText != null)
                return xmlNode.InnerText.Trim();
            else
                return "";
        }

        public static string GetItemXML(XmlNode xmlNode, string xmlPath)
        {
            XmlNode node;

            if (!string.IsNullOrEmpty(xmlPath))
                node = xmlNode.SelectSingleNode(xmlPath);
            else
                node = xmlNode;

            if (node != null && node.InnerText != null)
                return node.InnerText;
            else
                return "";
        }

        public static string GetItemXML(XmlNode xmlNode, string xmlPath, XmlNamespaceManager nsmgr)
        {
            XmlNode node;

            if (!string.IsNullOrEmpty(xmlPath))
                node = xmlNode.SelectSingleNode(xmlPath, nsmgr);
            else
                node = xmlNode;

            if (node != null && node.InnerText != null)
                return node.InnerText;
            else
                return "";
        }

        public static string SelectSingleNodeValue(XmlNode xmlNode, string xmlPath)
        {
            XmlNode node = null;
            if (!string.IsNullOrEmpty(xmlPath))
                node = xmlNode.SelectSingleNode(xmlPath);

            return node != null ? GetInnerValue(node) : null;
        }

        public static string GetItemInnerXML(XmlNode xmlNode, string xmlPath, XmlNamespaceManager nsmgr)
        {
            XmlNode node;

            if (!string.IsNullOrEmpty(xmlPath))
                node = xmlNode.SelectSingleNode(xmlPath, nsmgr);
            else
                node = xmlNode;

            if (node != null && node.InnerXml != null)
                return node.InnerXml;
            else
                return "";
        }


        public static void WriteElementCData(XmlTextWriter xml, string columnName, object value)
        {
            if (value != null)
            {
                xml.WriteStartElement(columnName);
                xml.WriteCData(Converter.ToString(value));
                xml.WriteEndElement();
            }
        }

        public static void WriteElementCData(XmlTextWriter xml, string columnName, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                xml.WriteStartElement(columnName);
                xml.WriteCData(value);
                xml.WriteEndElement();
            }
        }

        public static void WriteElement(XmlTextWriter xml, string columnName, object value)
        {
            if (value != null)
            {
                xml.WriteStartElement(columnName);
                xml.WriteValue(Converter.ToString(value));
                xml.WriteEndElement();
            }
        }

        public static void WriteElement(XmlTextWriter xml, string columnName, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                xml.WriteStartElement(columnName);
                xml.WriteValue(value);
                xml.WriteEndElement();
            }
        }

        public static void WriteAttribute(XmlTextWriter xml, string columnName, object value)
        {
            if (value != null)
                xml.WriteAttributeString(columnName, Converter.ToString(value));
        }

        public static void WriteAttribute(XmlTextWriter xml, string columnName, string value)
        {
            if (!string.IsNullOrEmpty(value))
                xml.WriteAttributeString(columnName, value);
        }

    }
}
