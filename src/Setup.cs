#if ANDROID
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
			_builder.ConfigureMauiHandlers(h =>
			{
#if ANDROID
				h.AddHandler<RefreshView, AndroidRefreshViewHandler>();
#endif
			});
		}

		public AppViewSetting RemoveBounce()
		{
#if ANDROID
			_builder.ConfigureMauiHandlers(h =>
			{
				h.AddHandler<RefreshView, AndroidRefreshViewHandler>();
				h.AddHandler<BlazorWebView, AndroidRemoveBounceHandler>();
			});
#elif IOS
				_builder.ConfigureMauiHandlers(h =>
				{
					h.AddHandler<CollectionView, iOSRemoveBounceHandler>();
				});
#endif

			return this;
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
