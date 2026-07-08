using System.Text.Json.Serialization;

namespace DataFrom1C.Infrastructure.DataSource.Models.SaleGoodsServices
{
    public class SaleGoodsServices
    {
        [JsonPropertyName("value")]
        public SaleGoodsServicesValue[] Value { get; set; }
    }
}
