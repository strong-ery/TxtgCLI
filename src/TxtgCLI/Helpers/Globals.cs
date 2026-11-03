public enum OutputQuality
{
    Automatic,
    Low,
    High
}

public enum OperationType
{
    Convert,
    Extract
}

public class TxCliGlobals
{
    public OutputQuality outputQuality = OutputQuality.Automatic;
    public OperationType operationType = OperationType.Convert;
}