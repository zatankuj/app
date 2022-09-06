using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Zatankuj.App.Pages.Map;

public partial class MapPageViewModel : ObservableObject
{
    public MapPageViewModel()
    {
        cords = (18.924788276875038, 52.155439971661785);
    }
    
    [ObservableProperty]
    public (double, double) cords;

    [ObservableProperty] 
    public (double, double) locationCords;

    [RelayCommand]
    public async Task SetCurrentLocation()
    {
        var cancelTokenSource = new CancellationTokenSource();
        var location = await Geolocation.Default.GetLocationAsync(
            new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10)), cancelTokenSource.Token);

        locationCords = (location!.Latitude, location!.Longitude);
    }
}