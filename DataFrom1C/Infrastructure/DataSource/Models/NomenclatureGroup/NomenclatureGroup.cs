using System.Text.Json.Serialization;

namespace DataFrom1C.Infrastructure.DataSource.Models.NomenclatureGroup
{
    public class NomenclatureGroup
    {
        [JsonPropertyName("value")]
        public NomenclatureGroupValue[] Value { get; set; }
    }
}
