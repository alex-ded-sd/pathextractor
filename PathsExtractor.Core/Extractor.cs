namespace PathsExtractor.Core
{
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;

	public class Extractor
	{
		public static IEnumerable<string> GetFilesPaths(string folder, string[] extensions) {
			if (!Directory.Exists(folder)) {
				return Enumerable.Empty<string>();
			}
			DirectoryInfo directory = new DirectoryInfo(folder);
			IEnumerable<FileInfo> files = extensions.SelectMany(ext => directory.EnumerateFiles(ext, SearchOption.AllDirectories));
			IEnumerable<string>  filesPaths = files.Select(f => f.FullName.Replace('\\', '/'));
			return filesPaths;
		}
	}
}
