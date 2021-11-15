using Newtonsoft.Json;
using Refit;
using RestSharp.Deserializers;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Refit2Lib
{
    public class DataUSA
    {
        [JsonProperty(PropertyName = "data")]
        public List<Nation> data { get; set; }
        [JsonProperty(PropertyName = "source")]
        public List<M> source { get; set; }
    }

    public class M
    {
        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }
    }

    public class Nation
    {
        [JsonProperty(PropertyName = "ID Nation")]
        public string id_nation { get; set; }
        [JsonProperty(PropertyName = "Nation")]
        public string nation { get; set; }
        [JsonProperty(PropertyName = "ID Year")]
        public int id_year { get; set; }
        [JsonProperty(PropertyName = "Year")]
        public string year { get; set; }
        [JsonProperty(PropertyName = "Population")]
        public int population { get; set; }
        [JsonProperty(PropertyName = "Slug Nation")]
        public string slug_nation { get; set; }
    }
    public class Bored
    {
        [JsonProperty(PropertyName = "activity")]
        public string activity { get; set; }
        [JsonProperty(PropertyName = "type")]
        public string type { get; set; }
        [JsonProperty(PropertyName = "participants")]
        public int participants { get; set; }
        [JsonProperty(PropertyName = "price")]
        public float price { get; set; }
        [JsonProperty(PropertyName = "link")]
        public string link { get; set; }
        [JsonProperty(PropertyName = "key")]
        public string key { get; set; }
        [JsonProperty(PropertyName = "accessibility")]
        public float accessibility { get; set; }
    }

    public interface IDataUSA
    {
        [Get("/api/data")]
        Task<DataUSA> GetInfos([AliasAs("drilldowns")] string drilldowns, [AliasAs("measures")] string measures);
    }

    public interface IBoredApi
    {
        [Get("/api/activity")]
        Task<Bored> GetInfos();
    }

    public class Go
    {
        public static async Task<Bored> Task()
        {
            HttpClient _client = new HttpClient
            {
                BaseAddress = new Uri("https://boredapi.com")
            };
            IBoredApi _restApiService = RestService.For<IBoredApi>(_client);
            Bored bored;
            bored = await _restApiService.GetInfos();
            return bored;
        }

        public static async Task<DataUSA> DataUSA()
        {
            HttpClient _client = new HttpClient
            {
                BaseAddress = new Uri("https://datausa.io")
            };
            IDataUSA _restApiService = RestService.For<IDataUSA>(_client);
            //DataUSA<Nation> datausa;
            var drilldowns = "Nation";
            var measures = "Population";
            var datausa = await _restApiService.GetInfos(drilldowns, measures);
            return datausa;
        }
    }
    
}
