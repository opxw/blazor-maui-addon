#if ANDROID
using CommunityToolkit.Maui;
using Opx.Blazor.Maui.Tools.Platforms.Android;
using Opx.Blazor.Maui.Tools.Toolkit;
#elif IOS
using Opx.Blazor.Maui.Tools.Platforms.iOS;
#endif

namespace Opx.Blazor.Maui.Tools
{
	public static class SetupExtension
	{
		public static void RegisterBlazorMaui(this MauiAppBuilder builder)
		{
#if ANDROID
			builder.Services.AddSingleton<IDeviceInfoService, AndroidDeviceInfoService>();
#elif IOS
			builder.Services.AddSingleton<IDeviceInfoService, iOSDeviceInfoService>();
#endif
		}

		public static MauiApp AddBlazorToolkit(this MauiApp b)
		{
			ToolkitServices.Initialize(b.Services);
			return b;
		}
	}
}
