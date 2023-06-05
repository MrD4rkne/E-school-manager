using ESchoolManager.App.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ESchoolManager.App.Common
{
    public class Settings
    {
        [DataMember]
        public SerializerType SerializerType;

        public Settings()
        {
            SerializerType = SerializerType.XML;
        }

        public Settings(SerializerType serializerType)
        {
            SerializerType = serializerType;
        }
    }
}
