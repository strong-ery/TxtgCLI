

public class ExtractorOrchestrator
{
    private readonly FsHelpers _fsHelpers;

    public ExtractorOrchestrator()
    {
        _fsHelpers = new FsHelpers();
    }

    public void Extract(string inputFolder, string outputFolder, OutputQuality? outputQuality)
    {
        _fsHelpers.GetFilesInDirectoryByExtension(inputFolder, new string[] { ".png", ".dds" });
    }
}