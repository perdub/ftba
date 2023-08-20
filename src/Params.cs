using CommandLineParser;
using CommandLineParser.Arguments;

namespace ftba;

public class Params
{
    [ValueArgument(typeof(string), 'i', "input", AllowMultiple = true)]
    public List<string> Files{get;set;}

    [ValueArgument(typeof(string), 'o', "output")]
    public string OutputDir{get;set;} = "";

    [ValueArgument(typeof(bool), 'm', "minimize")]
    public bool MinimizeOutput{get;set;}

    [ValueArgument(typeof(int), 'b', "buffer", DefaultValue = 4096, Description = "Buffer size(in bytes)")]
    public int BufferSize{get;set;}
}