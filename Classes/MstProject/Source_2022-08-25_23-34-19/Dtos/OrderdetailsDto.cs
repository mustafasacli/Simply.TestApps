using SimpleInfra.Dto.Core;
using System.Runtime.Serialization;

namespace Mst.Project.Dtos
{
    [DataContract]
    public class OrderdetailsDto : SimpleBaseDto
    {
        [DataMember]
        public int OrderNumber
        { get; set; }

        [DataMember]
        public string ProductCode
        { get; set; }

        [DataMember]
        public int QuantityOrdered
        { get; set; }

        [DataMember]
        public decimal PriceEach
        { get; set; }

        [DataMember]
        public short OrderLineNumber
        { get; set; }
    }
}