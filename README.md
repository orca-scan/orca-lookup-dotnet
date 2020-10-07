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

## Run

```bash
# start the project
dotnet run
```

Open your browser at [http://localhost:5001](http://localhost:5001) to interact with the controller.

## Troubleshooting

**The current .NET SDK does not support targeting .NET Core 3.1**

This example uses [.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1), upgrade and try again.

