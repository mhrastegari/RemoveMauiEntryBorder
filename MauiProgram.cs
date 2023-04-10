using Microsoft.Extensions.Logging;
#if ANDROID
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
#endif

namespace RemoveMauiEntryBorder;

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

        // Remove Entry control underline
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("CustomEntry", (handler, view) =>
        {
#if IOS || MACCATALYST
            handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif ANDROID
            handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToAndroid());
#endif
        });

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
