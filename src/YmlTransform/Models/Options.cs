using CommandLine;

namespace YmlTransform.Models
{
    class Options
    {
        /// <summary>
        /// Path to folder containing .yml files
        /// </summary>
        [Option('p', "path", Required = true, HelpText = "Path to folder containing .yml files")]
        public string Path { get; set; }

        /// <summary>
        /// Walk recursive through the folder structure
        /// </summary>
        [Option('r', "recursive", Required = false, HelpText = "Loop recursively", DefaultValue = false)]
        public bool Recursive { get; set; }

        /// <summary>
        /// Path to the file containing the transformations
        /// </summary>
        [Option('t', "transform", Required = true, HelpText = "Transformation file")]
        public string TransformFile { get; set; }
    }
}
