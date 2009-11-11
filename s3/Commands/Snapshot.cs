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
    class Snapshot : Command
    {
        string volumeId;

        protected override void initialise(CommandLine cl)
        {
            if (cl.args.Count == 1)
                volumeId = cl.args[0].Trim();
            else
                throw new SyntaxException("The snapshot command requires one parameter");
        }

        public override void execute()
        {
            Amazon.EC2.AmazonEC2Client client = new Amazon.EC2.AmazonEC2Client(AWSAuthConnection.OUR_ACCESS_KEY_ID, AWSAuthConnection.OUR_SECRET_ACCESS_KEY);
            Amazon.EC2.Model.CreateSnapshotRequest request = new Amazon.EC2.Model.CreateSnapshotRequest();
            request.VolumeId = volumeId;
            Amazon.EC2.Model.CreateSnapshotResponse response = client.CreateSnapshot(request);
            string snapshotId = response.CreateSnapshotResult.Snapshot.SnapshotId;
            Console.WriteLine("Started snapshot of volume {0} with snapshot ID {1}", volumeId, snapshotId);
        }

        public override string[] getHelpText()
        {
            return new string[] {@"
s3 snapshot <volumeID>
    Starts an EBS snapshot.  Returns as soon as job begins.
"};
        }
    }
}
