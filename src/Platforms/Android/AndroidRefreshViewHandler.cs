using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace Opx.Blazor.Maui.Tools.Platforms.Android
{
	public class AndroidRefreshViewHandler : RefreshViewHandler
	{
		protected override MauiSwipeRefreshLayout CreatePlatformView()
		{
			return new AndroidDisableSwipeRefreshLayout(Context);
		}
	}
}