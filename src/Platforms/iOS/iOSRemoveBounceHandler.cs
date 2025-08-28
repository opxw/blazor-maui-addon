using Microsoft.AspNetCore.Components.WebView.Maui;
using WebKit;

namespace Opx.Blazor.Maui.Tools.Platforms.iOS
{
	public class iOSRemoveBounceHandler : BlazorWebViewHandler
	{
		protected override void ConnectHandler(WKWebView platformView)
		{
			base.ConnectHandler(platformView);

			platformView.ScrollView.Bounces = false;
		}
	}
}
