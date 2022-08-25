using System;
using System.Runtime.Serialization;

namespace Mst.Project.Dtos
{
    [DataContract]
    public class OrdersDto
    {
        [DataMember]
        public int OrderNumber
        { get; set; }

        [DataMember]
        public DateTime OrderDate
        { get; set; }

        [DataMember]
        public DateTime RequiredDate
        { get; set; }

        [DataMember]
        public DateTime? ShippedDate
        { get; set; }

        [DataMember]
        public string Status
        { get; set; }

        [DataMember]
        public string Comments
        { get; set; }

        [DataMember]
        public int CustomerNumber
        { get; set; }
    }
}