using System.Text.Json.Serialization;

namespace DataFrom1C.Infrastructure.DataSource.Models.ImplementationConstructionWorks
{
    public class ImplementationConstructionWorks
    {
        [JsonPropertyName("value")]
        public ImplementationConstructionWorksValue[] Value { get; set; }
    }
}
