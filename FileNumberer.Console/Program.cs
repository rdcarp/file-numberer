﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fclp;
using Fclp.Internals;
using FileNumberer.Lib;

namespace FileNumberer.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            FileNumbererArgs fnArgs = ParseArgs(args);

            if (fnArgs != null)
            {
                // todo: remove clash of class and namespace
                Lib.FileNumberer fn = new Lib.FileNumberer(fnArgs);

                fn.Process();
            }
        }

        private static FileNumbererArgs ParseArgs(string[] args)
        {
            var parser = new FluentCommandLineParser<FileNumbererArgs>();
            
            parser.Setup<List<string>>(arg => arg.Directories)
                .As('d', "dirs")
                .WithDescription("Directories to process")
                .Required();

            parser.Setup<string>(arg => arg.Prefix)
                .As('p', "prefix")
                .WithDescription("Prefix");

            parser.Setup<string>(arg => arg.Suffix)
                .As('s', "suffix")
                .WithDescription("Suffix");

            parser.Setup<bool>(arg => arg.Recurse)
                .As('r', "recurse")
                .WithDescription("Recurse down to child folders?")
                .SetDefault(false);

            parser.Setup<int>(arg => arg.NumberOfDigits)
                .As('n', "number_length")
                .WithDescription("How many digits should numbers be?")
                .SetDefault(4);

            parser.Setup<string>(arg => arg.Target)
                .As('t', "target")
                .WithDescription("Target folder for generated files")
                .SetDefault("output/");

            parser.Setup<SequenceMethod>(arg => arg.Method)
                .As('m', "Method")
                .WithDescription("The ordering mechanism to use");

            parser.Setup<int>(arg => arg.StartNumber)
                .As('f', "start-from")
                .WithDescription("Start file numbering from this number")
                .SetDefault(1);

            parser.SetupHelp("?", "help")
                .Callback(text => Console.WriteLine(text));

            ICommandLineParserResult result = parser.Parse(args);
            FileNumbererArgs parsedArgs = parser.Object;

            if (result.HasErrors || result.HelpCalled)
            {
                Console.WriteLine(result.ErrorText);
                Console.WriteLine("Use --help to display help information");

                parsedArgs = null;
            }

            return parsedArgs;
        }
    }
}
