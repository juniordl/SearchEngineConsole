using SearchEngine.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.Core.Interfaces
{
    public interface IConfigService
    {
        List<Searcher> ConfigSearchers();
    }
}
