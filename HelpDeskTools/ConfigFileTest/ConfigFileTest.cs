using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigFileTest
{
    class ConfigFileTest
    {
        static void Main(string[] args)
        {
            MyConfig config = new MyConfig();
            if (!System.IO.File.Exists(MyConfig.configPath))
            {
                config.setting1 = "default setting 1";
                config.setting2 = "default setting 2";
                config.Save();
            }
            if (System.IO.File.Exists(MyConfig.configPath))
            {
                config = MyConfig.Load();
            }

            Console.WriteLine(config.setting1);
            Console.WriteLine(config.setting2);

            Console.Write("Press any key....."); Console.ReadKey();
        }
    }
}
