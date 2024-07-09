using Microsoft.Extensions.Logging;
using Haulage.Database;
using Haulage.Services;

namespace Haulage;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();

        builder.Services.AddSingleton<DbContext>();
        builder.Services.AddSingleton<ICustomerServiceDatabase, CustomerServiceDatabase>();

        builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
