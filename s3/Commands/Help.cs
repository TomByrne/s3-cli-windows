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
            else
                command.displayHelp();
        }

        void writeHighlighted(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Error.WriteLine(text);
            Console.ResetColor();
        }

        public override void displayHelp()
        {
            Console.Error.WriteLine("Type 's3 help' followed by a command name for more details, e.g. 's3 help put'.");
            Console.Error.WriteLine();
            writeHighlighted("s3 auth [<key> <secret>]");
            Console.Error.WriteLine("    Gets and saves your Amazon authentication details for future invocations.");
            Console.Error.WriteLine();
            writeHighlighted("s3 put <bucket>[/<keyprefix>] <path> [/big[:<size>]] [/backup] [/sync] [/acl:<acl>] [/sub[:withdelete]] [/yes]");
Console.Error.WriteLine(
@"    Puts a file, files or an entire directory hierarchy to S3.  Big files can
    be split up into smaller chunks (/big), the Windows archive flag can be 
    honoured (/backup) and there is an option to upload only files modified
    since last upload (/sync).  Type 's3 help put' for more details.

Examples:
s3 put mybucket pic*.jpg /acl:public-read
s3 put mybucket/backup-pictures/ c:\mypictures\ /sub:withdelete /sync");
            Console.Error.WriteLine();
            writeHighlighted("s3 get <bucket>/<keyprefix> [<path>] [/big] [/sub]");
            Console.Error.WriteLine(
@"    Gets an object or objects from S3.  Can join together files that have been
    uploaded in chunks (/big) or download entire directory hierarchies (/sub).
    Type 's3 help get' for more details.

Examples:
s3 get mybucket/pic*
s3 get mybucket/backup-pictures/ /sub");
            Console.Error.WriteLine();
            writeHighlighted("s3 list [<bucket>[/<keyprefix>]]");
            Console.Error.WriteLine(
@"    Lists keys or buckets.  Type 's3 help list' for more details.

Example:
s3 list mybucket/pic*");
            Console.Error.WriteLine();
            writeHighlighted("s3 snapshot <volumeID>");
            Console.Error.WriteLine(
@"    Starts an EBS snapshot.  Returns as soon as job begins.

Please blog or twitter about s3.exe if you find it useful.");
        }
    }
}
