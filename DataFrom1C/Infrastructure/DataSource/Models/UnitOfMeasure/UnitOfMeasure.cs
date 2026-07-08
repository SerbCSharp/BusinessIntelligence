using System.Text.Json.Serialization;

namespace DataFrom1C.Infrastructure.DataSource.Models.UnitOfMeasure
{
    public class UnitOfMeasure
    {
        [JsonPropertyName("value")]
        public UnitOfMeasureValue[] Value { get; set; }
    }
}
