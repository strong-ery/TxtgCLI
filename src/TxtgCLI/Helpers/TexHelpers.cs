using System.Buffers.Binary;
using TexSharp;

public enum FormatType
{
    PNG,
    DDS
}

public class TexHelpers
{
    public (int, int) GetMaxMipResolution(string filePath, FormatType type)
    {
        switch (type)
        {
            case FormatType.PNG:
                byte[] pngHeader = new byte[24];
                using (FileStream fs = File.OpenRead(filePath))
                {
                    fs.ReadExactly(pngHeader);
                }
                int w = BinaryPrimitives.ReadInt32BigEndian(pngHeader.AsSpan(16));
                int h = BinaryPrimitives.ReadInt32BigEndian(pngHeader.AsSpan(20));
                return (w, h);
            case FormatType.DDS:
                byte[] bytesDds = File.ReadAllBytes(filePath);
                DdsImage dds = DdsImage.Parse(bytesDds);
                return (dds.Width, dds.Height);
            default:
                throw new ArgumentException($"Unsupported format type: {type}");
        }
    }
}