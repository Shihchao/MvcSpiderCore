using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Common.Tool
{
    public class ConfigEntity
    {
        public ConfigEntity(string path, bool optional = true, bool reloadOnChange = true)
        {
            Root = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(path, optional, reloadOnChange)
                .Build();
        }

        public IConfigurationRoot Root
        {
            private set;
            get;
        }

        public string GetConnectionString(string configName)
        {
            return Root.GetConnectionString(configName);
        }
    }
}
