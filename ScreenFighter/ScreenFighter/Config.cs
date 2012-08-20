using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ScreenFighter
{
    class Config
    {
        public string FolderPathFullScreenShot;
        public ImageFormat ImageFormat;

        string fileName;

        public Config()
        {
            FolderPathFullScreenShot = @"d:\";
            ImageFormat = ImageFormat.Png;
            fileName = Application.ExecutablePath + ".cfg";
        }

        public bool Load()
        {
            if (!File.Exists(fileName))
                return false;
            
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(fileName);
            }
            catch (XmlException)
            {
                return false;
            }

            XmlNode root = doc.SelectSingleNode("config");
            if (root == null)
                return false;

            if (root.Attributes["version"] == null ||
                root.Attributes["version"].InnerText != Application.ProductVersion)
                return false;

            XmlNode node = root["FolderPathFullScreenShot"];
            if (node == null)
                return false;
            string _FolderPathFullScreenShot = node.InnerText;

            node = root["ImageFormat"];
            if (node == null)
                return false;

            ImageFormat _ImageFormat = FromTextToImageFormat(node.InnerText);
            if (_ImageFormat == null)
                return false;

            // All okay
            FolderPathFullScreenShot = _FolderPathFullScreenShot;
            ImageFormat = _ImageFormat;

            return true;
        }

        public void Save()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("config");
            root.SetAttribute("version", Application.ProductVersion);
            doc.AppendChild(root);

            XmlElement tmp = doc.CreateElement("FolderPathFullScreenShot");
            tmp.InnerText = FolderPathFullScreenShot;
            root.AppendChild(tmp);

            tmp = doc.CreateElement("ImageFormat");
            tmp.InnerText = ImageFormat.ToString();
            root.AppendChild(tmp);

            doc.Save(fileName);
        }

        public static ImageFormat FromTextToImageFormat(string text)
        {
            switch (text)
            {
                case "Png": return ImageFormat.Png;
                case "Jpeg": return ImageFormat.Jpeg;
                case "Gif": return ImageFormat.Gif;
                default: return null;
            }
        }
    }
}
