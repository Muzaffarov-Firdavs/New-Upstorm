using System.Text.RegularExpressions;

namespace NewUpstorm.Web.Helpers
{
    public class RouteConfiguration
    {
        public string TransformOutbound(object value)
        {
            // Slugify value
            return value == null ? null : Regex.Replace(value.ToString(), "([a-z])([A-Z])", "$1-$2").ToLower();
        }
    }
}
