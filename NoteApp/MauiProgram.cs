using Microsoft.Extensions.Logging;
using NoteApp.Data;
using NoteApp.ViewModels;
using NoteApp.Views;

namespace NoteApp {
    public static class MauiProgram {
        public static MauiApp CreateMauiApp() {

            // Create Database
            DBContext dBContext = new DBContext();
            SQLitePCL.Batteries.Init();
            dBContext.Database.EnsureCreated();


            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts => {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<NoteView>();
            builder.Services.AddSingleton<NoteViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
