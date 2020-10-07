using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace OrcaLookupDotNet.Controllers
{
    [ApiController]
    [Route("/")]
    [Produces("application/json")]
    public class OrcaLookupController : ControllerBase
    {
        // Model that mimics the structure of an Orca Sheet
        // This will be serialises as JSON
        // (JSON property names must match orca sheet column names!)
        private class OrcaLookupResult {

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

        [HttpGet]
        public IActionResult Get()
        {
            // get the incoming barcode sent from Orca Scan (scanned by a user)
            string barcode = HttpContext.Request.Query["barcode"].ToString();

            // TODO: query a database or API to retrive some data
            
            // hydrate model with data from data source
            var result = new OrcaLookupResult(){
                Vin = "4S3BMHB68B3286050",
                Make = "SUBARU",
                Model = "SUBARU",
                ManufacturerName = "FUJI HEAVY INDUSTRIES U.S.A",
                VehicleType = "PASSENGER CAR",
                Year = 1992
            };

            // return data to Orca as a JSON object (JSON property names must match orca sheet column names!)
            return new JsonResult(result);
        }
    }
}
