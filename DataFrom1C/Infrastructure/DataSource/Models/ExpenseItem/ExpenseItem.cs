using System.Text.Json.Serialization;

namespace DataFrom1C.Infrastructure.DataSource.Models.ExpenseItem
{
    public class ExpenseItem
    {
        [JsonPropertyName("value")]
        public ExpenseItemValue[] Value { get; set; }
    }
}
