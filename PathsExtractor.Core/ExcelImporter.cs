namespace PathsExtractor.Core
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.IO;
	using System.Net.Mime;
	using OfficeOpenXml;

	public class ExcelImporter
	{
		public static void Export(string fileName, IEnumerable<string> files) {
			using (var excel = new ExcelPackage()) {
				ExcelWorksheet wks = excel.Workbook.Worksheets.Add("Content");
				wks.Cells[1, 1].LoadFromCollection(files);
				excel.SaveAs(new FileInfo(fileName));
			};
			Process process = new Process();
			process.StartInfo.FileName = fileName;
			process.Start();
		}
	}
}