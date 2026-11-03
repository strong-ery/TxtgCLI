public class AsciiArt
{
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