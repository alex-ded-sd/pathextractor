namespace PathsExtractor.ConsoleClient
{
	using System;
	using System.Linq;
	using Core;

	class Program
	{
		static void Main(string[] args) {
			var files = Extractor.GetFilesPaths(@"C:\materials", new[] {"*.pdf"});
			try {
				ExcelImporter.Export("test.xlsx", files);
				Console.WriteLine("ok");
			}
			catch (Exception e) {
				Console.WriteLine(e);
			}
			Console.ReadLine();
		}
	}
}
