using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Entity
{
    [DataContract]
    public class EntityAdmin
    {
        /// <summary>
        /// Id
        /// </summary>
       // [DataField("Id")]
       // [DataMember]
       [DataMember]
        public int id { get; set; }

        /// <summary>
        /// Id
        /// </summary>
       // [DataField("Id")]
        [DataMember]
        public string username { get; set; }

        /// <summary>
        /// Id
        /// </summary>
       // [DataField("Id")]
        [DataMember]
        public string userpwd { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        //[DataField("Id")]
       [DataMember]
        public string name { get; set; }

        /// <summary>
        /// Id
        /// </summary>
       // [DataField("Id")]
        [DataMember]
        public string sex { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        //[DataField("Id")]
        [DataMember]
        public string tel { get; set; }

        [DataMember]
        public Enum EnumState { get; set; }

    }
}
