using GestionCommandes.Maui.Services;
using GestionCommandes.Maui.ViewModels;
using GestionCommandes.Maui.Views;
using Microsoft.Extensions.Logging;

namespace GestionCommandes.Maui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // ---------- Injection de dépendances ----------
        // Services : une seule instance pour toute l'application (Singleton)
        builder.Services.AddSingleton<IDepotClients, DepotClientsFactice>();

        // Pages et ViewModels : une nouvelle instance à chaque demande (Transient)
        builder.Services.AddTransient<ClientsViewModel>();
        builder.Services.AddTransient<ClientsPage>();
        builder.Services.AddTransient<CommandeViewModel>();
        builder.Services.AddTransient<CommandePage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
