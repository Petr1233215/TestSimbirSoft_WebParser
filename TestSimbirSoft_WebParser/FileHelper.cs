using System;
using System.Collections.Generic;
using System.Text;

namespace TestSimbirSoft_WebParser
{
	public abstract class FileHelper
	{
		public string PathToFile { get; private set; }

		public FileHelper()
		{
			PathToFile = GetPathToSaveFile();
		}

		/// <summary>
		/// Получает путь куда нужно сохранить файл
		/// </summary>
		/// <returns>путь к будущему файлу</returns>
		public abstract string GetPathToSaveFile();

		/// <summary>
		/// Нужно ли продолжать работу программы
		/// </summary>
		public abstract bool IsStopWork();

		/// <summary>
		/// Добавляет расширение к имени файла
		/// </summary>
		/// <param name="fileName">имя файла(без расширения)</param>
		public abstract string GetFileNameWithExtension(string fileName);

		public abstract void SaveFileResult(object result);

		/// <summary>
		/// Возвращает результат после чтения какого-то контента, чтобы не привязываться к string, возвращает object
		/// </summary>
		public abstract object GetContentResult();
	}
}
