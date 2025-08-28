
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opx.Blazor.Maui.Tools
{
	public static class ToolsExtension
	{
		public static void RemoveBounce(this ContentPage c)
		{
			Microsoft.AspNetCore.Components.WebView.Maui.BlazorWebViewHandler.BlazorWebViewMapper.AppendToMapping("Disable_Bounce", (handler, view) =>
			{
#if IOS
				handler.PlatformView.ScrollView.Bounces = false;
#elif ANDROID
				handler.PlatformView.OverScrollMode = Android.Views.OverScrollMode.Never;
#endif
			});
		}

		public static void FixBlazorHybrid()
		{
			Microsoft.AspNetCore.Components.WebView.Maui.BlazorWebViewHandler.BlazorWebViewMapper.AppendToMapping("Disable_Bounce", (handler, view) =>
			{
#if IOS
				handler.PlatformView.ScrollView.Bounces = false;
#elif ANDROID
				handler.PlatformView.OverScrollMode = Android.Views.OverScrollMode.Never;
#endif
			});
		}
	}
}
