using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using FastEnumUtility;

namespace Opx.Blazor.Maui.Tools.Toolkit
{
	public class ToolkitAlertBase
	{
		public ToolkitAlertsGlobalOptions? CheckValidOptions()
		{
			var svc = ToolkitServices.GetService<ToolkitAlertsGlobalOptions>();
			if (svc == null)
				throw new InvalidOperationException("ToolkitAlerts not initialized with valid options. Please register it in DI with valid options.");

			return svc;
		}
	}

	public class ToastShowProvider : ToolkitAlertBase
	{
		public IToast Make(string msg, double fontSize = 14, ToastDuration duration = ToastDuration.Short)
		{
			var toast = CommunityToolkit.Maui.Alerts.Toast.Make(msg, duration, fontSize);
			return toast;
		}

		public IToast MakeFromOptions(string msg)
		{
			var options = CheckValidOptions();
			var toast = this.Make(msg, options.Toast.FontSize, options.Toast.Duration);
			return toast;
		}

		public async Task Show(string msg, double fontSize = 14, ToastDuration duration = ToastDuration.Short,
			CancellationToken cancellation = default)
		{
			var toast = this.Make(msg, fontSize, duration);
			await toast.Show(cancellation);
		}

		public async Task Show2(string msg, CancellationToken cancellation = default)
		{
			var toast = this.MakeFromOptions(msg);
			await toast.Show(cancellation);
		}
	}

	public class SnackbarShowProvider : ToolkitAlertBase
	{
		public ISnackbar Make(string msg, string actionText = "OK", int duration = 2, SnackbarOptions? options = null,
			Action? action = null)
		{
			ISnackbar snackbar;
			snackbar = Snackbar.Make(msg, action != null ? () => { Task.Run(action); } : null, actionText, TimeSpan.FromSeconds(duration), options);

			return snackbar;
		}

		public ISnackbar MakeFromOptions(string msg, SnackbarStyle style = SnackbarStyle.Default, Action? action = null)
		{
			var options = CheckValidOptions();

			var htmLColor = style.GetLabel();
			if (!string.IsNullOrWhiteSpace(htmLColor))
			{
				options.Snackbar.Options.BackgroundColor = Color.FromArgb(htmLColor);
				options.Snackbar.Options.TextColor = Color.FromArgb("#fff");
			}

			ISnackbar snackbar;
			snackbar = this.Make(msg, options.Snackbar.ActionText, options.Snackbar.Duration, options.Snackbar.Options, action);

			return snackbar;
		}

		public async Task Show(string msg, string actionText = "OK",
			int duration = 2, Action? action = null, SnackbarOptions options = null, CancellationToken cancellation = default)
		{
			var snackbar = this.Make(msg, actionText, duration, options, action);

			await snackbar.Show(cancellation);
		}
		
		public async Task Show2(string msg, SnackbarStyle style = SnackbarStyle.Default, Action? action = null, CancellationToken cancellation = default)
		{
			var snackbar = this.MakeFromOptions(msg, style, action);

			await snackbar.Show(cancellation);
		}
	}

	public static class ToolkitAlerts
	{
		public static ToastShowProvider Toast()
		{
			var svc = ToolkitServices.GetService<ToastShowProvider>();
			return svc;
		}

		public static SnackbarShowProvider Snackbar()
		{
			var svc = ToolkitServices.GetService<SnackbarShowProvider>();
			return svc;
		}
	}
}