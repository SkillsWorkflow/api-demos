using System;
using System.Globalization;
using System.Threading.Tasks;
using TimesheetAndJobsExtractionTool.Core.Helpers;
using TimesheetAndJobsExtractionTool.Core.Models;

namespace TimesheetAndJobsExtractionTool.Core
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var parameters = ArgumentHelper.Get(args);
            var reporthelper = new ReportHelper();
            var reports = new [] {"Timesheets Reconciliation"};
            foreach (var reportName in reports)
            {
                var report = await reporthelper.GetReportIdByNameAsync(parameters,reportName);
                var data = await reporthelper.ExecuteReportAsync(parameters, report, new[]
                {
                    new ReportFilterModel
                    {
                        ParameterName = "ClientId",
                        Value = parameters.ClientId.ToString(),
                        StringValue = parameters.ClientId.ToString()
                    },
                    new ReportFilterModel
                    {
                        ParameterName = "FromDate",
                        Value = new DateTime(parameters.Year,01,01).ToString("yyyy-MM-dd"),
                        StringValue = new DateTime(parameters.Year,01,01).ToString("yyyy-MM-dd")
                    },
                    new ReportFilterModel
                    {
                        ParameterName = "ToDate",
                        Value = new DateTime(parameters.Year,12,31,23,59,59).ToString("yyyy-MM-dd"),
                        StringValue = new DateTime(parameters.Year,12,31,23,59,59).ToString("yyyy-MM-dd")
                    }
                });
                DataExportHelper.ExportToCsv(reportName, data.Data);
            }
        }

        
    }
}
