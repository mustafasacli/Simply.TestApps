using System.Runtime.Serialization;

namespace Mst.Project.Dtos
{
    [DataContract]
    public class CustomersDto
    {
        [DataMember]
        public int CustomerNumber
        { get; set; }

        [DataMember]
        public string CustomerName
        { get; set; }

        [DataMember]
        public string ContactLastName
        { get; set; }

        [DataMember]
        public string ContactFirstName
        { get; set; }

        [DataMember]
        public string Phone
        { get; set; }

        [DataMember]
        public string AddressLine1
        { get; set; }

        [DataMember]
        public string AddressLine2
        { get; set; }

        [DataMember]
        public string City
        { get; set; }

        [DataMember]
        public string State
        { get; set; }

        [DataMember]
        public string PostalCode
        { get; set; }

        [DataMember]
        public string Country
        { get; set; }

        [DataMember]
        public int? SalesRepEmployeeNumber
        { get; set; }

        [DataMember]
        public decimal? CreditLimit
        { get; set; }
    }
}