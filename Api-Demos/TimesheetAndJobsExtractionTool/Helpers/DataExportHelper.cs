using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace TimesheetAndJobsExtractionTool.Core.Helpers
{
    static class DataExportHelper
    {

        internal static void ExportToCsv(string fileName, object[] data)
        {
            var timestamp = DateTime.UtcNow.ToShortDateString().Replace("/", "") + "_" + DateTime.UtcNow.ToShortTimeString().Replace(":","");
            fileName = fileName + "_" + timestamp;
            var sb = new StringBuilder();
            var line = string.Empty;
            var header = JObject.Parse(JsonConvert.SerializeObject(data[0]));
            foreach (var item in header)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    line += ",";
                }
                line += item.Key;
            }
            sb.Append(line);
            sb.Append(Environment.NewLine);


            foreach (var node in data)
            {
                var row = JObject.Parse(JsonConvert.SerializeObject(node));
                var result = string.Empty;
                foreach (var item in row)
                {
                    if (!string.IsNullOrEmpty(result)) result += ",";
                    result += item.Value;
                }
                result += Environment.NewLine;
                sb.Append(result);
            }
            File.WriteAllText($"{fileName}.txt", sb.ToString());
            Console.WriteLine($"Exported to '{fileName}.csv' {data.Length -1} Rows ");
        }
    }
}
