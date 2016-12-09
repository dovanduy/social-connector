namespace App.Common.Helpers
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public class JsonHelper
    {
        public static string ToString(object data)
        {
            return JsonConvert.SerializeObject(
                data,
                Formatting.None,
                new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }
    }
}
