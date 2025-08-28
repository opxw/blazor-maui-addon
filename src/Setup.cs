#if ANDROID
using CommunityToolkit.Maui;
using Microsoft.AspNetCore.Components.WebView.Maui;
using Opx.Blazor.Maui.Tools.Platforms.Android;
#elif IOS
using Opx.Blazor.Maui.Tools.Platforms.iOS;
#endif

namespace Opx.Blazor.Maui.Tools
{
	public class AppViewSetting
	{
		private MauiAppBuilder _builder;

		public AppViewSetting(MauiAppBuilder builder)
		{
			_builder = builder;
		}
	}

	public static class SetupExtension
	{
		public static void RegisterMauiTools(this MauiAppBuilder builder)
		{
#if ANDROID
			builder.Services.AddSingleton<IDeviceInfoService, AndroidDeviceInfoService>();
#elif IOS
			builder.Services.AddSingleton<IDeviceInfoService, iOSDeviceInfoService>();
#endif
		}

		public static AppViewSetting ViewSettings(this MauiAppBuilder b)
		{
			return new AppViewSetting(b);
		}
	}
}
