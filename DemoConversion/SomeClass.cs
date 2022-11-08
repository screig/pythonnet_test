using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DemoConversion
{
    public class SomeClass
    {
        private static ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);


        static SomeClass()
        {
            RegisterEncoders.register_python_encoders();
        }

        public static DateTime get_current_time()
        {
            return DateTime.UtcNow;
        }

        public static List<string> get_names()
        {
            List<string> some_names = new List<string>() { "Tom", "Dick", "Harry"};  
            return some_names;

        }




        internal static void CreateLogfile()
        {
            string ConfigFile = "log4net.config";

            if (!File.Exists(ConfigFile))
            {
                Assembly asm = MethodBase.GetCurrentMethod().DeclaringType.Assembly;
                string resourceName = asm.GetManifestResourceNames().Single(str => str.EndsWith(ConfigFile));
                using (Stream stream = asm.GetManifestResourceStream(resourceName))
                {
                    XmlConfigurator.Configure(stream);
                }
            }
            else
            {
                XmlConfigurator.Configure(new FileInfo(ConfigFile));
            }
            _log.Warn($"***********************************************************");
            _log.Warn($"Starting");
            _log.Warn($"***********************************************************");

        }


    }
}
