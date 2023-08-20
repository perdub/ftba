namespace ftba.Convert;

public abstract class AbstractConvert : IDisposable
{
    protected FileStream sourceFile;
    protected bool minimizeOutput;
    protected StreamWriter writer;
    protected int bufferSize;

    public AbstractConvert(string outputFile, bool minimizeOutput = false, int bufferSize = 4096)
    {
        sourceFile = File.Open(outputFile, FileMode.Create, FileAccess.ReadWrite);
        this.minimizeOutput = minimizeOutput;
        writer = new StreamWriter(sourceFile);
        this.bufferSize = bufferSize;

        writer.AutoFlush = true;
    }

    public abstract void BeforeWrite();
    public abstract void ProcessFile(string path);
    public abstract void AfterWrite();

    public void Dispose()
    {
        sourceFile.Dispose();
        writer.Dispose();
    }
}