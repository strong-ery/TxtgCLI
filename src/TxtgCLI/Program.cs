using TxtgSharp;
using System.CommandLine;
using System.CommandLine.Parsing;
using System.CommandLine.Invocation;
using System.Threading.Tasks;

class Program
{
    static async Task<int> Main(string[] args)
    {
        var operationTypeOption = new Option<OperationType>("-t", "--type")
        {
            Description = "Operation type: convert or extract.",
            Required = true
        };
        var inputFolderOption = new Option<string>("-i", "--input" )
        {
           Description = "Input folder containing PNG/DDS files to convert.",
           Required = true
        };

        var outputFolderOption = new Option<string>("-o", "--output" )
        {
            Description = "Output folder path for converted TXTG files. (will be created if it doesn't exist)",
            Required = true
        };

        var outputQualityOption = new Option<OutputQuality>("-q", "--quality" )
        {
            Description = "Output quality for converted TXTG files. Automatic will select the quality based on the filename postfixes + other image data. (default: Automatic)",
            Required = false
        };

        var rootCommand = new RootCommand("TxtgCLI - A command line interface for batch converting PNG/DDS to TXTG files, and vice versa, with a hardware texture format (HTF) selection algorithm based off of the input image(s) postfixes (by filename), and other image data.");

        rootCommand.Options.Add(operationTypeOption);
        rootCommand.Options.Add(inputFolderOption);
        rootCommand.Options.Add(outputFolderOption);
        rootCommand.Options.Add(outputQualityOption);
        
        AsciiArt.PrintAsciiArt();

        if (args.Length == 0)
        {
            return rootCommand.Parse(new string[] { "--help" }).Invoke();
        }

        rootCommand.SetAction((Func<ParseResult, int>)(parseResult =>
        {
            OperationType? operationType = parseResult.GetValue(operationTypeOption);
            string? inputFolder = parseResult.GetValue(inputFolderOption);
            string? outputFolder = parseResult.GetValue(outputFolderOption);
            OutputQuality? outputQuality = parseResult.GetValue(outputQualityOption);

            switch (operationType)
            {
                case OperationType.Convert:
                    return 0;

                case OperationType.Extract:
                    return 0;

                default:
                    Console.WriteLine("Invalid operation type specified. Please use 'convert' or 'extract'.");
                    return 1;
            }
        }));

        //stupid fucking v3 syntax for system.commandline I got STUCK ON THIS FOR 2 HOURS
        return await rootCommand.Parse(args).InvokeAsync();
    }
}