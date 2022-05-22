using CsvHelper;
using System;
using System.Data;
using System.Globalization;
using System.IO;

namespace FinanciallySmart.Models
{
    internal class ReportModel
    {
        public void ExportDataTableAsCSV(DataTable dt)
        {
			// TODO Create a dialog box for save location. 
			using (var writer = new StringWriter())
			using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
			{
				foreach (DataColumn dc in dt.Columns)
				{
					csv.WriteField(dc.ColumnName);
				}
				csv.NextRecord();

				foreach (DataRow dr in dt.Rows)
				{
					foreach (DataColumn dc in dt.Columns)
					{
						csv.WriteField(dr[dc]);
					}
					csv.NextRecord();
				}

				// writer.ToString().Dump();
				string path = Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
				System.IO.File.WriteAllText(path, writer.ToString());

			}
			
		}
    }
}
