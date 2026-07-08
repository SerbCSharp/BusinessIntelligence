using System.ComponentModel.DataAnnotations;

namespace DataFrom1C.Domain
{
    public class Warehouse
    {
        [Key]
        public string WarehouseId { get; set; }
        public string Name { get; set; }
    }
}
