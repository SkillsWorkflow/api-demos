using System;

namespace TimesheetAndJobsExtractionTool.Core.Models
{
    public class ReportModel
    {
        public string Oid { get; set; }
        public string Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Version { get; set; }
        public string Language { get; set; }
        public bool HasFields { get; set; }
        public bool HasFilters { get; set; }
        public bool HasFiles { get; set; }
        public Defaultfile DefaultFile { get; set; }
    }

    public class Defaultfile
    {
        public string Oid { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
    }



    public class ReportExecuteDto
    {
        public Object[] Data { get; set; }
        public ReportFieldDto[] Fields { get; set; }
        public ReportFilterDto[] Filters { get; set; }
        public ReportFileToOpenDto[] Files { get; set; }
    }

    public class ReportFieldDto
    {
        public int Position { get; set; }
        public string FieldName { get; set; }
        public string Caption { get; set; }
        public string Area { get; set; }
        public string FieldType { get; set; }
        public int AreaIndex { get; set; }
        public bool Visible { get; set; }
        public bool ShowTotals { get; set; }
        public string FormatString { get; set; }
    }

    public class ReportFilterDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ParameterName { get; set; }
        public string Query { get; set; }
        public string DataType { get; set; }
        public bool Mandatory { get; set; }
        public int Position { get; set; }
        public bool FilterWithQuery { get; set; }
        public ReportFilterValueDto Value { get; set; }
        public ReportFilterValueOptionDto[] ValueOptions { get; set; }
    }

    public class ReportFileToOpenDto
    {
        public string Oid { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
    }

    public class ReportFilterValueDto
    {
        public object ObjectValue { get; set; }
        public string StringValue { get; set; }
        public bool BooleanValue { get; set; }
        public DateTime DateTimeValue { get; set; }
        public int IntValue { get; set; }
        public int DecimalValue { get; set; }
        public string UniqueIdentifierValue { get; set; }
    }

    public class ReportFilterValueOptionDto
    {
        public string Text { get; set; }
        public object Value { get; set; }
    }


    public class ReportFilterModel 
    {
        public string ParameterName { get; set; }
        public object Value { get; set; }
        public string StringValue { get; set; }
    }

}
