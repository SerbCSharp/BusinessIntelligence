using System.Text.Json.Serialization;

namespace DataFrom1C.Infrastructure.DataSource.Models.AdditionalInformation
{
    public class AdditionalInformation
    {
        [JsonPropertyName("value")]
        public AdditionalInformationValue[] Value { get; set; }
    }
}
