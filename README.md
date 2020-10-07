# orca-lookup-dotnet

An Orca Scan Lookup URL is the easiest way to connect Orca Scan to your data.

Each time a user scans a barcode from the Orca Scan mobile app, Orca will send a request to the endpoint that you provide and pass the barcode value as a Query String `?barcode=0123456`.

You can use the barcode value to query your database and return data to the Orca Scan mobile app.

This project is a quick example of how to accept and respond to an [Orca Lookup URL](https://orcascan.com/docs/api/lookup-url) request in C# AspNetCore.

## Install

```bash
# download this example code
git clone git@github.com:orca-scan/orca-lookup-dotnet.git

# go into the new directory
cd orca-lookup-dotnet

# install dependencies
dotnet restore
```

## Usage

[OrcaLookupController](/Controllers/OrcaLookupController.cs) is an example of how to process an incoming request:

```csharp
[HttpGet]
public IActionResult Get()
{
    // get the incoming barcode sent from Orca Scan (scanned by a user)
    string barcode = HttpContext.Request.Query["barcode"].ToString();

    // TODO: query a database or API to retrieve some data

    // hydrate model with data from data source
    var result = new OrcaLookupModel(){
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
```

[OrcaLookupModel](/Models/OrcaLookupModel.cs) is an example model of how to respond to a lookup request:

```csharp
// IMPORTANT: Model must mimics the structure of an Orca Sheet when serialised
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
```

## Run

```bash
# start the project
dotnet run
```

Open your browser at [http://localhost:5001](http://localhost:5001) to interact with the controller.

## Troubleshooting

**The current .NET SDK does not support targeting .NET Core 3.1**

This example uses [.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1), upgrade and try again.

