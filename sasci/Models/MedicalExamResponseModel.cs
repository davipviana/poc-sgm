using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SASCi.Models
{
    [DataContract]
    public class MedicalExamResponseModel
    {
        [DataMember]
        public float FloatProperty { get; set; }

        [DataMember]
        public string StringProperty { get; set; }
    }
}