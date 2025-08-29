namespace Opx.Blazor.Maui.Tools.Toolkit
{
	public static class ToolkitSetup
	{
		public static MauiAppBuilder RegisterBlazorMauiToolkit(this MauiAppBuilder builder)
		{
			builder.Services.AddSingleton<ToastShowProvider>();
			builder.Services.AddSingleton<SnackbarShowProvider>();

			return builder;
		}
	}
}