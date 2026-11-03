using TxtgSharp;
using TexSharp;

public class ExtractorOrchestrator
{
    private readonly FsHelpers _fsHelpers;

    public ExtractorOrchestrator()
    {
        _fsHelpers = new FsHelpers();
    }

    public void Extract(string inputFolder, string outputFolder, OutputQuality? outputQuality)
    {
        string[] files =_fsHelpers.GetFilesInDirectoryByExtension(inputFolder, new string[] { ".txtg" });

        if (files.Length == 0)
        {
            Console.WriteLine($"No .txtg files found in the input folder: {inputFolder}");
            return;
        }

        foreach(string file in files)
        {
            var fileName = _fsHelpers.StripFileToRawName(file);

            Console.WriteLine($"Extracting {fileName} to {outputFolder} with quality: {outputQuality}");
            // var fileExtension = _fsHelpers.StripToFileExtension(file); - not needed for the extractor, but the converter will need it to determine the output format (PNG or DDS)
            TxtgFile txtgFile = TxtgFile.FromFile(file);

            switch(outputQuality)
            {
                case OutputQuality.Automatic:
                    var texAuto = txtgFile.ToPng();
                    File.WriteAllBytes(Path.Combine(outputFolder, Path.ChangeExtension(fileName, ".png")), texAuto);
                    break;
                case OutputQuality.Low:
                    var texLow = txtgFile.ToPng();
                    File.WriteAllBytes(Path.Combine(outputFolder, Path.ChangeExtension(fileName, ".png")), texLow);
                    break;
                case OutputQuality.High:
                    var texHigh = txtgFile.ToDds();
                    File.WriteAllBytes(Path.Combine(outputFolder, Path.ChangeExtension(fileName, ".dds")), texHigh.ToBytes());
                    break;
                default:
                    Console.WriteLine($"Invalid output quality specified: {outputQuality}");
                    break;
            } 
        }
    }
}