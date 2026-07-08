using System.Text.Json.Serialization;

namespace DataFrom1C.Infrastructure.DataSource.Models.ReceiptProcessing
{
    public class ReceiptProcessing
    {
        [JsonPropertyName("value")]
        public ReceiptProcessingValue[] Value { get; set; }
    }
}
