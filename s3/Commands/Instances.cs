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
    class Instances : Command
    {
        bool ips = false;

        protected override void Initialise(CommandLine commandLine) { }

        public override void Execute()
        {
            AmazonEC2Client client = new AmazonEC2Client(AWSAuthConnection.OUR_ACCESS_KEY_ID, AWSAuthConnection.OUR_SECRET_ACCESS_KEY);
            DescribeInstancesRequest request = new DescribeInstancesRequest();
            DescribeInstancesResponse response = client.DescribeInstances(request);

            Dictionary<string, List<RunningInstance>> instances = new Dictionary<string, List<RunningInstance>>();
            foreach (Reservation r in response.DescribeInstancesResult.Reservation)
                foreach (RunningInstance i in r.RunningInstance)
                {
                    if (!instances.ContainsKey(i.ImageId))
                        instances[i.ImageId] = new List<RunningInstance>();

                    instances[i.ImageId].Add(i);
                }

            List<string> allImageIds = new List<string>();
            foreach (string imageId in instances.Keys)
                allImageIds.Add(imageId);

            DescribeImagesRequest imageReq = new DescribeImagesRequest();
            imageReq.ImageId = allImageIds;
            DescribeImagesResponse imageResp = client.DescribeImages(imageReq);

            Dictionary<string, Image> imageDescriptions = new Dictionary<string, Image>();
            foreach (Image image in imageResp.DescribeImagesResult.Image)
                imageDescriptions.Add(image.ImageId, image);

            foreach (string imageId in instances.Keys)
            {
                if (imageDescriptions.ContainsKey(imageId))
                    Console.WriteLine("--- {0} {1} ({2} {3})",
                        imageId,
                        imageDescriptions[imageId].ImageLocation,
                        imageDescriptions[imageId].Platform,
                        imageDescriptions[imageId].Architecture);
                else
                    Console.WriteLine("--- {0} (AMI not found)", imageId);

                foreach (RunningInstance i in instances[imageId])
                {
                    DateTime launchTime = DateTime.Parse(i.LaunchTime);
                    Console.Write("{0}\t{1}\t{2}\t{3}\t{4}", launchTime, i.InstanceType, i.InstanceState.Name, i.InstanceId, i.StateTransitionReason);
                    if (ips)
                        Console.Write("\t{0}\t{1}", i.PublicDnsName, i.PrivateDnsName);
                    Console.WriteLine();
                }

                Console.WriteLine();
            }
        }

    }
}
