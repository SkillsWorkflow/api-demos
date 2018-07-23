using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TimesheetAndJobsExtractionTool.Core.Models;

namespace TimesheetAndJobsExtractionTool.Core.Helpers
{
    public class ReportHelper
    {
        public async Task<string> GetReportIdByNameAsync(ArgumentDto context, string name)
        {
            string result;
            using (var client = new HttpClientHelper().Create("https", context))
            {
                try
                {
                    var response = await client.GetAsync("/api/reports");
                    response.EnsureSuccessStatusCode();
                    var reportList = JsonConvert.DeserializeObject<List<ReportModel>>(
                        await response.Content.ReadAsStringAsync());
                    result = reportList.FirstOrDefault(r => r.Name == name)?.Id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
            return result;
        }

        public async Task<ReportExecuteDto> ExecuteReportAsync(ArgumentDto context, string id, ReportFilterModel[] filter)
        {
            using (var client = new HttpClientHelper().Create("https", context))
            {
                try
                {
                    var content = new StringContent(JsonConvert.SerializeObject(filter), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"/api/reports/{id}/execute", content);
                    response.EnsureSuccessStatusCode();
                    return JsonConvert.DeserializeObject<ReportExecuteDto>(await response.Content.ReadAsStringAsync());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }

    }
}
