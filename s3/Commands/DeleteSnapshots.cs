using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

using com.amazon.s3;

using s3.Options;

using Amazon.EC2;
using Amazon.EC2.Model;

namespace s3.Commands
{
    class DeleteSnapshots : Command
    {
        bool isVolumeId;
        string id;
        int days;

        protected override void Initialise(CommandLine cl)
        {
            if (cl.args.Count == 1)
            {
                id = cl.args[0].Trim();
                isVolumeId = id.StartsWith("vol-", StringComparison.InvariantCultureIgnoreCase);
                if (isVolumeId)
                {
                    if (!cl.options.ContainsKey(typeof(Days)))
                        throw new SyntaxException("When specifying a volume ID, the /days option is required.  You can use /days:0 if needed.");
                    else
                        days = (cl.options[typeof(Days)] as Days).days;
                }
            }
            else
                throw new SyntaxException("The deletesnapshots command requires one parameter");
        }

        public override void Execute()
        {
            Amazon.EC2.AmazonEC2Client client = new Amazon.EC2.AmazonEC2Client(AWSAuthConnection.OUR_ACCESS_KEY_ID, AWSAuthConnection.OUR_SECRET_ACCESS_KEY);
            List<string> snapshotsToDelete = new List<string>();

            if (isVolumeId)
            {
                // delete snapshots belonging to this volume
                DescribeSnapshotsRequest request = new DescribeSnapshotsRequest();
                DescribeSnapshotsResponse response = client.DescribeSnapshots(request);

                foreach (Amazon.EC2.Model.Snapshot s in response.DescribeSnapshotsResult.Snapshot)
                {
                    if (string.Equals(s.VolumeId, id, StringComparison.InvariantCultureIgnoreCase))
                    {
                        DateTime snapshotDate = DateTime.Parse(s.StartTime);
                        if (snapshotDate.AddDays(days) < DateTime.Now)
                            snapshotsToDelete.Add(s.SnapshotId);
                    }
                }
            }
            else
            {
                snapshotsToDelete.Add(id);
            }

            foreach (string snapshotId in snapshotsToDelete)
            {
                Console.WriteLine("Deleting snapshot ID {0}", snapshotId);
                Amazon.EC2.Model.DeleteSnapshotRequest request = new Amazon.EC2.Model.DeleteSnapshotRequest();
                request.SnapshotId = snapshotId;
                Amazon.EC2.Model.DeleteSnapshotResponse response = client.DeleteSnapshot(request);
            }
        }
    }
}
