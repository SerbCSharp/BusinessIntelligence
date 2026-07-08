using System.Text.Json.Serialization;

namespace DataFrom1C.Infrastructure.DataSource.Models.ReceiptGoodsServices
{
    public class ReceiptGoodsServicesValue
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
        public GoodAndService[] Goods { get; set; }

        [JsonPropertyName("Услуги")]
        public GoodAndService[] Services { get; set; }
    }
}
