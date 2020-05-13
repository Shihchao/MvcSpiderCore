using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;

namespace Common.Tool
{
    public static class ConfigurationManager
    {
        static Dictionary<string, ConfigEntity> configSet = new Dictionary<string, ConfigEntity>();

        public static ConfigEntity GetConfiguration(string path = "appsettings.json")
        {
            if (!configSet.ContainsKey(path))
            {
                if (path == "appsettings.json")
                {
                    configSet.Add(path, new ConfigEntity(path, false, true));
                }
                else
                {
                    configSet.Add(path, new ConfigEntity(path));
                }
            }

            return configSet[path];
        }
    }
}
