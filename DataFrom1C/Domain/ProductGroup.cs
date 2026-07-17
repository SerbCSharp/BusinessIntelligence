using System.ComponentModel.DataAnnotations;

namespace DataFrom1C.Domain
{
    public class ProductGroup
    {
        [Key]
        public string ProductGroupId { get; set; }
        public string Name { get; set; }
    }
}
