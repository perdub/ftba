using CommandLineParser;

namespace ftba;

class Program
{
    static void Main(string[] args)
    {
        CommandLineParser.CommandLineParser parser = new CommandLineParser.CommandLineParser();
        Params _params = new Params();
        parser.ExtractArgumentAttributes(_params);
        parser.ParseCommandLine(args);

        ftba.Convert.AbstractConvert conv = new ftba.Convert.CSharpConvert("test.cs", _params.MinimizeOutput, _params.BufferSize);

        Console.WriteLine(_params.BufferSize);

        conv.BeforeWrite();
        foreach(var a in _params.Files){
            conv.ProcessFile(a);
        }
        conv.AfterWrite();
    }
}
