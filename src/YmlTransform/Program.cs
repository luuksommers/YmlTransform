using System;
using Sitecore.Express;
using YmlTransform.Exceptions;
using YmlTransform.Models;

namespace YmlTransform
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var options = new Options();
                var isValid = CommandLine.Parser.Default.ParseArgumentsStrict(args, options);
                if (isValid)
                {
                    YmlTransformer.TransformPath(options.Path, options.TransformFile, options.Recursive);
                }
            }
            catch (IncompleteTransformationException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Error.WriteLine("Not all fields were processed. Please verify the following transformations:");
                Console.Error.WriteLine(e.Message);
                System.Environment.Exit(1);
            }
        }
    }
}
