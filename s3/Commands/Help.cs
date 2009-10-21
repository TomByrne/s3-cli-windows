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
        protected override void initialise(CommandLine cl)
        {
            // does nothing
        }

        public override void execute()
        {
            Console.Error.WriteLine(
@"s3 auth [<key> <secret>]
    Prompts for authentication details or reads from command line if specified.

s3 put <bucket>[/<keyprefix>] <filename> [/big[:<size>]] [/backup] [/sync] [/acl:<acl>]
Example:
s3 put mybucket pic*.jpg /acl:public-read

    Puts the specified filename to S3.  Wildcards are supported.  The filename
    excluding path is suffixed to the end of the supplied key prefix, if any.

    /big splits files into 10MB chunks suffixed with .000, .001 etc.  This is
    done without creating any temporary files on disk.  A custom chunk size 
    can be specified in MB, e.g. /big:0.1 creates chunks of about 100KB.

    /backup causes only files with the archive attribute to be copied, and the
    archive attribute is reset after copying.

    /sync only uploads files that do not exist on S3 or have been modified
    since last being uploaded. 

    /acl sets the ACL.  To make files public use /acl:public-read

s3 get <bucket>/<key> [<filename>] [/big]
Example:
s3 get mybucket/pic*
    
    Gets the specified object from S3. If no filename is supplied then the 
    suffix of the key after the final slash is used as the filename.

    A trailing * on the end of the key is treated as a wildcard, except when 
    the /big option or the <filename> is specified.

    /big fetches a file or files split using /big with the put command.

s3 list [<bucket>[/<keyprefix>]]
Example:
s3 list mybucket/pic*

    Lists the keys in the bucket beginning with the keyprefix, if supplied.  A
    trailing asterisk on the keyprefix is ignored.  With no parameters, gets 
    the list of buckets.

s3 snapshot <volumeID>
    Starts an EBS snapshot.  Returns as soon as job begins.

Please blog or twitter about s3.exe if you find it useful.");
        }
    }
}
