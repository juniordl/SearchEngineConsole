using SearchEngine.Core.Entities;
using SearchEngine.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;

namespace SearchEngine.Core.Service
{
    public class ConfigService : IConfigService
    {
        private readonly IConfigurationRoot _config;

        public ConfigService(IConfigurationRoot config) {
            this._config = config;
        }

        public List<Searcher> ConfigSearchers()
        {
            List<Searcher> searchers = _config.GetSection("Providers").Get<List<Searcher>>();
            return searchers;
        }
    }
}
