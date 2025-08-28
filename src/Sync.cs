namespace Opx.Blazor.Maui.Tools
{ 
	public static class Sync
	{
		public static readonly TaskFactory _taskFactory = new
			TaskFactory(CancellationToken.None,
						TaskCreationOptions.None,
						TaskContinuationOptions.None,
						TaskScheduler.Default);

		public static void Run(Func<Task> task)
			=> _taskFactory
				.StartNew(task)
				.Unwrap()
				.GetAwaiter()
				.GetResult();

		public static TResult Run<TResult>(Func<Task<TResult>> task)
			=> _taskFactory
				.StartNew(task)
				.Unwrap()
				.GetAwaiter()
				.GetResult();
	}
}