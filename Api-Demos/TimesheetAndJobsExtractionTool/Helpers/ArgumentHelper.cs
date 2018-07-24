using System;
using Microsoft.Extensions.CommandLineUtils;
using TimesheetAndJobsExtractionTool.Core.Models;

namespace TimesheetAndJobsExtractionTool.Core.Helpers
{
    public static class ArgumentHelper
    {
        public static ArgumentDto Get(string[] args)
        {
            var app = new CommandLineApplication
            {
                Name = "Api demos - Skills WorkFlow Extraction Tool",
                Description = "Skills Workflow - Timesheet and Jobs Extraction Tool",
                ExtendedHelpText = Environment.NewLine 
                                   + "Usage: -Year <year> -Clientid <clientID> -Tenantid <tenantId> -Endpoint <endpoint> -Apikey <apikey> -Apisecret <apisecret>" 
                                   + Environment.NewLine
                                   + "Year: Year For Extracting Data"
                                   + Environment.NewLine
                                   + "ClientId: Skills Workflow ClientId"
                                   + Environment.NewLine
                                   + "Tenatid: Skills Tenant ID"
                                   + Environment.NewLine
                                   + "Endpoint: Skills apiV2 Endpoint"
                                   + Environment.NewLine
                                   + "ApiKey: Skills Api Key"
                                   + Environment.NewLine
                                   + "ApiSecret: Skills Api Key"
                                   + Environment.NewLine 
                                   + Environment.NewLine
                                   + "Depending on your OS, you may need to execute the application as TimesheetAndJobsExtractionTool.Core.exe " +
                                   Environment.NewLine 
                                   + "or 'dotnet TimesheetAndJobsExtractionTool.Core.dll'" 
                                   + Environment.NewLine
            };
            app.HelpOption("-? | -h | --help");

            var yearOption = app.Option("-Year", "Year", CommandOptionType.SingleValue);
            var clientIdOption = app.Option("-Clientid", "Client ID", CommandOptionType.SingleValue);
            var endpointOption = app.Option("-Endpoint", "Endpoint", CommandOptionType.SingleValue);
            var tenantIdOption = app.Option("-Tenantid", "Tenant ID", CommandOptionType.SingleValue);
            var apiKeyOption = app.Option("-Apikey", "Api Key", CommandOptionType.SingleValue);
            var apiSecretOption = app.Option("-Apisecret", "Api Secret", CommandOptionType.SingleValue);

            app.OnExecute(() =>
            {
                if (string.IsNullOrEmpty(yearOption.Value()))
                {
                    Console.WriteLine($"Year Missing...");
                    app.ShowHint();
                    Environment.Exit(-1);
                }
                if (string.IsNullOrEmpty(clientIdOption.Value()))
                {
                    Console.WriteLine($"Client ID Missing...{Environment.NewLine}");
                    app.ShowHint();
                    Environment.Exit(-1);
                }
                if (string.IsNullOrEmpty(tenantIdOption.Value()))
                {
                    Console.WriteLine($"Tenant ID Missing...{Environment.NewLine}");
                    app.ShowHint();
                    Environment.Exit(-1);
                }
                if (string.IsNullOrEmpty(endpointOption.Value()))
                {
                    Console.WriteLine($"Endpoint Missing...{Environment.NewLine}");
                    app.ShowHint();
                    Environment.Exit(-1);
                }
                if (string.IsNullOrEmpty(apiKeyOption.Value()))
                {
                    Console.WriteLine($"Api key Missing...{Environment.NewLine}");
                    app.ShowHint();
                    Environment.Exit(-1);
                }
                if (string.IsNullOrEmpty(apiSecretOption.Value()))
                {
                    Console.WriteLine($"Api Secret Missing...{Environment.NewLine}");
                    app.ShowHint();
                    Environment.Exit(-1);
                }
                return 0;

            });
            
            app.Execute(args);

            if (app.Options.TrueForAll(t => string.IsNullOrEmpty(t.Value())))
            {
                Environment.Exit(-1);
            }

            var result = new ArgumentDto
            {
                ApiSecret = apiSecretOption.Value()
            };
            try
            {
                result.Year = int.Parse(yearOption.Value());
                result.ApiKey = Guid.Parse(apiKeyOption.Value());
                result.ClientId = Guid.Parse(clientIdOption.Value());
                result.TenantId= Guid.Parse(tenantIdOption.Value());
                result.EndPoint = endpointOption.Value().ToLower().StartsWith("https://") ? new Uri(endpointOption.Value()).Host : new Uri($"https://{endpointOption.Value()}").Host;
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(-1);
            }
            return result;
        }
    }
}
