using TxtgSharp;
using System.CommandLine;

class Program
{
    static void Main()
    {
        var rootCommand = new RootCommand("TxtgCLI - A command line interface for batch converting PNG/DDS to TXTG files, with a format selection algorithm based off of format postfixes");

        var asm = System.Reflection.Assembly.GetExecutingAssembly();

        string asciiResourceName = "TxtgCLI.derpylink.txt";

        using (Stream stream = asm.GetManifestResourceStream(asciiResourceName))
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