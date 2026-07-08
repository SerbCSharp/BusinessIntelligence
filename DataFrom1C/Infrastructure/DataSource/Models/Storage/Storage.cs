using System.Text.Json.Serialization;

namespace DataFrom1C.Infrastructure.DataSource.Models.Storage
{
    public class Storage
    {
        [JsonPropertyName("value")]
        public StorageValue[] Value { get; set; }
    }
}
