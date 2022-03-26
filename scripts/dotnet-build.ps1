$rentalAppWebApiDir = $PSScriptRoot.Substring(0, $PSScriptRoot.LastIndexOf("\"))

dotnet build $rentalAppWebApiDir\RentalApp\RentalApp.WebApi\RentalApp.WebApi.csproj