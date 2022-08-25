using System.Runtime.Serialization;

namespace Mst.Project.Dtos
{
    [DataContract]
    public class ProductsDto
    {
        [DataMember]
        public string ProductCode
        { get; set; }

        [DataMember]
        public string ProductName
        { get; set; }

        [DataMember]
        public string ProductLine
        { get; set; }

        [DataMember]
        public string ProductScale
        { get; set; }

        [DataMember]
        public string ProductVendor
        { get; set; }

        [DataMember]
        public string ProductDescription
        { get; set; }

        [DataMember]
        public short QuantityInStock
        { get; set; }

        [DataMember]
        public decimal BuyPrice
        { get; set; }

        [DataMember]
        public decimal Msrp
        { get; set; }
    }
}