using System;
using System.Runtime.Serialization;

namespace IConcepts.Net.Serialization
{
    [Serializable]
    public class JsonSerializationWrapper<T> : ISerializable
    {
        private readonly T _item;

        public T Item
        {
            get { return _item; }
        }

        public JsonSerializationWrapper(T item)
        {
            _item = item;
        }

        protected JsonSerializationWrapper(SerializationInfo info, StreamingContext context)
        {
            string text = info.GetString("Item");
            _item = JsonHelper.JsonToObject<T>(text);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            string text = JsonHelper.ObjectToJson(_item);
            info.AddValue("Item", text);
        }
    }
}