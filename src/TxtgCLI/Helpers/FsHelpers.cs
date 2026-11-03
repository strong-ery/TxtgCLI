public class FsHelpers
{
    public void CreateDirectoryIfNotExists(string path)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
    }

    public string[] GetFilesInDirectoryByExtension(string directoryPath, string[] extensions)
    {
        if (Directory.Exists(directoryPath))
        {
            var files = Directory.GetFiles(directoryPath, $"*{string.Join("*", extensions)}");
            return files;
        }
        else
        {
            Console.WriteLine($"Directory '{directoryPath}' does not exist.");
            return new string[0];
        }
    }

    public string StripFileToRawName(string filePath)
    {
        return Path.GetFileNameWithoutExtension(filePath);
    }

    public string StripToFileExtension(string filePath)
    {
        return Path.GetExtension(filePath);
    }
}