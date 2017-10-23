using YmlTransform.Models;

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
    }
}
