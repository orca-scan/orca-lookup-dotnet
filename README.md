# orca-lookup-dotnet

Quick example of how to respond to an [Orca Lookup URL](https://orcascan.com/docs/api/lookup-url) request in C# AspNetCore.

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

