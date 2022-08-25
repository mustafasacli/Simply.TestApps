using SimpleInfra.Dto.Core;
using System.Runtime.Serialization;

namespace Mst.Project.Dtos
{
    [DataContract]
    public class OfficesDto : SimpleBaseDto
    {
        [DataMember]
        public string OfficeCode
        { get; set; }

        [DataMember]
        public string City
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
        public string State
        { get; set; }

        [DataMember]
        public string Country
        { get; set; }

        [DataMember]
        public string PostalCode
        { get; set; }

        [DataMember]
        public string Territory
        { get; set; }
    }
}