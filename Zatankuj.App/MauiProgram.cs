using SkiaSharp.Views.Maui.Controls.Hosting;
using Zatankuj.App.Pages.Map;

namespace Zatankuj.App;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseSkiaSharp()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddTransient<MapPage>();
        builder.Services.AddTransient<MapPageViewModel>();

        return builder.Build();
    }
}