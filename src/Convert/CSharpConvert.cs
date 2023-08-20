using System.Text;

namespace ftba.Convert;

public class CSharpConvert : AbstractConvert
{
    public CSharpConvert(string outputFile, bool minimizeOutput = false, int bufferSize=4096) : base(outputFile, minimizeOutput, bufferSize)
    {
    }

    public override void AfterWrite()
    {
        writer.Write('}');
        if (!minimizeOutput)
        {
            writer.Write(writer.NewLine);
        }
        writer.Write('}');
    }

    public override void BeforeWrite()
    {
        writer.Write("namespace ftba.Files{");
        if (!minimizeOutput)
        {
            writer.Write(writer.NewLine);
            writer.Write("\t");
        }

        writer.Write("public static partial class Files{");
        if (!minimizeOutput)
        {
            writer.Write(writer.NewLine);
            writer.Write("\t\t");
        }
    }

    public override void ProcessFile(string path)
    {
        writer.Write("public static byte[] _");

        string finalName = Path.GetFileName(path)
            .Replace(" ", "")
            .Replace(".", "_")
            .Replace("!", "_")
            .Replace("-","_");

        writer.Write(finalName);

        writer.Write("=new byte[]{");

        var file = File.Open(path, FileMode.Open);
        while (true)
        {
            byte[] buf = new byte[bufferSize];

            int readed = file.Read(buf, 0, bufferSize);

            StringBuilder sb = new StringBuilder(readed);

            if (readed < bufferSize)
            {
                for (int i = 0; i < readed; i++)
                {
                    sb.Append(buf[i]);
                    sb.Append(',');
                }
                writer.Write(sb.ToString());
                break;
            }
            else
            {
                for (int i = 0; i < bufferSize; i++)
                {
                    sb.Append(buf[i]);
                    sb.Append(',');
                }
            }

            writer.Write(sb.ToString());
        }

        writer.BaseStream.Position--;

        writer.Write("};");
        if (!minimizeOutput)
        {
            writer.Write(writer.NewLine);
            writer.Write("\t\t");
        }
    }
}