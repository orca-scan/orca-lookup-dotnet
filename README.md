# orca-lookup-dotnet

This open source project is a an example of [how to scan barcodes using a smartphone](https://orcascan.com/mobile) and [present data from your system](https://orcascan.com/docs/api/lookup-url) using C# and the [ASP.NET Core](https://dotnet.microsoft.com/learn/aspnet/what-is-aspnet-core) framework.

**How it works:**

1. A user [scans a barcode](https://orcascan.com/mobile) using their smartphone
2. Orca Scan sends a HTTP GET request to your endpoint with `?barcode=value`
3. Your system queries a database or internal API for a `barcode` match
4. Your system returns the data in JSON format with keys matching column names
5. The [Orca Scan mobile](https://orcascan.com/mobile) app presents that data to the user

*If the mobile user has [update permission](https://orcascan.com/docs/getting-started/adding-users#selecting-user-permissions) and saves the data, it will saved to your Orca sheet.*

## Install

First ensure you have [.NET Core 3.1](https://dotnet.microsoft.com/learn/aspnet/hello-world-tutorial/install) installed.

```bash
# should return 3.1.402 or similar
dotnet --version
```

Then execute the following:

```bash
# download this example code
git clone https://github.com/orca-scan/orca-lookup-dotnet.git

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

Visit [http://localhost:5000?barcode=4S3BMHB68B3286050](http://localhost:5000?barcode=4S3BMHB68B3286050) to see the following:

```json
{
    "VIN": "4S3BMHB68B3286050",
    "Make": "SUBARU",
    "Model": "Legacy",
    "Manufacturer Name": "FUJI HEAVY INDUSTRIES U.S.A",
    "Vehicle Type": "PASSENGER CAR",
    "Year": 1992
}
```

## How this example works

This project is broken into two parts a [controller](/Controllers/OrcaLookupController.cs) to handle the incoming request:

```csharp
[HttpGet]
public JsonResult Get()
{
    // get the incoming barcode sent from Orca Scan (scanned by a user)
    string barcode = HttpContext.Request.Query["barcode"].ToString();

    // TODO: query a database or API to retrieve some data

    // hydrate model with data from data source
    var result = new OrcaLookupModel(){
        Vin = barcode,
        Make = "SUBARU",
        Model = "Legacy",
        ManufacturerName = "FUJI HEAVY INDUSTRIES U.S.A",
        VehicleType = "PASSENGER CAR",
        Year = 1992
    };

    // return data to Orca as a JSON object
    return new JsonResult(result);
}
```

And a [model](/Models/OrcaLookupModel.cs) used to return data to Orca Scan in a structure that matches your sheet:

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

## Troubleshooting

If you run into any issues not listed here, please [open a ticket](https://github.com/orca-scan/orca-lookup-dotnet/issues) and we'll get back to you as soon as we can.

* **The current .NET SDK does not support targeting .NET Core 3.1**
  This example uses [.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1), upgrade and try again.


## Contributing

To contribute simply:

1. Fork it!
2. Create your feature branch: `git checkout -b my-new-feature`
3. Commit your changes: `git commit -m 'Add some feature'`
4. Push to the branch: `git push origin my-new-feature`
5. Submit a pull request

## History

For change-log, check [releases](https://github.com/orca-scan/orca-lookup-dotnet/releases).

## License

Licensed under [MIT License](LICENSE) &copy; [Orca Scan](https://orcascan.com)
