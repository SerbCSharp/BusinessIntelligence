using System.Text.Json.Serialization;

namespace DataFrom1C.Infrastructure.DataSource.Models.AdditionalInformation
{
    public class AdditionalInformationValue
    {
        [JsonPropertyName("Объект")]
        public string ObjectId { get; set; }

        [JsonPropertyName("Значение")]
        public string ObjectValue { get; set; }

        [JsonPropertyName("Значение_Type")]
        public string ValueType { get; set; }
    }
}
