using HtmlAgilityPack;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace TestSimbirSoft_WebParser
{
	public class FileWorkeWithConsole : FileHelper, IStatistics
	{
		public const string EXTENSION_FILE = ".html";
		public readonly string[] SEPARATORS = { " ", ",", ".", "! ", "?", "\"", ";", ":", "[", "]", "(", ")", "\n", "\r", "\t" };

		public string Uri { get; set; }
		public string FileResult { get; set; }

		public FileWorkeWithConsole() : base()
		{
			Uri = GetLinkToHttp();
			FileResult = (string)GetContentResult();
		}

		//Данный метод не стал выносить в FileHelper, так как мне показалось, что он не может быть
		//общим и нужен скорее только в рамках этого класса
		/// <summary>
		/// Возвращает ссылку на сайт
		/// </summary>
		/// <returns></returns>
		public string GetLinkToHttp()
		{
			Console.Write("Введите ссылку веб сайта: ");
			string link = Console.ReadLine();
			return link;
		}


		public override object GetContentResult()
		{
			using (var client = new HttpClient())
			using (var responce = client.GetAsync(Uri).Result)
			using (var content = responce.Content)
			{
				return content.ReadAsStringAsync().Result;
			}
		}

		public override string GetPathToSaveFile()
		{
			Console.Write("Введите путь до директории, затем через пробел название будущего файла(Пример D:/ fileName): ");
			var path = Console.ReadLine().Split(' ');
			if (path.Length < 2 || path.Any(c => string.IsNullOrEmpty(c)))
				throw new Exception("Вы ввели не все значения или оставили их пустыми");

			return Path.Combine(path[0], GetFileNameWithExtension(path[1]));
		}

		public override bool IsStopWork()
		{
			Console.Write("Нажмите Y чтобы попробовать снова: ");

			var tryAgain = Console.ReadKey();
			//делаем перенос строки, чтобы нничего не слипалось
			Console.WriteLine();

			return tryAgain.Key != ConsoleKey.Y;
		}

		public override void SaveFileResult(object result)
		{
			File.WriteAllText(PathToFile, (string)result);
		}


		/// <summary>
		/// Проверяем, если пользовател уже указал расширение, то не добавляем его, иначе добавим
		/// </summary>
		public override string GetFileNameWithExtension(string fileName) => fileName.Length > EXTENSION_FILE.Length
			&& fileName.Substring(fileName.Length - EXTENSION_FILE.Length).Contains(EXTENSION_FILE)
				? fileName
				: $"{fileName}{EXTENSION_FILE}";

		public void ShowStatistics()
		{
			Console.WriteLine();
			Console.WriteLine("Статистика: ");

			var statisticDictionary = this.FillStatisticsDictionary(ConvertHtmlToTextArray(FileResult).Select(c => c.ToUpper()));
			foreach (var keyValue in statisticDictionary)
				Console.WriteLine($"{keyValue.Key}-{keyValue.Value}");
		}

		/// <summary>
		/// Убирает из Html все теги и возвращает массив элементов с учетом разделителей
		/// </summary>
		/// <param name="htmlText">файл содержащий в себе html</param>
		/// <returns>массив слов из html страницы без тегов</returns>
		public string[] ConvertHtmlToTextArray(string htmlText)
		{
			var pageDoc = new HtmlDocument();
			pageDoc.LoadHtml(htmlText);
			return pageDoc.DocumentNode
				.InnerText
				.Split(SEPARATORS, StringSplitOptions.RemoveEmptyEntries);
		}

	}
}
