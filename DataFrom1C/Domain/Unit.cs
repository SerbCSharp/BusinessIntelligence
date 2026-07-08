using System.ComponentModel.DataAnnotations;

namespace DataFrom1C.Domain
{
    public class Unit
    {
        [Key]
        public string UnitId { get; set; }
        public string Name { get; set; }
    }
}
