# Search Engine Console

This is a console application built on C# with .NET Core. That receives multiple arguments, does a search in the search engines defined in a json file and obtains the total of results to compare them, this solution implement onion arquitecture and dependency inversion principle.

### Execution

1. Download compressed file SearchEngine.exe.rar
2. Unzip it in your prefered folder
3. Open the cmd console in the application path and enter the words to search
```sh
F:\path> SearchEngine.exe java .net

//result
find word java in {Searcher1}, total results {1900000}
find word java in {Searcher2}, total results {2921034320}
find word .net in {Searcher1}, total results {1900000}
find word .net in {Searcher2}, total results {2921034320}
Winner in {Searcher1} : java
Winner in {Searcher2} : .net
Total Winner: java
```
### Search engine configuration
search engines can be added with the following configuration file and its properties:
* ***baseuri*** - api uri without parameters
* ***searcherName*** - name provider search engine
* ***headers*** - list of headers requires to request
* ***uriParameters*** - params requires to request, for the search parameter always use {query}
* ***nodesResult*** - name of parent and child from which the value will be taken
```json
{
  "Providers": [
    {
      "baseuri": "https://www.googleapis.com/customsearch/v1",
      "searcherName": "Google Search",
      "headers": {},
      "uriParameters": [
        "?key=[YOUR_APIKEY_HERE]",
        "&cx=xxxxxxxxxxxxxxx",
        "&q={query}"
      ],
      "nodesResult": {
        "searchInformation": "totalResults"
      }
    },
    }
  ]
}
```

Enjoy!
