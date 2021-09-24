#Enable Secret Storage

- On package manager console, under default project: WeatherChecker.Presentation type the following in order:

1. dotnet user-secrets init --project "WeatherChecker.Presentation"
2. dotnet user-secrets set "APIAccessKey:key" "28a507215a59a0db892ffd65e6a5fdec" --project "WeatherChecker.Presentation"

In that way, we can use user secrets. Thanks!
