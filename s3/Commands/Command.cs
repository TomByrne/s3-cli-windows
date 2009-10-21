using System;
using System.Collections.Generic;
using System.Text;

using s3.Options;

namespace s3.Commands
{
    internal abstract class Command
    {
        static List<Type> allCommands = new List<Type>()
        {
            typeof(Auth),
            typeof(Get),
            typeof(Help),
            typeof(List),
            typeof(Put),
            typeof(Snapshot)
        };

        protected abstract void initialise(CommandLine commandLine);

        public abstract void execute();

        public static void createInstance(string commandName, CommandLine commandLine)
        {
            foreach (Type c in allCommands)
                if (c.Name.Equals(commandName, StringComparison.InvariantCultureIgnoreCase))
                {
                    commandLine.command = (Command)Activator.CreateInstance(c);
                    commandLine.command.initialise(commandLine);
                    return;
                }

            throw new SyntaxError(string.Format("Unknown command: {0}", commandName));
        }
    }
}
