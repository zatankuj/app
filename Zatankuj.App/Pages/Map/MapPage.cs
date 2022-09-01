using Mapsui;
using Mapsui.Projections;
using Mapsui.UI.Maui;

namespace Zatankuj.App.Pages.Map;

public sealed class MapPage : ContentPage
{
    private readonly MapControl _mapControl = new ();
    
    public MapPage()
    {
        Shell.SetNavBarIsVisible(this, false);
        _mapControl.Map?.Layers.Add(Mapsui.Tiling.OpenStreetMap.CreateTileLayer());

        Content = _mapControl;
    }

    protected override async void OnAppearing()
    {
        await SetLocation();
    }

    private async Task SetLocation()
    {
        var location = await GetCurrentLocationAsync();
        var (x, y) = SphericalMercator.FromLonLat(location!.Longitude, location!.Latitude);
        _mapControl.Navigator?.NavigateTo(center: new MPoint(x, y), 100d);
    }

    private static async Task<Location> GetCurrentLocationAsync()
    {
        var cancelTokenSource = new CancellationTokenSource();
        var location = await Geolocation.Default.GetLocationAsync(
            new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10)), cancelTokenSource.Token);

        return location;
    }
}