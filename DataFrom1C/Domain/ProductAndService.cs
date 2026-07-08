using System.ComponentModel.DataAnnotations;

namespace DataFrom1C.Domain
{
    public class ProductAndService
    {
        [Key]
        public string ProductAndServiceId { get; set; }
        public string Name { get; set; }
    }
}
