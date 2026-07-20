using System.ComponentModel.DataAnnotations;

namespace DataFrom1C.Domain
{
    public class CostItem
    {
        [Key]
        public string CostItemId { get; set; }
        public string Name { get; set; }
    }
}
