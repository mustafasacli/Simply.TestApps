using System.Runtime.Serialization;

namespace Mst.Project.Dtos
{
    [DataContract]
    public class EmployeesDto
    {
        [DataMember]
        public int EmployeeNumber
        { get; set; }

        [DataMember]
        public string LastName
        { get; set; }

        [DataMember]
        public string FirstName
        { get; set; }

        [DataMember]
        public string Extension
        { get; set; }

        [DataMember]
        public string Email
        { get; set; }

        [DataMember]
        public string OfficeCode
        { get; set; }

        [DataMember]
        public int? ReportsTo
        { get; set; }

        [DataMember]
        public string JobTitle
        { get; set; }
    }
}