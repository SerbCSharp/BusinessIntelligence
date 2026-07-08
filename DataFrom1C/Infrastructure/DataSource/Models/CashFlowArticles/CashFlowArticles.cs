using System.Text.Json.Serialization;

namespace DataFrom1C.Infrastructure.DataSource.Models.CashFlowArticles
{
    public class CashFlowArticles
    {
        [JsonPropertyName("value")]
        public CashFlowArticlesValue[] Value { get; set; }
    }
}
