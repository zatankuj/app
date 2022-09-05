using Mapsui;
using Mapsui.Projections;

namespace Zatankuj.App.Pages.Map;

public partial class MapPage : ContentPage
{
    public MapPage(MapPageViewModel vm)
    {
        InitializeComponent();
        Shell.SetNavBarIsVisible(this, false);
        BindingContext = vm;    
        MapView.Map?.Layers.Add(Mapsui.Tiling.OpenStreetMap.CreateTileLayer());
    }
    
    private void SetLocation()
    {
        var model = (MapPageViewModel)BindingContext;
        var (x, y) = SphericalMercator.FromLonLat(model.cords.Item1, model.cords.Item2);
        MapView.Navigator?.NavigateTo(center: new MPoint(x, y), 3000d);
    }

    private void MapComponentLoaded(object sender, EventArgs e)
    {
        SetLocation();
    }
}