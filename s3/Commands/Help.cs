using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

using com.amazon.s3;

using s3.Options;
using System.Reflection;

namespace s3.Commands
{
    class Help : Command {

        Command command = null;

        protected override void initialise(CommandLine cl) {
            if (cl.args.Count > 0)
                command = Command.createInstance(cl.args[0]);
        }

        public override void execute() {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string commandName = (command == null) ? "Help" : command.GetType().Name;
            using (Stream stream = assembly.GetManifestResourceStream("s3.Help." + commandName + ".txt")) {
                if (stream != null) {
                    using (StreamReader reader = new StreamReader(stream)) {
                        while (reader.Peek() >= 0) {
                            WriteText(reader.ReadLine());
                        }
                    }
                } else {
                    Console.WriteLine("There is no help associated with that command. Type 's3 help' for general help.");
                }
            }
        }

        void WriteText(string text) {
            foreach (Type t in Option.AllOptions) {
                text = text.Replace("/" + t.Name.ToLower(), Option.OptionPrefix + t.Name.ToLower());
            }
            if (text.StartsWith("*")) {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Error.WriteLine(text.Substring(1));
                Console.ResetColor();
            } else {
                Console.Error.WriteLine(text);
            }
        }

    }

}
