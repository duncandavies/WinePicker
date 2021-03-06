using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace WinePicker.Shared.Models
{
    [BsonIgnoreExtraElements]
    public class WineModel
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public string Variety { get; set; }
        [JsonPropertyName("Volume")]
        [BsonElement("Volume")]
        public double Volume_ml { get; set; }
        public double AlcholContent { get; set; }
    }
}