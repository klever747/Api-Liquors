using Newtonsoft.Json;

namespace Application.MobileApp.Helpers
{
    public static class DeserializationHelpers
    {
        public static T DeserializeData<T>(object data) => data is null
            ? default
            : JsonConvert.DeserializeObject<T>(data.ToString());
    }
}
