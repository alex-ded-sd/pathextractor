namespace PathsExtractor.Core
{
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;

	public class Extractor
	{
		public static IEnumerable<string> GetFilesPaths(string folder, string[] extensions)
		{
		    IEnumerable<FileInfo> files = GetFiles(folder, extensions);
			IEnumerable<string>  filesPaths = files.Select(f => f.FullName.Replace('\\', '/'));
			return filesPaths;
		}

	    public static IEnumerable<FileInfo> GetFiles(string folder, string[] extensions)
	    {
	        if(!Directory.Exists(folder))
	        {
	            return Enumerable.Empty<FileInfo>();
	        }
	        DirectoryInfo directory = new DirectoryInfo(folder);
	        return extensions.SelectMany(ext => directory.EnumerateFiles(ext, SearchOption.AllDirectories));
	    }
    }
}
