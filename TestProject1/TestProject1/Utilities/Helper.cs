using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serialization.Json;

namespace TestProject1.Utilities
{
    public static class Helper
    {

        public static Dictionary<string, string> DeserializeResponse(this IRestResponse restResponse)
        {
            var jsonObj = new JsonDeserializer().Deserialize<Dictionary<string,string>>(restResponse);
            return jsonObj;
        }

        public static string DeserializeResponseUsingJObject(this IRestResponse restResponse, string responseObj)
        {
            
            var jObject = JObject.Parse(restResponse.Content);
            return jObject[responseObj]?.ToString();
        }
        

    }
}