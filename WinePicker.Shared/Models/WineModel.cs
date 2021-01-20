using System.Text.Json.Serialization;

namespace WinePicker.Shared.Models
{
    public class WineModel
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public string Variety { get; set; }
        [JsonPropertyName("Volume")]
        public double Volume_ml { get; set; }
        public double AlcholContent { get; set; }
    }
}