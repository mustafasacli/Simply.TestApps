using System;
using System.Runtime.Serialization;

namespace Mst.Project.Dtos
{
    [DataContract]
    public class PaymentsDto
    {
        [DataMember]
        public int CustomerNumber
        { get; set; }

        [DataMember]
        public string CheckNumber
        { get; set; }

        [DataMember]
        public DateTime PaymentDate
        { get; set; }

        [DataMember]
        public decimal Amount
        { get; set; }
    }
}