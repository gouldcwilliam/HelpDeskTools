using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;
using System.IO;

namespace ConfigFileTest
{
    public class MyConfig
    {
        public const string configPath = @"test.config";

        public string setting1 { get; set; }
        public string setting2 { get; set; }

        public static MyConfig Load()
        {
            XmlSerializer xs = new XmlSerializer(typeof(MyConfig));
            using(StreamReader sr = new StreamReader(configPath))
            {
                return (MyConfig)xs.Deserialize(sr);
            }
        }
        public void Save()
        {
            XmlSerializer xs = new XmlSerializer(typeof(MyConfig));
            using(StreamWriter sw = new StreamWriter(configPath))
            {
                xs.Serialize(sw, this);
            }
        }
    }
}
