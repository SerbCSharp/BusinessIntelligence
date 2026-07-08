using System.Text.Json.Serialization;

namespace DataFrom1C.Infrastructure.DataSource.Models.ReceiptGoodsServices
{
    public class ReceiptGoodsServices
    {
        [JsonPropertyName("value")]
        public ReceiptGoodsServicesValue[] Value { get; set; }
    }
}
