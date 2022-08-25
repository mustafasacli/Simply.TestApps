using SimpleInfra.Dto.Core;
using System.Runtime.Serialization;

namespace Mst.Project.Dtos
{
    [DataContract]
    public class ProductlinesDto : SimpleBaseDto
    {
        [DataMember]
        public string ProductLine
        { get; set; }

        [DataMember]
        public string TextDescription
        { get; set; }

        [DataMember]
        public string HtmlDescription
        { get; set; }

        [DataMember]
        public byte[] Image
        { get; set; }
    }
}