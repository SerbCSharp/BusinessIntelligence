using System.ComponentModel.DataAnnotations;

namespace DataFrom1C.Domain
{
    public class MoreInformation
    {
        [Key]
        public Guid RowId { get; set; }
        public string ObjectId { get; set; }
        public string ObjectValue { get; set; }
        public string ValueType { get; set; }
    }
}
