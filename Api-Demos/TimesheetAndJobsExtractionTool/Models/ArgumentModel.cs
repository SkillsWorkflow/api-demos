using System;

namespace TimesheetAndJobsExtractionTool.Core.Models
{
    public class ArgumentDto
    {
        public int Year { get; set; }
        public Guid ClientId { get; set; }
        public Guid TenantId { get; set; }
        public string EndPoint { get; set; }
        public Guid ApiKey { get; set; }
        public string ApiSecret { get; set; }

    }
}