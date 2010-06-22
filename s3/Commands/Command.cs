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
            typeof(DeleteSnapshots),
            typeof(Get),
            typeof(Help),
            typeof(Instances),
            typeof(List),
            typeof(Put),
            typeof(Snapshot),
            typeof(Snapshots)
        };

        protected abstract void Initialise(CommandLine commandLine);

        public abstract void Execute();

        protected static Command CreateInstance(string commandName)
        {
            foreach (Type c in allCommands)
                if (c.Name.Equals(commandName, StringComparison.InvariantCultureIgnoreCase))
                {
                    return (Command)Activator.CreateInstance(c);
                }

            return null;
        }

        public static void CreateInstance(string commandName, CommandLine commandLine)
        {
            commandLine.command = CreateInstance(commandName);
            if (commandLine.command == null)
                throw new SyntaxException(string.Format("Unknown command: {0}", commandName));
            else
                commandLine.command.Initialise(commandLine);
        }
    }
}
