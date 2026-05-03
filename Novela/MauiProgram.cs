using Microsoft.Extensions.Logging;
using Novela.Resources.Pages.Authentication;
using Novela.Resources.Pages.Book;
using Microsoft.Maui.Handlers;
using CommunityToolkit.Maui;


namespace Novela;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureMauiHandlers(handlers =>
            {
#if ANDROID
                PickerHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
                {
                    handler.PlatformView.Background = null;
                });
#endif
            })
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Sunborn-One.ttf", "Sunborn-One");
            });
        
        // Pages
        builder.Services.AddSingleton<AppShell>();
        builder.Services.AddTransient<Novela_Auth>();
        builder.Services.AddTransient<Novela_Dashboard>();
        
        // Services

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}