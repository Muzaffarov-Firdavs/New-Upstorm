namespace NewUpstorm.Service.Configurations
{
    public class AppAPISetting
    {
        public const string PATH = 
        $"https://api.openweathermap.org/data/2.5/weather?q=Tashkent&units=metric&appid=[Enter your api key]";

        public const string WEEKLY_PATH =
           $"https://api.openweathermap.org/data/2.5/forecast?q=Tashkent,uz&appid=[Enter your api key]";
    }
}
