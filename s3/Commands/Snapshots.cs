using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

using com.amazon.s3;
using Amazon.EC2;
using Amazon.EC2.Model;

using s3.Options;

namespace s3.Commands
{
    class Snapshots : Command
    {
        protected override void Initialise(CommandLine commandLine) { }

        public override void Execute()
        {
            AmazonEC2Client client = new AmazonEC2Client(AWSAuthConnection.OUR_ACCESS_KEY_ID, AWSAuthConnection.OUR_SECRET_ACCESS_KEY);
            DescribeSnapshotsRequest request = new DescribeSnapshotsRequest();
            DescribeSnapshotsResponse response = client.DescribeSnapshots(request);

            Dictionary<string, List<Amazon.EC2.Model.Snapshot>> snapshots = new Dictionary<string, List<Amazon.EC2.Model.Snapshot>>();
            foreach (Amazon.EC2.Model.Snapshot r in response.DescribeSnapshotsResult.Snapshot)
            {
                if (!snapshots.ContainsKey(r.VolumeId))
                    snapshots[r.VolumeId] = new List<Amazon.EC2.Model.Snapshot>();

                snapshots[r.VolumeId].Add(r);
            }

            foreach (string volumeId in snapshots.Keys)
            {
                Console.WriteLine("--- Volume: {0}", volumeId);
                snapshots[volumeId].Sort(delegate(Amazon.EC2.Model.Snapshot x,Amazon.EC2.Model.Snapshot y) 
                    { return DateTime.Parse(x.StartTime).CompareTo(DateTime.Parse(y.StartTime)); });

                foreach (Amazon.EC2.Model.Snapshot s in snapshots[volumeId])
                {
                    DateTime startTime = DateTime.Parse(s.StartTime);
                    Console.Write("{0}\t{1}\t{2}\t{3}", s.SnapshotId, startTime, s.Progress, s.Status);
                    Console.WriteLine();
                }

                Console.WriteLine();
            }
        }

    }
}
