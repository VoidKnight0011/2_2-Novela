using Microsoft.Extensions.Logging;
using Novela.Resources.Pages.Authentication;
using Novela.Resources.Pages.Book;
using Microsoft.Maui.Handlers;
using CommunityToolkit.Maui;
using UXDivers.Popups.Maui;


namespace Novela;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseUXDiversPopups()
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
                fonts.AddFont("Poppins-Light.ttf", "Poppins-Light");
                fonts.AddFont("Poppins-Regular.ttf", "Poppins-Regular");
                fonts.AddFont("Poppins-Black.ttf", "Poppins-Black");
            });
        
        // Pages
        builder.Services.AddSingleton<AppShell>();
        builder.Services.AddTransient<Novela_Auth>();
        builder.Services.AddTransient<Novela_Dashboard>();
        
            // Edit Book Pages
            builder.Services.AddTransient<Novela_Overview>();
            builder.Services.AddTransient<Novela_Characters>();
            builder.Services.AddTransient<Novela_Timeline>();
            builder.Services.AddTransient<Novela_Manuscript>();
            builder.Services.AddTransient<Novela_Appendices>();
        
        // Services

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}