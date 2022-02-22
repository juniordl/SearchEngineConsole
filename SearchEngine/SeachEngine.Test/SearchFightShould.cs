using Xunit;
using Moq;
using Microsoft.Extensions.Configuration;
using System.IO;
using System;
using SearchEngine.Core.Service;

namespace SeachEngine.Test
{
    public class SearchFightShould
    {
        public static IConfigurationRoot configuration;

        public SearchFightShould() {
            configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                    .AddJsonFile(@"TestData/SearchersTestData.json", false)
                    .Build();
        }

        [Fact]
        public void validateSearchers() {

            var config = new ConfigService(configuration);
            var searchers = config.ConfigSearchers();
            Assert.True(searchers.Count > 0);
        }
    }
}
