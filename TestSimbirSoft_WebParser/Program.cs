namespace TestSimbirSoft_WebParser
{
	class Program
	{
		static void Main(string[] args)
		{

			while (true)
			{
				var fileWorker = new FileWorkeWithConsole();
				fileWorker.SaveFileResult(fileWorker.FileResult);
				fileWorker.ShowStatistics();

				if (fileWorker.IsStopWork())
					break;
			}
		}
	}
}
