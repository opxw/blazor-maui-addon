using CommunityToolkit.Maui.Core;

namespace Opx.Blazor.Maui.Tools
{
	public static class Toolkit
	{
		public static async Task ToastAsync(string msg, double fontSize = 12, ToastDuration duration = ToastDuration.Short,
			CancellationToken cancellation = default)
		{
			var toast = CommunityToolkit.Maui.Alerts.Toast.Make(msg, duration, fontSize);
			await toast.Show(cancellation);
		}
	}
}