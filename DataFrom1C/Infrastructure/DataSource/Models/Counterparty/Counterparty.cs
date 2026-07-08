using System.Text.Json.Serialization;

namespace DataFrom1C.Infrastructure.DataSource.Models.Counterparty
{
    public class Counterparty
    {
        [JsonPropertyName("value")]
        public CounterpartyValue[] Value { get; set; }
    }
}
