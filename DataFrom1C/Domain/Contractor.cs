using System.ComponentModel.DataAnnotations;

namespace DataFrom1C.Domain
{
    public class Contractor
    {
        [Key]
        public string ContractorId { get; set; }
        public string Name { get; set; }
    }
}
