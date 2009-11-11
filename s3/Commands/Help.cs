using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

using com.amazon.s3;

using s3.Options;

namespace s3.Commands
{
    class Help : Command
    {
        Command command = null;

        protected override void initialise(CommandLine cl)
        {
            if (cl.args.Count > 0)
                command = Command.createInstance(cl.args[0]);
        }

        public override void execute()
        {
            if (command == null)
                displayHelp();
            else {

                string[] text = command.getHelpText();
                foreach (string s in text) {
                    writeNormal(s);
                }
            }
        }

        void writeHighlighted(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Black;
            writeNormal(text);
            Console.ResetColor();
        }

        void writeNormal(string text) {
            foreach (Type t in Option.AllOptions) {
                text = text.Replace("/" + t.Name.ToLower(), Option.OptionPrefix + t.Name.ToLower());
            }
            Console.Error.WriteLine(text);
        }

        public override string[] getHelpText() {
            return new string[] { };
        }

        public void displayHelp()
        {
            writeNormal("Type 's3 help' followed by a command name for more details, e.g. 's3 help put'.");
            Console.Error.WriteLine();
            writeHighlighted("s3 auth [<key> <secret>]");
            writeNormal("    Gets and saves your Amazon authentication details for future invocations.");
            Console.Error.WriteLine();
            writeHighlighted("s3 put <bucket>[/<keyprefix>] <path> [/big[:<size>]] [/backup] [/sync] [/acl:<acl>] [/sub[:withdelete]] [/yes] [/accesskey:<key> /secretkey:<secret>]");
            writeNormal(
@"    Puts a file, files or an entire directory hierarchy to S3.  Big files can
    be split up into smaller chunks (/big), the Windows archive flag can be 
    honoured (/backup) and there is an option to upload only files modified
    since last upload (/sync).  Type 's3 help put' for more details.

Examples:
s3 put mybucket pic*.jpg /acl:public-read
s3 put mybucket/pictures/ c:\mypictures\ /sub:withdelete /sync");
            Console.Error.WriteLine();
            writeHighlighted("s3 get <bucket>/<keyprefix> [<path>] [/big] [/sub] [/accesskey:<key> /secretkey:<secret>]");
            writeNormal(
@"    Gets an object or objects from S3.  Can join together files that have been
    uploaded in chunks (/big) or download entire directory hierarchies (/sub).
    Type 's3 help get' for more details.

Examples:
s3 get mybucket/pic*
s3 get mybucket/pictures/ /sub");
            Console.Error.WriteLine();
            writeHighlighted("s3 list [<bucket>[/<keyprefix>]] [/accesskey:<key> /secretkey:<secret>]");
            writeNormal(
@"    Lists keys or buckets.  Type 's3 help list' for more details.

Example:
s3 list mybucket/pic*");
            Console.Error.WriteLine();
            writeHighlighted("s3 instances");
            writeNormal(
@"    Lists the current EC2 instances on a per-AMI basis.");
            Console.Error.WriteLine();
            writeHighlighted("s3 snapshot <volumeID> [/accesskey:<key> /secretkey:<secret>]");
            writeNormal(
@"    Starts an EBS snapshot.  Returns as soon as job begins.

Please blog or twitter about s3.exe if you find it useful.");
        }
    }
}
