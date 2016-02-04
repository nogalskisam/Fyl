using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Fyl.Utilities
{
    public class SerialisationHelper
    {
        public static string DataContractSerialise(object obj)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                DataContractSerializer serializer = new DataContractSerializer(obj.GetType());
                serializer.WriteObject(memoryStream, obj);
                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
        }

        public static T DataContractDeserialise<T>(string xml)
        {
            using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                DataContractSerializer dcs =
                    new DataContractSerializer(typeof(T));
                return (T)dcs.ReadObject(reader);
            }
        }
    }
}
