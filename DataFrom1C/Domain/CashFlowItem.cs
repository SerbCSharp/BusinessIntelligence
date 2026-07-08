using System.ComponentModel.DataAnnotations;

namespace DataFrom1C.Domain
{
    public class CashFlowItem
    {
        [Key]
        public string CashFlowItemId { get; set; }
        public string Name { get; set; }
    }
}
