using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProxyManager.Helpers
{
    internal sealed class XmlHelper
    {
        public XmlDocument Document { get; set; }

        public string CorePath { get; set; } = "ProxyManager";
        public string ElementPath { get; set; } = "Setting";
        public string FilePath { get; set; }

        public XmlHelper(string filePath)
        {
            Document = new XmlDocument();
            FilePath = filePath;

            string dirPath = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            if (!File.Exists(filePath))
            {
                ResetFileContents();
            }
        }

        public XmlNode CreateNode(string key, string value)
        {
            var node = Document.CreateElement(key);
            node.InnerText = value;

            return node;
        }

        public string GetValue(XmlNode node, string key)
        {
            return node.SelectSingleNode(key).InnerText;
        }

        public bool Save(XmlNode[] nodes)
        {
            Document.Load(FilePath);

            var mainElement = Document.CreateElement(ElementPath);

            foreach (var node in nodes)
            {
                mainElement.AppendChild(node);
            }

            Document.DocumentElement.AppendChild(mainElement);
            Document.Save(FilePath);

            return true;
        }

        public List<XmlNode> Read()
        {
            try
            {
                Document.Load(FilePath);

                var nodes = new List<XmlNode>();
                foreach (XmlNode node in Document.SelectNodes(string.Format("{0}/{1}", CorePath, ElementPath)))
                {
                    nodes.Add(node);
                }

                return nodes;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void ResetFileContents()
        {
            File.WriteAllText(FilePath, string.Format(@"<{0}></{0}>", CorePath));
        }
    }
}
