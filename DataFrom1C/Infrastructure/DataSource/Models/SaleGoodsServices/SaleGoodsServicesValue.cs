using System.Text.Json.Serialization;

namespace DataFrom1C.Infrastructure.DataSource.Models.SaleGoodsServices
{
    public class SaleGoodsServicesValue
    {
        [JsonPropertyName("Ref_Key")]
        public string DocumentId { get; set; }
        public DateTime Date { get; set; }

        [JsonPropertyName("СуммаДокумента")]
        public decimal Amount { get; set; }

        [JsonPropertyName("ДоговорКонтрагента_Key")]
        public string ContractId { get; set; }

        [JsonPropertyName("Склад_Key")]
        public string WarehouseId { get; set; }

        [JsonPropertyName("Товары")]
        public GoodAndService[] GoodsAndServices { get; set; }
    }
}
