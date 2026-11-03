using TxtgSharp;
using System.CommandLine;
using System.CommandLine.Parsing;
using System.CommandLine.Invocation;
using System.Threading.Tasks;



class Program
{
    static async Task<int> Main(string[] args)
    {
        var inputFolderOption = new Option<string>("-i", "--input" )
        {
           Description = ("Input folder containing PNG/DDS files to convert.")
        };

        var outputFolderOption = new Option<string>("-o", "--output" )
        {
            Description = ("Output folder path for converted TXTG files. (will be created if it doesn't exist)")
        };

        var outputQualityOption = new Option<OutputQuality>("-q", "--quality" )
        {
            Description = ("Output quality for converted TXTG files. Automatic will select the quality based on the filename postfixes + other image data. (default: Automatic)"),
        };

        var rootCommand = new RootCommand("TxtgCLI - A command line interface for batch converting PNG/DDS to TXTG files, with a hardware texture format (HTF) selection algorithm based off of the input image(s) postfixes (by filename), and other image data.");

        rootCommand.Options.Add(inputFolderOption);
        rootCommand.Options.Add(outputFolderOption);
        rootCommand.Options.Add(outputQualityOption);
        
        PrintAsciiArt();

        if (args.Length == 0)
        {
            return rootCommand.Parse(new string[] { "--help" }).Invoke();
        }

        return 0;
    }

    public static void PrintAsciiArt()
    {
        var asm = System.Reflection.Assembly.GetExecutingAssembly();

        string asciiResourceName = "TxtgCLI.derpylink.txt";

        using (Stream? stream = asm.GetManifestResourceStream(asciiResourceName))
        {
            if (stream != null)
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string asciiArt = reader.ReadToEnd();
                    Console.WriteLine(asciiArt);
                }
            }
            else
            {
                Console.WriteLine("What do you have against derpy link?");
            }
        }
    }
}