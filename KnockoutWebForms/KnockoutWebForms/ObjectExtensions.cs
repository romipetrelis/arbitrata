using Newtonsoft.Json;

namespace KnockoutWebForms
{
    public static class ObjectExtensions
    {
        public static string ToJson(this object value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}