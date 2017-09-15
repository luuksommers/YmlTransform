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
                var transformation = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TransformItem>>(File.ReadAllText(options.TransformFile));

                Transform(options.Path, transformation, options.Recursive);
            }
        }

        private static void Transform(string path, List<TransformItem> transformations, bool recursive)
        {
            var files = Directory.GetFiles(path, "*.yml",
                recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);

            foreach (var file in files)
            {
                using (var fs = new FileStream(file, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
                {
                    var transformed = false;
                    var formatter = new YamlSerializationFormatter(null, null);
                    var item = new ProxyItem(formatter.ReadSerializedItem(fs, Path.GetFileName(file)));

                    foreach (var t in transformations)
                    {
                        if (item.Path == t.Path)
                        {
                            if (t.Type == "Shared")
                            {
                                var field = item.SharedFields.FirstOrDefault(a => a.FieldId == t.FieldId) as ProxyFieldValue;
                                if (field != null)
                                {
                                    Console.WriteLine($"Updating file {file} section {t.Type} id {t.FieldId} to {t.Value}");
                                    field.Value = t.Value;
                                    transformed = true;
                                }
                            }
                            else if (t.Type == "Languages")
                            {
                                var field = item.Versions
                                    .Where(a => t.Languages == "*")
                                    .SelectMany(a => a.Fields)
                                    .FirstOrDefault(a => a.FieldId == t.FieldId) as ProxyFieldValue;
                                if (field != null)
                                {
                                    Console.WriteLine($"Updating file {file} section {t.Type} id {t.FieldId} to {t.Value}");
                                    field.Value = t.Value;
                                    transformed = true;
                                }
                            }
                        }
                    }



                    if (transformed)
                    {
                        Console.WriteLine($"Transformed: {file}");
                        fs.SetLength(0);
                        formatter.WriteSerializedItem(item, fs);
                    }
                }

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

        class TransformItem
        {
            public string Path { get; set; }
            public string Type { get; set; }
            public string Languages { get; set; }
            public Guid FieldId { get; set; }
            public string Value { get; set; }
            public string Hint { get; set; }
        }
    }
}
