using System.Text.Json.Serialization;

namespace DataFrom1C.Infrastructure.DataSource.Models.ImplementationConstructionWorks
{
    public class ImplementationConstructionWorksValue
    {
        [JsonPropertyName("Ref_Key")]
        public string DocumentId { get; set; }
        public DateTime Date { get; set; }

        [JsonPropertyName("СуммаДокумента")]
        public decimal Amount { get; set; }

        [JsonPropertyName("ДоговорКонтрагента_Key")]
        public string ContractId { get; set; }
    }
}
