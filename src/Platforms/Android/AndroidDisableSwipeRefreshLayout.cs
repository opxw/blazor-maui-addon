using Android.Content;
using Microsoft.Maui.Platform;

namespace Opx.Blazor.Maui.Tools.Platforms.Android
{
	public class AndroidDisableSwipeRefreshLayout : MauiSwipeRefreshLayout
	{
		public AndroidDisableSwipeRefreshLayout(Context context) : base(context)
		{
		}

		public bool DisableRefresh { get; set; } = false;

		public override bool CanChildScrollUp()
		{
			if (DisableRefresh)
				return true;

			return base.CanChildScrollUp();
		}
	}
}
