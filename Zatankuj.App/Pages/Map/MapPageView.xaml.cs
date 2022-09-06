using Mapsui;
using Mapsui.Projections;
using Mapsui.Tiling;
using Mapsui.UI.Maui;

namespace Zatankuj.App.Pages.Map;

public partial class MapPage : ContentPage
{
    public MapPage(MapPageViewModel vm)
    {
        InitializeComponent();
        Shell.SetNavBarIsVisible(this, false);
        BindingContext = vm;
        MapView.Map?.Layers.Add(OpenStreetMap.CreateTileLayer());
    }

    private void SetLocation()
    {
        var model = (MapPageViewModel)BindingContext;
        var (x, y) = SphericalMercator.FromLonLat(model.cords.Item1, model.cords.Item2);
        MapView.Navigator?.NavigateTo(new MPoint(x, y), 3000d);
    }

    private void SetMyLocation((double, double) location)
    {
        MapView.MyLocationLayer.UpdateMyLocation(new Position(location.Item1, location.Item2));
    }

    private async void MapComponentLoaded(object sender, EventArgs e)
    {
        SetLocation();
        var vm = (MapPageViewModel)BindingContext;
        await vm.SetCurrentLocation();
        SetMyLocation(vm.locationCords);
    }
}