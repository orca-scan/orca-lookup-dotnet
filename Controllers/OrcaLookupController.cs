using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using OrcaLookupDotNet.Models;

namespace OrcaLookupDotNet.Controllers
{
    [ApiController]
    [Route("/")]
    [Produces("application/json")]
    public class OrcaLookupController : ControllerBase
    {

        [HttpGet]
        public JsonResult Get()
        {
            // get the incoming barcode sent from Orca Scan (scanned by a user)
            string barcode = HttpContext.Request.Query["barcode"].ToString();

            // TODO: query a database or API to retrieve some data
            
            // hydrate model (property names must match column names when serialised)
            var result = new OrcaLookupModel(){
                Vin = barcode,
                Make = "SUBARU",
                Model = "Legacy",
                ManufacturerName = "FUJI HEAVY INDUSTRIES U.S.A",
                VehicleType = "PASSENGER CAR",
                Year = 1992
            };

            // return data to Orca as a JSON object (JSON property names must match orca sheet column names!)
            return new JsonResult(result);
        }
    }
}
