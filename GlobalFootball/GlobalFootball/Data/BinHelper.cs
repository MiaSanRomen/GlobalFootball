using GlobalFootball.Structure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GlobalFootball.Data
{
    class BinHelper
    {
        private static string FileName = "League.bin";
        public static void Save(List<League> leagues)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filename = Path.Combine(path, FileName);

            using (Stream stream = File.Open(filename, FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, leagues);
            }
        }
        public static List<League> Load()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filename = Path.Combine(path, FileName);

            if (File.Exists(filename))
            {
                using (Stream stream = File.Open(filename, FileMode.Open))
                {
                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    var leagues = (List<League>)binaryFormatter.Deserialize(stream);
                    return leagues;
                }
            }
            return null;
        }
    }
}
