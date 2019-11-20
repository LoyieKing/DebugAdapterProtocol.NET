using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DebugAdapterProtocol.Utility
{
    public static class JObjectExtension
    {
        private readonly static MethodInfo jObjectValueMethod = null;

        static JObjectExtension()
        {
            jObjectValueMethod = typeof(JObject).GetMethod("Value", new Type[] { typeof(object) });
        }


        public static object Value(this JObject jObject, Type type, object key)
        {
            return jObject.Value<JObject>(key).ToObject(type);
        }
    }
}
