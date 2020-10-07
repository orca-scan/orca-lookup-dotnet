# orca-lookup-dotnet

An [Orca Scan Lookup URL](https://orcascan.com/docs/api/lookup-url) is the easiest way to connect Orca Scan to your data.

Each time a user scans a barcode from the Orca Scan mobile app, Orca will send a request to the endpoint that you provide and pass the barcode value as a Query String `?barcode=0123456`.

You can use the barcode value to query your database and return data to the Orca Scan mobile app.

This project is a quick example of how to accept and respond to a [Barcode Lookup](https://orcascan.com/docs/api/lookup-url) request in C# using [ASP.NET Core](https://dotnet.microsoft.com/learn/aspnet/what-is-aspnet-core).

## Install

```bash
# download this example code
git clone git@github.com:orca-scan/orca-lookup-dotnet.git

# go into the new directory
cd orca-lookup-dotnet

# install dependencies
dotnet restore
```

## Run

```bash
# start the project
dotnet run
```

## How it works

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

    // return data to Orca as a JSON object
    return new JsonResult(result);
}
```

[OrcaLookupModel](/Models/OrcaLookupModel.cs) is an example model of how to respond to a lookup request:

```csharp
// IMPORTANT: JSON property names must match Orca sheet column names when serialised
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

Open your browser at [http://localhost:5001](http://localhost:5001) to interact with the controller.

## Troubleshooting

**The current .NET SDK does not support targeting .NET Core 3.1**

This example uses [.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1), upgrade and try again.

## Reporting Bugs

Please raise bugs using the [issue tracker](https://github.com/orca-scan/orca-lookup-dotnet/issues) and, if possible, please provide enough information to allow the bug to be reproduced. You will be notified via GitHub once we resolve the issue.

## Contributing

Feel free to contribute, either by [raising an issue](https://github.com/orca-scan/orca-lookup-dotnet/issues) or:

1. Fork it!
2. Create your feature branch: `git checkout -b my-new-feature`
3. Commit your changes: `git commit -m 'Add some feature'`
4. Push to the branch: `git push origin my-new-feature`
5. Submit a pull request

## History

For change-log, check [releases](https://github.com/orca-scan/orca-lookup-dotnet/releases).

## License

Licensed under [MIT License](LICENSE) &copy; [Orca Scan](https://orcascan.com)
