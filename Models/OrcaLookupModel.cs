using System.Text.Json.Serialization;

namespace OrcaLookupDotNet.Models
{
    // Model that mimics the structure of an Orca Sheet
    // This will be serialises as JSON
    // (JSON property names must match orca sheet column names!)
    public class OrcaLookupModel {

        [JsonPropertyName("VIN")]
        public string Vin { get; set; }

        [JsonPropertyName("Make")]
        public string Make { get; set; }

        [JsonPropertyName("Model")]
        public string Model { get; set; }

        [JsonPropertyName("Manufacturer Name")]
        public string ManufacturerName { get; set; }

        [JsonPropertyName("Vehicle Type")]
        public string VehicleType { get; set; }

        [JsonPropertyName("Year")]
        public int Year { get; set; }
    }
}