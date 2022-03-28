$rentalAppWebApiDir = $PSScriptRoot.Substring(0, $PSScriptRoot.LastIndexOf("\"))

dotnet run --project $rentalAppWebApiDir\RentalApp\RentalApp.WebApi\RentalApp.WebApi.csproj