using System.Text.Json.Serialization;

namespace DataFrom1C.Infrastructure.DataSource.Models.CreditToCurrentAccount
{
    public class CreditToCurrentAccount
    {
        [JsonPropertyName("value")]
        public CreditToCurrentAccountValue[] Value { get; set; }
    }
}
