using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using Rainbow.Model;
using Rainbow.Storage.Yaml;

namespace YmlTransform
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();
            var isValid = CommandLine.Parser.Default.ParseArgumentsStrict(args, options);
            if (isValid)
            {
                YmlTransformer.TransformPath(options.Path, options.TransformFile, options.Recursive);
            }
        }

        class Options
        {
            [Option('p', "path", Required = true, HelpText = "Path to process")]
            public string Path { get; set; }

            [Option('r', "recursive", Required = false, HelpText = "Loop recursively", DefaultValue = false)]
            public bool Recursive { get; set; }

            [Option('t', "transform", Required = true, HelpText = "Transformation file")]
            public string TransformFile { get; set; }
        }
    }
}
