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
            typeof(Instances),
            typeof(List),
            typeof(Put),
            typeof(Snapshot)
        };

        protected abstract void initialise(CommandLine commandLine);

        public abstract void execute();

        public abstract void displayHelp();

        protected static Command createInstance(string commandName)
        {
            foreach (Type c in allCommands)
                if (c.Name.Equals(commandName, StringComparison.InvariantCultureIgnoreCase))
                {
                    return (Command)Activator.CreateInstance(c);
                }

            return null;
        }

        public static void createInstance(string commandName, CommandLine commandLine)
        {
            commandLine.command = createInstance(commandName);
            if (commandLine.command == null)
                throw new SyntaxException(string.Format("Unknown command: {0}", commandName));
            else
                commandLine.command.initialise(commandLine);
        }
    }
}
