using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CoreLayer.Helper
{
    public static class SessionHelper
    {
        public static void SetObjectAsJson(this Microsoft.AspNetCore.Http.ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJson<T>(this Microsoft.AspNetCore.Http.ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}