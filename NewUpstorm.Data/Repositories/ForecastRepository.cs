//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
//using NewUpstorm.Data.IRepositories;
//using NewUpstorm.Domain.Entities;
//using System;

//namespace NewUpstorm.Data.Repositories
//{
//    public class ForecastRepository : IForecastRepository
//    {
//        string path = AppAPISetting.PATH;
//        string weeklyPath = AppAPISetting.WEEKLY_PATH;

//        public async ValueTask<RootObject> SelectCurrentForecastAsync(string city)
//        {
//            path = path.Replace("Tashkent",city);

//            HttpClient client = new HttpClient();
//            var response = (await client.GetAsync(path));
//            string content = await response.Content.ReadAsStringAsync();

//            RootObject data = JsonConvert.DeserializeObject<RootObject>(content);

//            return data;
//        }

//        public async ValueTask<JToken> SelectWeeklyForecastAsync(string city, string county_code)
//        {
//            path = path.Replace("Tashkent", city).Replace("uz", county_code);

//            using (var httpClient = new HttpClient())
//            {
//                var response = httpClient.GetAsync(path).Result;
//                var content = response.Content.ReadAsStringAsync().Result;

//                var data = JObject.Parse(content);

//                var forecasts = data["list"];

//                return forecasts;
//            }
//        }
//    }
//}
