using System;
using System.Runtime.Serialization;

namespace IConcepts.Net.Serialization
{
    [Serializable]
    public class SerializationWrapper : ISerializable
    {
        private object _item;
        private Type _type;

        public object Item
        {
            get { return _item; }
            set
            {
                _item = value;
                _type = _item == null ? null : _item.GetType();
            }
        }

        public SerializationWrapper(object item)
        {
            _item = item;
        }

        protected SerializationWrapper(SerializationInfo info, StreamingContext context)
        {
            var typeName = info.GetString("Type");
            _type = Type.GetType(typeName);
            var xml = info.GetString("Item");
            _item = SerializeHelper.Deserialize(_type, xml);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Type", _type.AssemblyQualifiedName);
            info.AddValue("Item", SerializeHelper.Serialize(_type, Item));
        }
    }
}