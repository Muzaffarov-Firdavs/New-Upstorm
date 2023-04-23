using Microsoft.EntityFrameworkCore.Metadata;
using NewUpstorm.Domain.Entities;
using System.Runtime.InteropServices;
using static System.Net.WebRequestMethods;

namespace NewUpstorm.Data.Configurations
{
    public class AppAPISetting
    {
        public const string PATH = 
        $"https://api.openweathermap.org/data/2.5/weather?q=Tashkent&units=metric&appid=c45d8b9a884e5ff945eb105a164c78e7";

        public const string WEEKLY_PATH =
           $"https://api.openweathermap.org/data/2.5/forecast?q=Tashkent,uz&appid=c45d8b9a884e5ff945eb105a164c78e7";
    }
}
