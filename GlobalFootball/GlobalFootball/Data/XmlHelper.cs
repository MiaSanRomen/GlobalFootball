using GlobalFootball.Structure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Xamarin.Forms;

namespace GlobalFootball.Data
{
    class XmlHelper
    {
        private static string FileName = "Setting.xml";
        public static void Save(Settings settings)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filename = Path.Combine(path, FileName);

            using (Stream stream = File.Open(filename, FileMode.Create))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(Settings));
                formatter.Serialize(stream, settings);
            }
        }
        public static Settings Load()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filename = Path.Combine(path, FileName);

            if (File.Exists(filename))
            {
                try
                {
                    using (Stream stream = File.Open(filename, FileMode.Open))
                    {
                        XmlSerializer formatter = new XmlSerializer(typeof(Settings));
                        Settings settings = (Settings)formatter.Deserialize(stream);
                        return settings;
                    }
                }
                catch
                { }
            }
            return null;
        }

        public static string GetHexString(Color color)
        {
            var red = (int)(color.R * 255);
            var green = (int)(color.G * 255);
            var blue = (int)(color.B * 255);
            var hex = $"#{red:X2}{green:X2}{blue:X2}";
            return hex;
        }
    }
}
