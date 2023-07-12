using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public static class JsonHelper
    {
        public static JToken DeserializeJsonAndGetToken(this RestResponse response, string tokenPath)
        {
            return JsonConvert.DeserializeObject<JObject>(response.Content).SelectToken(tokenPath);
        }
        
        public static IEnumerable<JToken> DeserializeJsonAndGetTokens(this RestResponse response, string tokenPath)
        {
            return JsonConvert.DeserializeObject<JObject>(response.Content).SelectTokens(tokenPath);
        }

        public static JToken GetElementByValue(this RestResponse response, string tokenPath, string key, string value)
        {
            var allTokens = response.DeserializeJsonAndGetTokens(tokenPath);

            foreach (var token in allTokens)
            {
                if (token.SelectToken(key).ToString() == value)
                {
                    return token;
                }
            }

            return null;
        }

        public static JToken[] GetElementByValueBulk(this RestResponse response, string tokenPath, string key, string[] values)
        {
            var allTokens = response.DeserializeJsonAndGetTokens(tokenPath);
            var filteredTokens = new List<JToken>();

            foreach (var token in allTokens)
            {
                if (values.Contains(token.SelectToken(key).ToString()))
                {
                    filteredTokens.Add(token);
                }
            }

            return filteredTokens.ToArray<JToken>();
        }

        public static JToken GetLastEntry(this RestResponse response, string tokenPath)
        {
            var allTokens = response.DeserializeJsonAndGetTokens(tokenPath);
            JToken entry = null;

            foreach (var token in allTokens)
            {
                entry = token;
            }

            return entry;
        }
    }
}
