using System.Text.Json.Serialization;

namespace DataFrom1C.Infrastructure.DataSource.Models.ContractCounterparties
{
    public class ContractCounterparties
    {
        [JsonPropertyName("value")]
        public ContractCounterpartiesValue[] Value { get; set; }
    }
}
