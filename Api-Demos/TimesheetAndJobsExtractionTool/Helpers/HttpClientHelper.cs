using System;
using System.Net.Http;
using TimesheetAndJobsExtractionTool.Core.Models;

namespace TimesheetAndJobsExtractionTool.Core.Helpers
{
    public class HttpClientHelper
    {
        public HttpClient Create(string scheme, ArgumentDto context)
        {
            var client = new HttpClient {BaseAddress = new Uri(scheme + "://" + context.EndPoint)};
            client.DefaultRequestHeaders.Add("X-AppTenant", context.TenantId.ToString());
            client.DefaultRequestHeaders.Add("X-AppToken",
                EncryptionUtilityHelper.Encrypt(context.ApiKey.ToString(), context.ApiSecret));
            client.Timeout = TimeSpan.FromMinutes(10);
            return client;
        }
    }
}