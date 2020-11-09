public class AbstractClassConverter<T> : JsonConverter 
    {
        private readonly Type[] _types;

        public AbstractClassConverter(params Type[] types)
        {
            _types = types;
        }
        
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
 
            foreach (Type type in _types)
            {
                try
                {
                    return (T) jObject.ToObject(type);
                }
                catch (Exception) { }
            }
            throw new InvalidOperationException();
        }
        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }
    }
