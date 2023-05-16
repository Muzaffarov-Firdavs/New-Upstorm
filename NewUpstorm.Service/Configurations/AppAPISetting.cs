namespace NewUpstorm.Service.Configurations
{
    public class AppAPISetting
    {
        public const string PATH = 
        $"https://api.openweathermap.org/data/2.5/weather?q=Tashkent&units=metric&appid=[enter your api]";

        public const string WEEKLY_PATH =
           $"https://api.openweathermap.org/data/2.5/forecast?q=Tashkent,uz&appid=[enter your api]";
    }
}
