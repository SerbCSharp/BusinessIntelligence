using System.Text.Json.Serialization;

namespace DataFrom1C.Infrastructure.DataSource.Models.Nomenclature
{
    public class Nomenclature
    {
        [JsonPropertyName("value")]
        public NomenclatureValue[] Value { get; set; }
    }
}
