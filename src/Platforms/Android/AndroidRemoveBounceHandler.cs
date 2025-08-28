using Android.Views;
using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace Opx.Blazor.Maui.Tools.Platforms.Android
{
	public class AndroidRemoveBounceHandler : BlazorWebViewHandler
	{
		//protected override void ConnectHandler(global::Android.Webkit.WebView platformView)
		//{
		//	base.ConnectHandler(platformView);
		//	platformView.OverScrollMode = OverScrollMode.Never;
		//}

		protected override void ConnectHandler(global::Android.Webkit.WebView platformView)
		{
			
			base.ConnectHandler(platformView);
			platformView.OverScrollMode = OverScrollMode.Never;
		}

	}
}