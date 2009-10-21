using System;
using System.Collections.Generic;
using System.Text;

using s3.Commands;
using s3.Options;

namespace s3
{
    class CommandLine
    {
        public Command command;
        public readonly List<string> args = new List<string>();
        public readonly Dictionary<Type, Option> options = new Dictionary<Type, Option>();

        public CommandLine(string[] args)
        {
            foreach (string a in args)
            {
                Option o = Option.fromString(a);

                if (o == null)
                    this.args.Add(a);
                else
                {
                    if (options.ContainsKey(o.GetType()))
                        throw new SyntaxError(string.Format("The {0} option was specified more than once", o.GetType().Name));
                    options.Add(o.GetType(), o);
                }
            }

            if (this.args.Count == 0)
                throw new SyntaxError("No arguments supplied");
            else
            {
                string commandName = this.args[0];
                this.args.RemoveAt(0);
                Command.createInstance(commandName, this);
            }
        }
    }
}
