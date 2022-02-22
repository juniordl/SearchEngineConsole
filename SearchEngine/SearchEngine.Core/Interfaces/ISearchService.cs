using SearchEngine.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.Core.Interfaces
{
    public interface ISearchService
    {
        Task<List<Result>> SearchInWeb(List<string> words);
    }
}
