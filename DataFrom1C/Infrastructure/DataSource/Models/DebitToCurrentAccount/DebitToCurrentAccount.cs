using System.Text.Json.Serialization;

namespace DataFrom1C.Infrastructure.DataSource.Models.DebitToCurrentAccount
{
    public class DebitToCurrentAccount
    {
        [JsonPropertyName("value")]
        public DebitToCurrentAccountValue[] Value { get; set; }
    }
}
