/******************************************************************************* 
 *  Copyright 2008 Amazon Technologies, Inc.
 *  Licensed under the Apache License, Version 2.0 (the "License"); 
 *  
 *  You may not use this file except in compliance with the License. 
 *  You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 *  specific language governing permissions and limitations under the License.
 * ***************************************************************************** 
 *    __  _    _  ___ 
 *   (  )( \/\/ )/ __)
 *   /__\ \    / \__ \
 *  (_)(_) \/\/  (___/
 * 
 *  Amazon EC2 CSharp Library
 *  API Version: 2008-12-01
 *  Generated: Fri Dec 26 23:53:41 PST 2008 
 * 
 */

using System;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Globalization;
using System.Xml.Serialization;
using System.Collections.Generic;
using Amazon.EC2.Model;
using Amazon.EC2.Util;
using Amazon.EC2;


namespace Amazon.EC2
{


   /**

    *
    * AmazonEC2Client is an implementation of AmazonEC2
    *
    */
    public class AmazonEC2Client : AmazonEC2
    {

        private String awsAccessKeyId = null;
        private String awsSecretAccessKey = null;
        private AmazonEC2Config config = null;

        /// <summary>
        /// Constructs AmazonEC2Client with AWS Access Key ID and AWS Secret Key
        /// </summary>
        /// <param name="awsAccessKeyId">AWS Access Key ID</param>
        /// <param name="awsSecretAccessKey">AWS Secret Access Key</param>
        public AmazonEC2Client(String awsAccessKeyId, String awsSecretAccessKey)
            : this(awsAccessKeyId, awsSecretAccessKey, new AmazonEC2Config())
        {
        }


        /// <summary>
        /// Constructs AmazonEC2Client with AWS Access Key ID and AWS Secret Key
        /// </summary>
        /// <param name="awsAccessKeyId">AWS Access Key ID</param>
        /// <param name="awsSecretAccessKey">AWS Secret Access Key</param>
        /// <param name="config">configuration</param>
        public AmazonEC2Client(String awsAccessKeyId, String awsSecretAccessKey, AmazonEC2Config config)
        {
            this.awsAccessKeyId = awsAccessKeyId;
            this.awsSecretAccessKey = awsSecretAccessKey;
            this.config = config;
        }


        // Public API ------------------------------------------------------------//

        
        /// <summary>
        /// Allocate Address 
        /// </summary>
        /// <param name="request">Allocate Address  request</param>
        /// <returns>Allocate Address  Response from the service</returns>
        /// <remarks>
        /// The AllocateAddress operation acquires an elastic IP address for use with your
        /// account.
        /// 
        /// </remarks>
        public AllocateAddressResponse AllocateAddress(AllocateAddressRequest request)
        {
            
            return Invoke<AllocateAddressResponse>(ConvertAllocateAddress(request));
        }

        
        /// <summary>
        /// Associate Address 
        /// </summary>
        /// <param name="request">Associate Address  request</param>
        /// <returns>Associate Address  Response from the service</returns>
        /// <remarks>
        /// The AssociateAddress operation associates an elastic IP address with an
        /// instance.
        /// If the IP address is currently assigned to another instance, the IP address is
        /// assigned to the new instance. This is an idempotent operation. If you enter it
        /// more than once, Amazon EC2 does not return an error.
        /// 
        /// </remarks>
        public AssociateAddressResponse AssociateAddress(AssociateAddressRequest request)
        {
            
            return Invoke<AssociateAddressResponse>(ConvertAssociateAddress(request));
        }

        
        /// <summary>
        /// Attach Volume 
        /// </summary>
        /// <param name="request">Attach Volume  request</param>
        /// <returns>Attach Volume  Response from the service</returns>
        /// <remarks>
        /// Attach a previously created volume to a running instance.
        /// 
        /// </remarks>
        public AttachVolumeResponse AttachVolume(AttachVolumeRequest request)
        {
            
            return Invoke<AttachVolumeResponse>(ConvertAttachVolume(request));
        }

        
        /// <summary>
        /// Authorize Security Group Ingress 
        /// </summary>
        /// <param name="request">Authorize Security Group Ingress  request</param>
        /// <returns>Authorize Security Group Ingress  Response from the service</returns>
        /// <remarks>
        /// The AuthorizeSecurityGroupIngress operation adds permissions to a security
        /// group.
        /// Permissions are specified by the IP protocol (TCP, UDP or ICMP), the source of
        /// the request (by IP range or an Amazon EC2 user-group pair), the source and
        /// destination port ranges (for TCP and UDP), and the ICMP codes and types (for
        /// ICMP). When authorizing ICMP, -1 can be used as a wildcard in the type and code
        /// fields.
        /// Permission changes are propagated to instances within the security group as
        /// quickly as possible. However, depending on the number of instances, a small
        /// delay might occur.
        /// When authorizing a user/group pair permission, GroupName,
        /// SourceSecurityGroupName and SourceSecurityGroupOwnerId must be specified. When
        /// authorizing a CIDR IP permission, GroupName, IpProtocol, FromPort, ToPort and
        /// CidrIp must be specified. Mixing these two types of parameters is not allowed.
        /// 
        /// </remarks>
        public AuthorizeSecurityGroupIngressResponse AuthorizeSecurityGroupIngress(AuthorizeSecurityGroupIngressRequest request)
        {
            
            return Invoke<AuthorizeSecurityGroupIngressResponse>(ConvertAuthorizeSecurityGroupIngress(request));
        }

        
        /// <summary>
        /// Bundle Instance 
        /// </summary>
        /// <param name="request">Bundle Instance  request</param>
        /// <returns>Bundle Instance  Response from the service</returns>
        /// <remarks>
        /// The BundleInstance operation request that an instance is bundled the next time it boots.
        /// The bundling process creates a new image from a running instance and stores
        /// the AMI data in S3. Once bundled, the image must be registered in the normal
        /// way using the RegisterImage API.
        /// 
        /// </remarks>
        public BundleInstanceResponse BundleInstance(BundleInstanceRequest request)
        {
            
            S3Storage s3 = request.Storage.S3;
            // Check to see if S3 upload policy was set on request.
            // If not, generate. Set expiration to 24 hours.
            if (!s3.IsSetUploadPolicy())
            {
                s3.AWSAccessKeyId = this.awsAccessKeyId;
                S3UploadPolicy policy = new S3UploadPolicy(this.awsAccessKeyId,
                            this.awsSecretAccessKey, s3.Bucket, s3.Prefix, 1440);
                s3.UploadPolicy = policy.PolicyString;
                s3.UploadPolicySignature = policy.PolicySignature;
            }

            
            return Invoke<BundleInstanceResponse>(ConvertBundleInstance(request));
        }

        
        /// <summary>
        /// Cancel Bundle Task 
        /// </summary>
        /// <param name="request">Cancel Bundle Task  request</param>
        /// <returns>Cancel Bundle Task  Response from the service</returns>
        /// <remarks>
        /// CancelBundleTask operation cancels a pending or
        /// in-progress bundling task. This is an asynchronous
        /// call and it make take a while for the task to be cancelled.
        /// If a task is cancelled while it is storing items,
        /// there may be parts of the incomplete AMI stored in S3.
        /// It is up to the caller to clean up these parts from S3.
        /// 
        /// </remarks>
        public CancelBundleTaskResponse CancelBundleTask(CancelBundleTaskRequest request)
        {
            
            return Invoke<CancelBundleTaskResponse>(ConvertCancelBundleTask(request));
        }

        
        /// <summary>
        /// Confirm Product Instance 
        /// </summary>
        /// <param name="request">Confirm Product Instance  request</param>
        /// <returns>Confirm Product Instance  Response from the service</returns>
        /// <remarks>
        /// The ConfirmProductInstance operation returns true if the specified product code
        /// is attached to the specified instance. The operation returns false if the
        /// product code is not attached to the instance.
        /// The ConfirmProductInstance operation can only be executed by the owner of the
        /// AMI. This feature is useful when an AMI owner is providing support and wants to
        /// verify whether a user's instance is eligible.
        /// 
        /// </remarks>
        public ConfirmProductInstanceResponse ConfirmProductInstance(ConfirmProductInstanceRequest request)
        {
            
            return Invoke<ConfirmProductInstanceResponse>(ConvertConfirmProductInstance(request));
        }

        
        /// <summary>
        /// Create Key Pair 
        /// </summary>
        /// <param name="request">Create Key Pair  request</param>
        /// <returns>Create Key Pair  Response from the service</returns>
        /// <remarks>
        /// The CreateKeyPair operation creates a new 2048 bit RSA key pair and returns a
        /// unique ID that can be used to reference this key pair when launching new
        /// instances. For more information, see RunInstances.
        /// 
        /// </remarks>
        public CreateKeyPairResponse CreateKeyPair(CreateKeyPairRequest request)
        {
            
            return Invoke<CreateKeyPairResponse>(ConvertCreateKeyPair(request));
        }

        
        /// <summary>
        /// Create Security Group 
        /// </summary>
        /// <param name="request">Create Security Group  request</param>
        /// <returns>Create Security Group  Response from the service</returns>
        /// <remarks>
        /// The CreateSecurityGroup operation creates a new security group.
        /// Every instance is launched in a security group. If no security group is
        /// specified during launch, the instances are launched in the default security
        /// group. Instances within the same security group have unrestricted network
        /// access to each other. Instances will reject network access attempts from other
        /// instances in a different security group. As the owner of instances you can
        /// grant or revoke specific permissions using the AuthorizeSecurityGroupIngress
        /// and RevokeSecurityGroupIngress operations.
        /// 
        /// </remarks>
        public CreateSecurityGroupResponse CreateSecurityGroup(CreateSecurityGroupRequest request)
        {
            
            return Invoke<CreateSecurityGroupResponse>(ConvertCreateSecurityGroup(request));
        }

        
        /// <summary>
        /// Create Snapshot 
        /// </summary>
        /// <param name="request">Create Snapshot  request</param>
        /// <returns>Create Snapshot  Response from the service</returns>
        /// <remarks>
        /// Create a snapshot of the volume identified by volume ID. A volume does not have to be detached
        /// at the time the snapshot is taken.
        /// Important Note:
        /// Snapshot creation requires that the system is in a consistent state.
        /// For instance, this means that if taking a snapshot of a database, the tables must
        /// be read-only locked to ensure that the snapshot will not contain a corrupted
        /// version of the database.  Therefore, be careful when using this API to ensure that
        /// the system remains in the consistent state until the create snapshot status
        /// has returned.
        /// 
        /// </remarks>
        public CreateSnapshotResponse CreateSnapshot(CreateSnapshotRequest request)
        {
            
            return Invoke<CreateSnapshotResponse>(ConvertCreateSnapshot(request));
        }

        
        /// <summary>
        /// Create Volume 
        /// </summary>
        /// <param name="request">Create Volume  request</param>
        /// <returns>Create Volume  Response from the service</returns>
        /// <remarks>
        /// Initializes an empty volume of a given size
        /// 
        /// </remarks>
        public CreateVolumeResponse CreateVolume(CreateVolumeRequest request)
        {
            
            return Invoke<CreateVolumeResponse>(ConvertCreateVolume(request));
        }

        
        /// <summary>
        /// Delete Key Pair 
        /// </summary>
        /// <param name="request">Delete Key Pair  request</param>
        /// <returns>Delete Key Pair  Response from the service</returns>
        /// <remarks>
        /// The DeleteKeyPair operation deletes a key pair.
        /// 
        /// </remarks>
        public DeleteKeyPairResponse DeleteKeyPair(DeleteKeyPairRequest request)
        {
            
            return Invoke<DeleteKeyPairResponse>(ConvertDeleteKeyPair(request));
        }

        
        /// <summary>
        /// Delete Security Group 
        /// </summary>
        /// <param name="request">Delete Security Group  request</param>
        /// <returns>Delete Security Group  Response from the service</returns>
        /// <remarks>
        /// The DeleteSecurityGroup operation deletes a security group.
        /// Note:
        /// If you attempt to delete a security group that contains instances, a fault is
        /// returned.
        /// If you attempt to delete a security group that is referenced by another
        /// security group, a fault is returned. For example, if security group B has a
        /// rule that allows access from security group A, security group A cannot be
        /// deleted until the allow rule is removed.
        /// 
        /// </remarks>
        public DeleteSecurityGroupResponse DeleteSecurityGroup(DeleteSecurityGroupRequest request)
        {
            
            return Invoke<DeleteSecurityGroupResponse>(ConvertDeleteSecurityGroup(request));
        }

        
        /// <summary>
        /// Delete Snapshot 
        /// </summary>
        /// <param name="request">Delete Snapshot  request</param>
        /// <returns>Delete Snapshot  Response from the service</returns>
        /// <remarks>
        /// Deletes the snapshot identitied by snapshotId.
        /// 
        /// </remarks>
        public DeleteSnapshotResponse DeleteSnapshot(DeleteSnapshotRequest request)
        {
            
            return Invoke<DeleteSnapshotResponse>(ConvertDeleteSnapshot(request));
        }

        
        /// <summary>
        /// Delete Volume 
        /// </summary>
        /// <param name="request">Delete Volume  request</param>
        /// <returns>Delete Volume  Response from the service</returns>
        /// <remarks>
        /// Deletes a  previously created volume. Once successfully deleted, a new volume  can be created with the same name.
        /// 
        /// </remarks>
        public DeleteVolumeResponse DeleteVolume(DeleteVolumeRequest request)
        {
            
            return Invoke<DeleteVolumeResponse>(ConvertDeleteVolume(request));
        }

        
        /// <summary>
        /// Deregister Image 
        /// </summary>
        /// <param name="request">Deregister Image  request</param>
        /// <returns>Deregister Image  Response from the service</returns>
        /// <remarks>
        /// The DeregisterImage operation deregisters an AMI. Once deregistered, instances
        /// of the AMI can no longer be launched.
        /// 
        /// </remarks>
        public DeregisterImageResponse DeregisterImage(DeregisterImageRequest request)
        {
            
            return Invoke<DeregisterImageResponse>(ConvertDeregisterImage(request));
        }

        
        /// <summary>
        /// Describe Addresses 
        /// </summary>
        /// <param name="request">Describe Addresses  request</param>
        /// <returns>Describe Addresses  Response from the service</returns>
        /// <remarks>
        /// The DescribeAddresses operation lists elastic IP addresses assigned to your
        /// account.
        /// 
        /// </remarks>
        public DescribeAddressesResponse DescribeAddresses(DescribeAddressesRequest request)
        {
            
            return Invoke<DescribeAddressesResponse>(ConvertDescribeAddresses(request));
        }

        
        /// <summary>
        /// Describe Availability Zones 
        /// </summary>
        /// <param name="request">Describe Availability Zones  request</param>
        /// <returns>Describe Availability Zones  Response from the service</returns>
        /// <remarks>
        /// The DescribeAvailabilityZones operation describes availability zones that are
        /// currently available to the account and their states.
        /// Availability zones are not the same across accounts. The availability zone
        /// us-east-1a for account A is not necessarily the same as us-east-1a for account
        /// B. Zone assignments are mapped independently for each account.
        /// 
        /// </remarks>
        public DescribeAvailabilityZonesResponse DescribeAvailabilityZones(DescribeAvailabilityZonesRequest request)
        {
            
            return Invoke<DescribeAvailabilityZonesResponse>(ConvertDescribeAvailabilityZones(request));
        }

        
        /// <summary>
        /// Describe Bundle Tasks 
        /// </summary>
        /// <param name="request">Describe Bundle Tasks  request</param>
        /// <returns>Describe Bundle Tasks  Response from the service</returns>
        /// <remarks>
        /// The DescribeBundleTasks operation describes in-progress
        /// and recent bundle tasks. Complete and failed tasks are
        /// removed from the list a short time after completion.
        /// If no bundle ids are given, all bundle tasks are returned.
        /// 
        /// </remarks>
        public DescribeBundleTasksResponse DescribeBundleTasks(DescribeBundleTasksRequest request)
        {
            
            return Invoke<DescribeBundleTasksResponse>(ConvertDescribeBundleTasks(request));
        }

        
        /// <summary>
        /// Describe Image Attribute 
        /// </summary>
        /// <param name="request">Describe Image Attribute  request</param>
        /// <returns>Describe Image Attribute  Response from the service</returns>
        /// <remarks>
        /// The DescribeImageAttribute operation returns information about an attribute of
        /// an AMI. Only one attribute can be specified per call.
        /// 
        /// </remarks>
        public DescribeImageAttributeResponse DescribeImageAttribute(DescribeImageAttributeRequest request)
        {
            
            return Invoke<DescribeImageAttributeResponse>(ConvertDescribeImageAttribute(request));
        }

        
        /// <summary>
        /// Describe Images 
        /// </summary>
        /// <param name="request">Describe Images  request</param>
        /// <returns>Describe Images  Response from the service</returns>
        /// <remarks>
        /// The DescribeImages operation returns information about AMIs, AKIs, and ARIs
        /// available to the user. Information returned includes image type, product codes,
        /// architecture, and kernel and RAM disk IDs. Images available to the user include
        /// public images available for any user to launch, private images owned by the
        /// user making the request, and private images owned by other users for which the
        /// user has explicit launch permissions.
        /// Launch permissions fall into three categories:
        /// Public:
        /// The owner of the AMI granted launch permissions for the AMI to the all group.
        /// All users have launch permissions for these AMIs.
        /// Explicit:
        /// The owner of the AMI granted launch permissions to a specific user.
        /// Implicit:
        /// A user has implicit launch permissions for all AMIs he or she owns.
        /// The list of AMIs returned can be modified by specifying AMI IDs, AMI owners, or
        /// users with launch permissions. If no options are specified, Amazon EC2 returns
        /// all AMIs for which the user has launch permissions.
        /// If you specify one or more AMI IDs, only AMIs that have the specified IDs are
        /// returned. If you specify an invalid AMI ID, a fault is returned. If you specify
        /// an AMI ID for which you do not have access, it will not be included in the
        /// returned results.
        /// If you specify one or more AMI owners, only AMIs from the specified owners and
        /// for which you have access are returned. The results can include the account IDs
        /// of the specified owners, amazon for AMIs owned by Amazon or self for AMIs that
        /// you own.
        /// If you specify a list of executable users, only users that have launch
        /// permissions for the AMIs are returned. You can specify account IDs (if you own
        /// the AMI(s)), self for AMIs for which you own or have explicit permissions, or
        /// all for public AMIs.
        /// Note:
        /// Deregistered images are included in the returned results for an unspecified
        /// interval after deregistration.
        /// 
        /// </remarks>
        public DescribeImagesResponse DescribeImages(DescribeImagesRequest request)
        {
            
            return Invoke<DescribeImagesResponse>(ConvertDescribeImages(request));
        }

        
        /// <summary>
        /// Describe Instances 
        /// </summary>
        /// <param name="request">Describe Instances  request</param>
        /// <returns>Describe Instances  Response from the service</returns>
        /// <remarks>
        /// The DescribeInstances operation returns information about instances that you
        /// own.
        /// If you specify one or more instance IDs, Amazon EC2 returns information for
        /// those instances. If you do not specify instance IDs, Amazon EC2 returns
        /// information for all relevant instances. If you specify an invalid instance ID,
        /// a fault is returned. If you specify an instance that you do not own, it will
        /// not be included in the returned results.
        /// Recently terminated instances might appear in the returned results. This
        /// interval is usually less than one hour.
        /// 
        /// </remarks>
        public DescribeInstancesResponse DescribeInstances(DescribeInstancesRequest request)
        {
            
            return Invoke<DescribeInstancesResponse>(ConvertDescribeInstances(request));
        }

        
        /// <summary>
        /// Describe Regions 
        /// </summary>
        /// <param name="request">Describe Regions  request</param>
        /// <returns>Describe Regions  Response from the service</returns>
        /// <remarks>
        /// The DescribeRegions operation describes regions zones that are currently available to the account.
        /// 
        /// </remarks>
        public DescribeRegionsResponse DescribeRegions(DescribeRegionsRequest request)
        {
            
            return Invoke<DescribeRegionsResponse>(ConvertDescribeRegions(request));
        }

        
        /// <summary>
        /// Describe Key Pairs 
        /// </summary>
        /// <param name="request">Describe Key Pairs  request</param>
        /// <returns>Describe Key Pairs  Response from the service</returns>
        /// <remarks>
        /// The DescribeKeyPairs operation returns information about key pairs available to
        /// you. If you specify key pairs, information about those key pairs is returned.
        /// Otherwise, information for all registered key pairs is returned.
        /// 
        /// </remarks>
        public DescribeKeyPairsResponse DescribeKeyPairs(DescribeKeyPairsRequest request)
        {
            
            return Invoke<DescribeKeyPairsResponse>(ConvertDescribeKeyPairs(request));
        }

        
        /// <summary>
        /// Describe Security Groups 
        /// </summary>
        /// <param name="request">Describe Security Groups  request</param>
        /// <returns>Describe Security Groups  Response from the service</returns>
        /// <remarks>
        /// The DescribeSecurityGroups operation returns information about security groups
        /// that you own.
        /// If you specify security group names, information about those security group is
        /// returned. Otherwise, information for all security group is returned. If you
        /// specify a group that does not exist, a fault is returned.
        /// 
        /// </remarks>
        public DescribeSecurityGroupsResponse DescribeSecurityGroups(DescribeSecurityGroupsRequest request)
        {
            
            return Invoke<DescribeSecurityGroupsResponse>(ConvertDescribeSecurityGroups(request));
        }

        
        /// <summary>
        /// Describe Snapshots 
        /// </summary>
        /// <param name="request">Describe Snapshots  request</param>
        /// <returns>Describe Snapshots  Response from the service</returns>
        /// <remarks>
        /// Describes the indicated snapshots, or in lieu of that, all snapshots owned by the caller.
        /// 
        /// </remarks>
        public DescribeSnapshotsResponse DescribeSnapshots(DescribeSnapshotsRequest request)
        {
            
            return Invoke<DescribeSnapshotsResponse>(ConvertDescribeSnapshots(request));
        }

        
        /// <summary>
        /// Describe Volumes 
        /// </summary>
        /// <param name="request">Describe Volumes  request</param>
        /// <returns>Describe Volumes  Response from the service</returns>
        /// <remarks>
        /// Describes the status of the indicated or, in lieu of any specified,  all volumes belonging to the caller. Volumes that have been deleted are not described.
        /// 
        /// </remarks>
        public DescribeVolumesResponse DescribeVolumes(DescribeVolumesRequest request)
        {
            
            return Invoke<DescribeVolumesResponse>(ConvertDescribeVolumes(request));
        }

        
        /// <summary>
        /// Detach Volume 
        /// </summary>
        /// <param name="request">Detach Volume  request</param>
        /// <returns>Detach Volume  Response from the service</returns>
        /// <remarks>
        /// Detach a previously attached volume from a running instance.
        /// 
        /// </remarks>
        public DetachVolumeResponse DetachVolume(DetachVolumeRequest request)
        {
            
            return Invoke<DetachVolumeResponse>(ConvertDetachVolume(request));
        }

        
        /// <summary>
        /// Disassociate Address 
        /// </summary>
        /// <param name="request">Disassociate Address  request</param>
        /// <returns>Disassociate Address  Response from the service</returns>
        /// <remarks>
        /// The DisassociateAddress operation disassociates the specified elastic IP
        /// address from the instance to which it is assigned. This is an idempotent
        /// operation. If you enter it more than once, Amazon EC2 does not return an error.
        /// 
        /// </remarks>
        public DisassociateAddressResponse DisassociateAddress(DisassociateAddressRequest request)
        {
            
            return Invoke<DisassociateAddressResponse>(ConvertDisassociateAddress(request));
        }

        
        /// <summary>
        /// Get Console Output 
        /// </summary>
        /// <param name="request">Get Console Output  request</param>
        /// <returns>Get Console Output  Response from the service</returns>
        /// <remarks>
        /// The GetConsoleOutput operation retrieves console output for the specified
        /// instance.
        /// Instance console output is buffered and posted shortly after instance boot,
        /// reboot, and termination. Amazon EC2 preserves the most recent 64 KB output
        /// which will be available for at least one hour after the most recent post.
        /// 
        /// </remarks>
        public GetConsoleOutputResponse GetConsoleOutput(GetConsoleOutputRequest request)
        {
            
            return Invoke<GetConsoleOutputResponse>(ConvertGetConsoleOutput(request));
        }

        
        /// <summary>
        /// Modify Image Attribute 
        /// </summary>
        /// <param name="request">Modify Image Attribute  request</param>
        /// <returns>Modify Image Attribute  Response from the service</returns>
        /// <remarks>
        /// The ModifyImageAttribute operation modifies an attribute of an AMI.
        /// 
        /// </remarks>
        public ModifyImageAttributeResponse ModifyImageAttribute(ModifyImageAttributeRequest request)
        {
            
            return Invoke<ModifyImageAttributeResponse>(ConvertModifyImageAttribute(request));
        }

        
        /// <summary>
        /// Reboot Instances 
        /// </summary>
        /// <param name="request">Reboot Instances  request</param>
        /// <returns>Reboot Instances  Response from the service</returns>
        /// <remarks>
        /// The RebootInstances operation requests a reboot of one or more instances. This
        /// operation is asynchronous; it only queues a request to reboot the specified
        /// instance(s). The operation will succeed if the instances are valid and belong
        /// to the user. Requests to reboot terminated instances are ignored.
        /// 
        /// </remarks>
        public RebootInstancesResponse RebootInstances(RebootInstancesRequest request)
        {
            
            return Invoke<RebootInstancesResponse>(ConvertRebootInstances(request));
        }

        
        /// <summary>
        /// Register Image 
        /// </summary>
        /// <param name="request">Register Image  request</param>
        /// <returns>Register Image  Response from the service</returns>
        /// <remarks>
        /// The RegisterImage operation registers an AMI with Amazon EC2. Images must be
        /// registered before they can be launched. For more information, see RunInstances.
        /// Each AMI is associated with an unique ID which is provided by the Amazon EC2
        /// service through the RegisterImage operation. During registration, Amazon EC2
        /// retrieves the specified image manifest from Amazon S3 and verifies that the
        /// image is owned by the user registering the image.
        /// The image manifest is retrieved once and stored within the Amazon EC2. Any
        /// modifications to an image in Amazon S3 invalidates this registration. If you
        /// make changes to an image, deregister the previous image and register the new
        /// image. For more information, see DeregisterImage.
        /// 
        /// </remarks>
        public RegisterImageResponse RegisterImage(RegisterImageRequest request)
        {
            
            return Invoke<RegisterImageResponse>(ConvertRegisterImage(request));
        }

        
        /// <summary>
        /// Release Address 
        /// </summary>
        /// <param name="request">Release Address  request</param>
        /// <returns>Release Address  Response from the service</returns>
        /// <remarks>
        /// The ReleaseAddress operation releases an elastic IP address associated with
        /// your account.
        /// Note:
        /// Releasing an IP address automatically disassociates it from any instance with
        /// which it is associated. For more information, see DisassociateAddress.
        /// Important:
        /// After releasing an elastic IP address, it is released to the IP address pool
        /// and might no longer be available to your account. Make sure to update your DNS
        /// records and any servers or devices that communicate with the address.
        /// If you run this operation on an elastic IP address that is already released,
        /// the address might be assigned to another account which will cause Amazon EC2 to
        /// return an error.
        /// 
        /// </remarks>
        public ReleaseAddressResponse ReleaseAddress(ReleaseAddressRequest request)
        {
            
            return Invoke<ReleaseAddressResponse>(ConvertReleaseAddress(request));
        }

        
        /// <summary>
        /// Reset Image Attribute 
        /// </summary>
        /// <param name="request">Reset Image Attribute  request</param>
        /// <returns>Reset Image Attribute  Response from the service</returns>
        /// <remarks>
        /// The ResetImageAttribute operation resets an attribute of an AMI to its default
        /// value.
        /// Note:
        /// The productCodes attribute cannot be reset.
        /// 
        /// </remarks>
        public ResetImageAttributeResponse ResetImageAttribute(ResetImageAttributeRequest request)
        {
            
            return Invoke<ResetImageAttributeResponse>(ConvertResetImageAttribute(request));
        }

        
        /// <summary>
        /// Revoke Security Group Ingress 
        /// </summary>
        /// <param name="request">Revoke Security Group Ingress  request</param>
        /// <returns>Revoke Security Group Ingress  Response from the service</returns>
        /// <remarks>
        /// The RevokeSecurityGroupIngress operation revokes permissions from a security
        /// group. The permissions used to revoke must be specified using the same values
        /// used to grant the permissions.
        /// Permissions are specified by IP protocol (TCP, UDP, or ICMP), the source of the
        /// request (by IP range or an Amazon EC2 user-group pair), the source and
        /// destination port ranges (for TCP and UDP), and the ICMP codes and types (for
        /// ICMP).
        /// Permission changes are quickly propagated to instances within the security
        /// group. However, depending on the number of instances in the group, a small
        /// delay is might occur, .
        /// When revoking a user/group pair permission, GroupName, SourceSecurityGroupName
        /// and SourceSecurityGroupOwnerId must be specified. When authorizing a CIDR IP
        /// permission, GroupName, IpProtocol, FromPort, ToPort and CidrIp must be
        /// specified. Mixing these two types of parameters is not allowed.
        /// 
        /// </remarks>
        public RevokeSecurityGroupIngressResponse RevokeSecurityGroupIngress(RevokeSecurityGroupIngressRequest request)
        {
            
            return Invoke<RevokeSecurityGroupIngressResponse>(ConvertRevokeSecurityGroupIngress(request));
        }

        
        /// <summary>
        /// Run Instances 
        /// </summary>
        /// <param name="request">Run Instances  request</param>
        /// <returns>Run Instances  Response from the service</returns>
        /// <remarks>
        /// The RunInstances operation launches a specified number of instances.
        /// If Amazon EC2 cannot launch the minimum number AMIs you request, no instances
        /// launch. If there is insufficient capacity to launch the maximum number of AMIs
        /// you request, Amazon EC2 launches as many as possible to satisfy the requested
        /// maximum values.
        /// Every instance is launched in a security group. If you do not specify a
        /// security group at launch, the instances start in your default security group.
        /// For more information on creating security groups, see CreateSecurityGroup.
        /// An optional instance type can be specified. For information about instance
        /// types, see Instance Types.
        /// You can provide an optional key pair ID for each image in the launch request
        /// (for more information, see CreateKeyPair). All instances that are created from
        /// images that use this key pair will have access to the associated public key at
        /// boot. You can use this key to provide secure access to an instance of an image
        /// on a per-instance basis. Amazon EC2 public images use this feature to provide
        /// secure access without passwords.
        /// Important:
        /// Launching public images without a key pair ID will leave them inaccessible.
        /// The public key material is made available to the instance at boot time by
        /// placing it in the openssh_id.pub file on a logical device that is exposed to
        /// the instance as /dev/sda2 (the ephemeral store). The format of this file is
        /// suitable for use as an entry within ~/.ssh/authorized_keys (the OpenSSH
        /// format). This can be done at boot (e.g., as part of rc.local) allowing for
        /// secure access without passwords.
        /// Optional user data can be provided in the launch request. All instances that
        /// collectively comprise the launch request have access to this data For more
        /// information, see Instance Metadata.
        /// Note:
        /// If any of the AMIs have a product code attached for which the user has not
        /// subscribed, the RunInstances call will fail.
        /// Important:
        /// We strongly recommend using the 2.6.18 Xen stock kernel with the c1.medium and
        /// c1.xlarge instances. Although the default Amazon EC2 kernels will work, the new
        /// kernels provide greater stability and performance for these instance types. For
        /// more information about kernels, see Kernels, RAM Disks, and Block Device
        /// Mappings.
        /// 
        /// </remarks>
        public RunInstancesResponse RunInstances(RunInstancesRequest request)
        {
            
            return Invoke<RunInstancesResponse>(ConvertRunInstances(request));
        }

        
        /// <summary>
        /// Terminate Instances 
        /// </summary>
        /// <param name="request">Terminate Instances  request</param>
        /// <returns>Terminate Instances  Response from the service</returns>
        /// <remarks>
        /// The TerminateInstances operation shuts down one or more instances. This
        /// operation is idempotent; if you terminate an instance more than once, each call
        /// will succeed.
        /// Terminated instances will remain visible after termination (approximately one
        /// hour).
        /// 
        /// </remarks>
        public TerminateInstancesResponse TerminateInstances(TerminateInstancesRequest request)
        {
            
            return Invoke<TerminateInstancesResponse>(ConvertTerminateInstances(request));
        }

        // Private API ------------------------------------------------------------//

        /**
         * Configure HttpClient with set of defaults as well as configuration
         * from AmazonEC2Config instance
         */
        private HttpWebRequest ConfigureWebRequest(int contentLength)
        {
            HttpWebRequest request = WebRequest.Create(config.ServiceURL) as HttpWebRequest;

            if (config.IsSetProxyHost())
            {
                request.Proxy = new WebProxy(config.ProxyHost, config.ProxyPort);
            }
            request.UserAgent = config.UserAgent;
            request.Method = "POST";
            request.Timeout = 50000;
            request.ContentType = "application/x-www-form-urlencoded; charset=utf-8";
            request.ContentLength = contentLength;

            return request;
        }

        /**
         * Invoke request and return response
         */
        private T Invoke<T>(IDictionary<String, String> parameters)
        {
            String actionName = parameters["Action"];
            T response = default(T);
            String responseBody = null;
            HttpStatusCode statusCode = default(HttpStatusCode);

            /* Add required request parameters */
            AddRequiredParameters(parameters);

            String queryString = GetParametersAsString(parameters);

            byte[] requestData = new UTF8Encoding().GetBytes(queryString);
            bool shouldRetry = true;
            int retries = 0;
            do
            {
                HttpWebRequest request = ConfigureWebRequest(requestData.Length);
                /* Submit the request and read response body */
                try
                {
                    using (Stream requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(requestData, 0, requestData.Length);
                    }
                    using (HttpWebResponse httpResponse = request.GetResponse() as HttpWebResponse)
                    {
                        statusCode = httpResponse.StatusCode;
                        StreamReader reader = new StreamReader(httpResponse.GetResponseStream(), Encoding.UTF8);
                        responseBody = reader.ReadToEnd();
                    }

                    /* Perform response transformation */
                    if (responseBody.EndsWith(actionName + "Response>"))
                    {
                        responseBody = transform(responseBody, actionName);
                    }

                    /* Attempt to deserialize response into <Action> Response type */
                    XmlSerializer serlizer = new XmlSerializer(typeof(T));
                    response = (T)serlizer.Deserialize(new StringReader(responseBody));
                    shouldRetry = false;
                }
                /* Web exception is thrown on unsucessful responses */
                catch (WebException we)
                {
                    shouldRetry = false;
                    using (HttpWebResponse httpErrorResponse = (HttpWebResponse)we.Response as HttpWebResponse)
                    {
                        if (httpErrorResponse == null)
                        {
                            throw new AmazonEC2Exception(we);
                        }
                        statusCode = httpErrorResponse.StatusCode;
                        StreamReader reader = new StreamReader(httpErrorResponse.GetResponseStream(), Encoding.UTF8);
                        responseBody = reader.ReadToEnd();
                    }

                    if (statusCode == HttpStatusCode.InternalServerError || statusCode == HttpStatusCode.ServiceUnavailable)
                    {
                        shouldRetry = true;
                        PauseOnRetry(++retries, statusCode);
                    }
                    else
                    {

                        /* Attempt to deserialize response into ErrorResponse type */
                        try
                        {
                            XmlSerializer serlizer = new XmlSerializer(typeof(ErrorResponse));
                            ErrorResponse errorResponse = (ErrorResponse)serlizer.Deserialize(new StringReader(responseBody));
                            Error error = errorResponse.Error[0];

                            /* Throw formatted exception with information available from the error response */
                            throw new AmazonEC2Exception(
                                error.Message,
                                statusCode,
                                error.Code,
                                error.Type,
                                errorResponse.RequestId,
                                errorResponse.ToXML());
                        }
                        /* Rethrow on deserializer error */
                        catch (Exception e)
                        {
                            if (e is AmazonEC2Exception)
                            {
                                throw e;
                            }
                            else
                            {
                                AmazonEC2Exception se = ReportAnyErrors(responseBody, statusCode, e);
                                throw se;
                            }
                        }
                    }
                }

                /* Catch other exceptions, attempt to convert to formatted exception,
                 * else rethrow wrapped exception */
                catch (Exception e)
                {
                    throw new AmazonEC2Exception(e);
                }
            } while (shouldRetry);

            return response;
        }


        /**
         * Look for additional error strings in the response and return formatted exception
         */
        private AmazonEC2Exception ReportAnyErrors(String responseBody, HttpStatusCode status, Exception e)
        {

            AmazonEC2Exception ex = null;

            if (responseBody != null && responseBody.StartsWith("<"))
            {
                Match errorMatcherOne = Regex.Match(responseBody, "<RequestId>(.*)</RequestId>.*<Error>" +
                        "<Code>(.*)</Code><Message>(.*)</Message></Error>.*(<Error>)?", RegexOptions.Multiline);
                Match errorMatcherTwo = Regex.Match(responseBody, "<Error><Code>(.*)</Code><Message>(.*)" +
                        "</Message></Error>.*(<Error>)?.*<RequestID>(.*)</RequestID>", RegexOptions.Multiline);

                if (errorMatcherOne.Success)
                {
                    String requestId = errorMatcherOne.Groups[1].Value;
                    String code = errorMatcherOne.Groups[2].Value;
                    String message = errorMatcherOne.Groups[3].Value;

                    ex = new AmazonEC2Exception(message, status, code, "Unknown", requestId, responseBody);

                }
                else if (errorMatcherTwo.Success)
                {
                    String code = errorMatcherTwo.Groups[1].Value;
                    String message = errorMatcherTwo.Groups[2].Value;
                    String requestId = errorMatcherTwo.Groups[4].Value;

                    ex = new AmazonEC2Exception(message, status, code, "Unknown", requestId, responseBody);
                }
                else
                {
                    ex = new AmazonEC2Exception("Internal Error", status);
                }
            }
            else
            {
                ex = new AmazonEC2Exception("Internal Error", status);
            }
            return ex;
        }

        /**
         * Exponential sleep on failed request
         */
        private void PauseOnRetry(int retries, HttpStatusCode status)
        {
            if (retries <= config.MaxErrorRetry)
            {
                int delay = (int)Math.Pow(4, retries) * 100;
                System.Threading.Thread.Sleep(delay);
            }
            else
            {
                throw new AmazonEC2Exception("Maximum number of retry attempts reached : " + (retries - 1), status);
            }
        }

        /**
         * Add authentication related and version parameters
         */
        private void AddRequiredParameters(IDictionary<String, String> parameters)
        {
            parameters.Add("AWSAccessKeyId", this.awsAccessKeyId);
            parameters.Add("Timestamp", GetFormattedTimestamp());
            parameters.Add("Version", config.ServiceVersion);
            parameters.Add("SignatureVersion", config.SignatureVersion);
            parameters.Add("Signature", SignParameters(parameters, this.awsSecretAccessKey));
        }

        /**
         * Convert Dictionary of paremeters to Url encoded query string
         */
        private string GetParametersAsString(IDictionary<String, String> parameters)
        {
            StringBuilder data = new StringBuilder();
            foreach (String key in (IEnumerable<String>)parameters.Keys)
            {
                String value = parameters[key];
                if (value != null)
                {
                    data.Append(key);
                    data.Append('=');
                    data.Append(UrlEncode(value, false));
                    data.Append('&');
                }
            }
            String result = data.ToString();
            return result.Remove(result.Length - 1);
        }

        /**
         * Computes RFC 2104-compliant HMAC signature for request parameters
         * Implements AWS Signature, as per following spec:
         *
         * If Signature Version is 0, it signs concatenated Action and Timestamp
         *
         * If Signature Version is 1, it performs the following:
         *
         * Sorts all  parameters (including SignatureVersion and excluding Signature,
         * the value of which is being created), ignoring case.
         *
         * Iterate over the sorted list and append the parameter name (in original case)
         * and then its value. It will not URL-encode the parameter values before
         * constructing this string. There are no separators.
         *
         * If Signature Version is 2, string to sign is based on following:
         *
         *    1. The HTTP Request Method followed by an ASCII newline (%0A)
         *    2. The HTTP Host header in the form of lowercase host, followed by an ASCII newline.
         *    3. The URL encoded HTTP absolute path component of the URI
         *       (up to but not including the query string parameters);
         *       if this is empty use a forward '/'. This parameter is followed by an ASCII newline.
         *    4. The concatenation of all query string components (names and values)
         *       as UTF-8 characters which are URL encoded as per RFC 3986
         *       (hex characters MUST be uppercase), sorted using lexicographic byte ordering.
         *       Parameter names are separated from their values by the '=' character
         *       (ASCII character 61), even if the value is empty.
         *       Pairs of parameter and values are separated by the '&' character (ASCII code 38).
         *
         */
        private String SignParameters(IDictionary<String, String> parameters, String key)
        {
            String signatureVersion = parameters["SignatureVersion"];

            KeyedHashAlgorithm algorithm = new HMACSHA1();

            String stringToSign = null;
            if ("0".Equals(signatureVersion))
            {
                stringToSign = CalculateStringToSignV0(parameters);
            }
            else if ("1".Equals(signatureVersion))
            {
                stringToSign = CalculateStringToSignV1(parameters);
            }
            else if ("2".Equals(signatureVersion))
            {
                String signatureMethod = config.SignatureMethod;
                algorithm = KeyedHashAlgorithm.Create(signatureMethod.ToUpper());
                parameters.Add("SignatureMethod", signatureMethod);
                stringToSign = CalculateStringToSignV2(parameters);
            }
            else
            {
                throw new Exception("Invalid Signature Version specified");
            }

            return Sign(stringToSign, key, algorithm);
        }

        private String CalculateStringToSignV0(IDictionary<String, String> parameters)
        {
            StringBuilder data = new StringBuilder();
            return data.Append(parameters["Action"]).Append(parameters["Timestamp"]).ToString();

        }

        private String CalculateStringToSignV1(IDictionary<String, String> parameters)
        {
            StringBuilder data = new StringBuilder();
                IDictionary<String, String> sorted =
                  new SortedDictionary<String, String>(parameters, StringComparer.OrdinalIgnoreCase);
                foreach (KeyValuePair<String, String> pair in sorted)
                {
                    if (pair.Value != null)
                    {
                        data.Append(pair.Key);
                        data.Append(pair.Value);
                    }
                }
            return data.ToString();
        }

        private String CalculateStringToSignV2(IDictionary<String, String> parameters)
        {
            StringBuilder data = new StringBuilder();
            IDictionary<String, String> sorted =
                  new SortedDictionary<String, String>(parameters, StringComparer.Ordinal);
            data.Append("POST");
            data.Append("\n");
            Uri endpoint = new Uri(config.ServiceURL.ToLower());

            data.Append(endpoint.Host);
            data.Append("\n");
            String uri = endpoint.AbsolutePath;
            if (uri == null || uri.Length == 0)
            {
                uri = "/";
            }
            data.Append(UrlEncode(uri, true));
            data.Append("\n");
            foreach (KeyValuePair<String, String> pair in sorted)
            {
                if (pair.Value != null)
                {
                    data.Append(UrlEncode(pair.Key, false));
                    data.Append("=");
                    data.Append(UrlEncode(pair.Value, false));
                    data.Append("&");
                }

            }

            String result = data.ToString();
            return result.Remove(result.Length - 1);
        }

        private String UrlEncode(String data, bool path)
        {
            StringBuilder encoded = new StringBuilder();
            String unreservedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~" + (path ? "/" : "");

            foreach (char symbol in System.Text.Encoding.UTF8.GetBytes(data))
            {
                if (unreservedChars.IndexOf(symbol) != -1)
                {
                    encoded.Append(symbol);
            }
            else
            {
                    encoded.Append("%" + String.Format("{0:X2}", (int)symbol));
            }
            }

            return encoded.ToString();

        }

        /**
         * Computes RFC 2104-compliant HMAC signature.
         */
        private String Sign(String data, String key, KeyedHashAlgorithm algorithm)
        {
            Encoding encoding = new UTF8Encoding();
            algorithm.Key = encoding.GetBytes(key);
            return Convert.ToBase64String(algorithm.ComputeHash(
                encoding.GetBytes(data.ToCharArray())));
        }


        /**
         * Formats date as ISO 8601 timestamp
         */
        private String GetFormattedTimestamp()
        {
            DateTime dateTime = DateTime.Now;
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day,
                                 dateTime.Hour, dateTime.Minute, dateTime.Second,
                                 dateTime.Millisecond
                                 , DateTimeKind.Local
                               ).ToUniversalTime().ToString("yyyy-MM-dd\\THH:mm:ss.fff\\Z",
                                CultureInfo.InvariantCulture);
        }


        
        /**
         * Convert AllocateAddressRequest to name value pairs
         */
        private IDictionary<String, String> ConvertAllocateAddress(AllocateAddressRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "AllocateAddress");

            return parameters;
        }
        
                        
        /**
         * Convert AssociateAddressRequest to name value pairs
         */
        private IDictionary<String, String> ConvertAssociateAddress(AssociateAddressRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "AssociateAddress");
            if (request.IsSetInstanceId())
            {
                parameters.Add("InstanceId", request.InstanceId);
            }
            if (request.IsSetPublicIp())
            {
                parameters.Add("PublicIp", request.PublicIp);
            }

            return parameters;
        }
        
                        
        /**
         * Convert AuthorizeSecurityGroupIngressRequest to name value pairs
         */
        private IDictionary<String, String> ConvertAuthorizeSecurityGroupIngress(AuthorizeSecurityGroupIngressRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "AuthorizeSecurityGroupIngress");
            if (request.IsSetGroupName())
            {
                parameters.Add("GroupName", request.GroupName);
            }
            if (request.IsSetSourceSecurityGroupName())
            {
                parameters.Add("SourceSecurityGroupName", request.SourceSecurityGroupName);
            }
            if (request.IsSetSourceSecurityGroupOwnerId())
            {
                parameters.Add("SourceSecurityGroupOwnerId", request.SourceSecurityGroupOwnerId);
            }
            if (request.IsSetIpProtocol())
            {
                parameters.Add("IpProtocol", request.IpProtocol);
            }
            if (request.IsSetFromPort())
            {
                parameters.Add("FromPort", request.FromPort + "");
            }
            if (request.IsSetToPort())
            {
                parameters.Add("ToPort", request.ToPort + "");
            }
            if (request.IsSetCidrIp())
            {
                parameters.Add("CidrIp", request.CidrIp);
            }

            return parameters;
        }
        
                        
        /**
         * Convert BundleInstanceRequest to name value pairs
         */
        private IDictionary<String, String> ConvertBundleInstance(BundleInstanceRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "BundleInstance");
            if (request.IsSetInstanceId())
            {
                parameters.Add("InstanceId", request.InstanceId);
            }
            if (request.IsSetStorage())
            {
                Storage  storage = request.Storage;
                if (storage.IsSetS3())
                {
                    S3Storage  s3 = storage.S3;
                    if (s3.IsSetBucket())
                    {
                        parameters.Add("Storage" + "." + "S3" + "." + "Bucket", s3.Bucket);
                    }
                    if (s3.IsSetPrefix())
                    {
                        parameters.Add("Storage" + "." + "S3" + "." + "Prefix", s3.Prefix);
                    }
                    if (s3.IsSetAWSAccessKeyId())
                    {
                        parameters.Add("Storage" + "." + "S3" + "." + "AWSAccessKeyId", s3.AWSAccessKeyId);
                    }
                    if (s3.IsSetUploadPolicy())
                    {
                        parameters.Add("Storage" + "." + "S3" + "." + "UploadPolicy", s3.UploadPolicy);
                    }
                    if (s3.IsSetUploadPolicySignature())
                    {
                        parameters.Add("Storage" + "." + "S3" + "." + "UploadPolicySignature", s3.UploadPolicySignature);
                    }
                }
            }

            return parameters;
        }
        
                        
        /**
         * Convert ConfirmProductInstanceRequest to name value pairs
         */
        private IDictionary<String, String> ConvertConfirmProductInstance(ConfirmProductInstanceRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "ConfirmProductInstance");
            if (request.IsSetProductCode())
            {
                parameters.Add("ProductCode", request.ProductCode);
            }
            if (request.IsSetInstanceId())
            {
                parameters.Add("InstanceId", request.InstanceId);
            }

            return parameters;
        }
        
                
        /**
         * Convert CancelBundleTaskRequest to name value pairs
         */
        private IDictionary<String, String> ConvertCancelBundleTask(CancelBundleTaskRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "CancelBundleTask");
            if (request.IsSetBundleId())
            {
                parameters.Add("BundleId", request.BundleId);
            }

            return parameters;
        }
        
                                
        /**
         * Convert CreateKeyPairRequest to name value pairs
         */
        private IDictionary<String, String> ConvertCreateKeyPair(CreateKeyPairRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "CreateKeyPair");
            if (request.IsSetKeyName())
            {
                parameters.Add("KeyName", request.KeyName);
            }

            return parameters;
        }
        
                        
        /**
         * Convert CreateSecurityGroupRequest to name value pairs
         */
        private IDictionary<String, String> ConvertCreateSecurityGroup(CreateSecurityGroupRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "CreateSecurityGroup");
            if (request.IsSetGroupName())
            {
                parameters.Add("GroupName", request.GroupName);
            }
            if (request.IsSetGroupDescription())
            {
                parameters.Add("GroupDescription", request.GroupDescription);
            }

            return parameters;
        }
        
                        
        /**
         * Convert DeleteKeyPairRequest to name value pairs
         */
        private IDictionary<String, String> ConvertDeleteKeyPair(DeleteKeyPairRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "DeleteKeyPair");
            if (request.IsSetKeyName())
            {
                parameters.Add("KeyName", request.KeyName);
            }

            return parameters;
        }
        
                        
        /**
         * Convert DeleteSecurityGroupRequest to name value pairs
         */
        private IDictionary<String, String> ConvertDeleteSecurityGroup(DeleteSecurityGroupRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "DeleteSecurityGroup");
            if (request.IsSetGroupName())
            {
                parameters.Add("GroupName", request.GroupName);
            }

            return parameters;
        }
        
                        
        /**
         * Convert DeregisterImageRequest to name value pairs
         */
        private IDictionary<String, String> ConvertDeregisterImage(DeregisterImageRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "DeregisterImage");
            if (request.IsSetImageId())
            {
                parameters.Add("ImageId", request.ImageId);
            }

            return parameters;
        }
        
                        
        /**
         * Convert DescribeAddressesRequest to name value pairs
         */
        private IDictionary<String, String> ConvertDescribeAddresses(DescribeAddressesRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "DescribeAddresses");
            List<String> publicIpList  =  request.PublicIp;
            foreach  (String publicIp in publicIpList)
            {
                parameters.Add("PublicIp" + "."  + (publicIpList.IndexOf(publicIp) + 1), publicIp);
            }

            return parameters;
        }
        
                        
        /**
         * Convert DescribeAvailabilityZonesRequest to name value pairs
         */
        private IDictionary<String, String> ConvertDescribeAvailabilityZones(DescribeAvailabilityZonesRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "DescribeAvailabilityZones");
            List<String> zoneNameList  =  request.ZoneName;
            foreach  (String zoneName in zoneNameList)
            {
                parameters.Add("ZoneName" + "."  + (zoneNameList.IndexOf(zoneName) + 1), zoneName);
            }

            return parameters;
        }
        
                        
        /**
         * Convert DescribeBundleTasksRequest to name value pairs
         */
        private IDictionary<String, String> ConvertDescribeBundleTasks(DescribeBundleTasksRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "DescribeBundleTasks");
            List<String> bundleIdList  =  request.BundleId;
            foreach  (String bundleId in bundleIdList)
            {
                parameters.Add("BundleId" + "."  + (bundleIdList.IndexOf(bundleId) + 1), bundleId);
            }

            return parameters;
        }
        
                        
        /**
         * Convert DescribeImageAttributeRequest to name value pairs
         */
        private IDictionary<String, String> ConvertDescribeImageAttribute(DescribeImageAttributeRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "DescribeImageAttribute");
            if (request.IsSetImageId())
            {
                parameters.Add("ImageId", request.ImageId);
            }
            if (request.IsSetAttribute())
            {
                parameters.Add("Attribute", request.Attribute);
            }

            return parameters;
        }
        
                        
        /**
         * Convert DescribeImagesRequest to name value pairs
         */
        private IDictionary<String, String> ConvertDescribeImages(DescribeImagesRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "DescribeImages");
            List<String> imageIdList  =  request.ImageId;
            foreach  (String imageId in imageIdList)
            {
                parameters.Add("ImageId" + "."  + (imageIdList.IndexOf(imageId) + 1), imageId);
            }
            List<String> ownerList  =  request.Owner;
            foreach  (String owner in ownerList)
            {
                parameters.Add("Owner" + "."  + (ownerList.IndexOf(owner) + 1), owner);
            }
            List<String> executableByList  =  request.ExecutableBy;
            foreach  (String executableBy in executableByList)
            {
                parameters.Add("ExecutableBy" + "."  + (executableByList.IndexOf(executableBy) + 1), executableBy);
            }

            return parameters;
        }
        
                        
        /**
         * Convert DescribeInstancesRequest to name value pairs
         */
        private IDictionary<String, String> ConvertDescribeInstances(DescribeInstancesRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "DescribeInstances");
            List<String> instanceIdList  =  request.InstanceId;
            foreach  (String instanceId in instanceIdList)
            {
                parameters.Add("InstanceId" + "."  + (instanceIdList.IndexOf(instanceId) + 1), instanceId);
            }

            return parameters;
        }
        
                        
        /**
         * Convert DescribeKeyPairsRequest to name value pairs
         */
        private IDictionary<String, String> ConvertDescribeKeyPairs(DescribeKeyPairsRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "DescribeKeyPairs");
            List<String> keyNameList  =  request.KeyName;
            foreach  (String keyName in keyNameList)
            {
                parameters.Add("KeyName" + "."  + (keyNameList.IndexOf(keyName) + 1), keyName);
            }

            return parameters;
        }
        
                        
        /**
         * Convert DescribeSecurityGroupsRequest to name value pairs
         */
        private IDictionary<String, String> ConvertDescribeSecurityGroups(DescribeSecurityGroupsRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "DescribeSecurityGroups");
            List<String> groupNameList  =  request.GroupName;
            foreach  (String groupName in groupNameList)
            {
                parameters.Add("GroupName" + "."  + (groupNameList.IndexOf(groupName) + 1), groupName);
            }

            return parameters;
        }
        
                        
        /**
         * Convert DisassociateAddressRequest to name value pairs
         */
        private IDictionary<String, String> ConvertDisassociateAddress(DisassociateAddressRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "DisassociateAddress");
            if (request.IsSetPublicIp())
            {
                parameters.Add("PublicIp", request.PublicIp);
            }

            return parameters;
        }
        
                        
        /**
         * Convert GetConsoleOutputRequest to name value pairs
         */
        private IDictionary<String, String> ConvertGetConsoleOutput(GetConsoleOutputRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "GetConsoleOutput");
            if (request.IsSetInstanceId())
            {
                parameters.Add("InstanceId", request.InstanceId);
            }

            return parameters;
        }
        
                        
        /**
         * Convert ModifyImageAttributeRequest to name value pairs
         */
        private IDictionary<String, String> ConvertModifyImageAttribute(ModifyImageAttributeRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "ModifyImageAttribute");
            if (request.IsSetImageId())
            {
                parameters.Add("ImageId", request.ImageId);
            }
            if (request.IsSetAttribute())
            {
                parameters.Add("Attribute", request.Attribute);
            }
            if (request.IsSetOperationType())
            {
                parameters.Add("OperationType", request.OperationType);
            }
            List<String> userIdList  =  request.UserId;
            foreach  (String userId in userIdList)
            {
                parameters.Add("UserId" + "."  + (userIdList.IndexOf(userId) + 1), userId);
            }
            List<String> userGroupList  =  request.UserGroup;
            foreach  (String userGroup in userGroupList)
            {
                parameters.Add("UserGroup" + "."  + (userGroupList.IndexOf(userGroup) + 1), userGroup);
            }
            List<String> productCodeList  =  request.ProductCode;
            foreach  (String productCode in productCodeList)
            {
                parameters.Add("ProductCode" + "."  + (productCodeList.IndexOf(productCode) + 1), productCode);
            }

            return parameters;
        }
        
                        
        /**
         * Convert RebootInstancesRequest to name value pairs
         */
        private IDictionary<String, String> ConvertRebootInstances(RebootInstancesRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "RebootInstances");
            List<String> instanceIdList  =  request.InstanceId;
            foreach  (String instanceId in instanceIdList)
            {
                parameters.Add("InstanceId" + "."  + (instanceIdList.IndexOf(instanceId) + 1), instanceId);
            }

            return parameters;
        }
        
                        
        /**
         * Convert RegisterImageRequest to name value pairs
         */
        private IDictionary<String, String> ConvertRegisterImage(RegisterImageRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "RegisterImage");
            if (request.IsSetImageLocation())
            {
                parameters.Add("ImageLocation", request.ImageLocation);
            }

            return parameters;
        }
        
                        
        /**
         * Convert ReleaseAddressRequest to name value pairs
         */
        private IDictionary<String, String> ConvertReleaseAddress(ReleaseAddressRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "ReleaseAddress");
            if (request.IsSetPublicIp())
            {
                parameters.Add("PublicIp", request.PublicIp);
            }

            return parameters;
        }
        
                        
        /**
         * Convert ResetImageAttributeRequest to name value pairs
         */
        private IDictionary<String, String> ConvertResetImageAttribute(ResetImageAttributeRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "ResetImageAttribute");
            if (request.IsSetImageId())
            {
                parameters.Add("ImageId", request.ImageId);
            }
            if (request.IsSetAttribute())
            {
                parameters.Add("Attribute", request.Attribute);
            }

            return parameters;
        }
        
                        
        /**
         * Convert RevokeSecurityGroupIngressRequest to name value pairs
         */
        private IDictionary<String, String> ConvertRevokeSecurityGroupIngress(RevokeSecurityGroupIngressRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "RevokeSecurityGroupIngress");
            if (request.IsSetGroupName())
            {
                parameters.Add("GroupName", request.GroupName);
            }
            if (request.IsSetSourceSecurityGroupName())
            {
                parameters.Add("SourceSecurityGroupName", request.SourceSecurityGroupName);
            }
            if (request.IsSetSourceSecurityGroupOwnerId())
            {
                parameters.Add("SourceSecurityGroupOwnerId", request.SourceSecurityGroupOwnerId);
            }
            if (request.IsSetIpProtocol())
            {
                parameters.Add("IpProtocol", request.IpProtocol);
            }
            if (request.IsSetFromPort())
            {
                parameters.Add("FromPort", request.FromPort + "");
            }
            if (request.IsSetToPort())
            {
                parameters.Add("ToPort", request.ToPort + "");
            }
            if (request.IsSetCidrIp())
            {
                parameters.Add("CidrIp", request.CidrIp);
            }

            return parameters;
        }
        
                        
        /**
         * Convert RunInstancesRequest to name value pairs
         */
        private IDictionary<String, String> ConvertRunInstances(RunInstancesRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "RunInstances");
            if (request.IsSetImageId())
            {
                parameters.Add("ImageId", request.ImageId);
            }
            if (request.IsSetMinCount())
            {
                parameters.Add("MinCount", request.MinCount + "");
            }
            if (request.IsSetMaxCount())
            {
                parameters.Add("MaxCount", request.MaxCount + "");
            }
            if (request.IsSetKeyName())
            {
                parameters.Add("KeyName", request.KeyName);
            }
            List<String> securityGroupList  =  request.SecurityGroup;
            foreach  (String securityGroup in securityGroupList)
            {
                parameters.Add("SecurityGroup" + "."  + (securityGroupList.IndexOf(securityGroup) + 1), securityGroup);
            }
            if (request.IsSetUserData())
            {
                parameters.Add("UserData", request.UserData);
            }
            if (request.IsSetInstanceType())
            {
                parameters.Add("InstanceType", request.InstanceType);
            }
            if (request.IsSetPlacement())
            {
                Placement  placement = request.Placement;
                if (placement.IsSetAvailabilityZone())
                {
                    parameters.Add("Placement" + "." + "AvailabilityZone", placement.AvailabilityZone);
                }
            }
            if (request.IsSetKernelId())
            {
                parameters.Add("KernelId", request.KernelId);
            }
            if (request.IsSetRamdiskId())
            {
                parameters.Add("RamdiskId", request.RamdiskId);
            }
            List<BlockDeviceMapping> blockDeviceMappingList = request.BlockDeviceMapping;
            foreach (BlockDeviceMapping blockDeviceMapping in blockDeviceMappingList)
            {
                if (blockDeviceMapping.IsSetVirtualName())
                {
                    parameters.Add("BlockDeviceMapping" + "."  + (blockDeviceMappingList.IndexOf(blockDeviceMapping) + 1) + "." + "VirtualName", blockDeviceMapping.VirtualName);
                }
                if (blockDeviceMapping.IsSetDeviceName())
                {
                    parameters.Add("BlockDeviceMapping" + "."  + (blockDeviceMappingList.IndexOf(blockDeviceMapping) + 1) + "." + "DeviceName", blockDeviceMapping.DeviceName);
                }

            }

            return parameters;
        }
        
                        
        /**
         * Convert TerminateInstancesRequest to name value pairs
         */
        private IDictionary<String, String> ConvertTerminateInstances(TerminateInstancesRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "TerminateInstances");
            List<String> instanceIdList  =  request.InstanceId;
            foreach  (String instanceId in instanceIdList)
            {
                parameters.Add("InstanceId" + "."  + (instanceIdList.IndexOf(instanceId) + 1), instanceId);
            }

            return parameters;
        }
        
                        
        /**
         * Convert DeleteVolumeRequest to name value pairs
         */
        private IDictionary<String, String> ConvertDeleteVolume(DeleteVolumeRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "DeleteVolume");
            if (request.IsSetVolumeId())
            {
                parameters.Add("VolumeId", request.VolumeId);
            }

            return parameters;
        }
        
                        
        /**
         * Convert CreateVolumeRequest to name value pairs
         */
        private IDictionary<String, String> ConvertCreateVolume(CreateVolumeRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "CreateVolume");
            if (request.IsSetSize())
            {
                parameters.Add("Size", request.Size);
            }
            if (request.IsSetSnapshotId())
            {
                parameters.Add("SnapshotId", request.SnapshotId);
            }
            if (request.IsSetAvailabilityZone())
            {
                parameters.Add("AvailabilityZone", request.AvailabilityZone);
            }

            return parameters;
        }
        
                        
        /**
         * Convert DescribeVolumesRequest to name value pairs
         */
        private IDictionary<String, String> ConvertDescribeVolumes(DescribeVolumesRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "DescribeVolumes");
            List<String> volumeIdList  =  request.VolumeId;
            foreach  (String volumeId in volumeIdList)
            {
                parameters.Add("VolumeId" + "."  + (volumeIdList.IndexOf(volumeId) + 1), volumeId);
            }

            return parameters;
        }
        
                        
        /**
         * Convert DetachVolumeRequest to name value pairs
         */
        private IDictionary<String, String> ConvertDetachVolume(DetachVolumeRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "DetachVolume");
            if (request.IsSetVolumeId())
            {
                parameters.Add("VolumeId", request.VolumeId);
            }
            if (request.IsSetInstanceId())
            {
                parameters.Add("InstanceId", request.InstanceId);
            }
            if (request.IsSetDevice())
            {
                parameters.Add("Device", request.Device);
            }
            if (request.IsSetForce())
            {
                parameters.Add("Force", request.Force + "");
            }

            return parameters;
        }
        
                        
        /**
         * Convert DescribeSnapshotsRequest to name value pairs
         */
        private IDictionary<String, String> ConvertDescribeSnapshots(DescribeSnapshotsRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "DescribeSnapshots");
            List<String> snapshotIdList  =  request.SnapshotId;
            foreach  (String snapshotId in snapshotIdList)
            {
                parameters.Add("SnapshotId" + "."  + (snapshotIdList.IndexOf(snapshotId) + 1), snapshotId);
            }

            return parameters;
        }
        
                        
        /**
         * Convert DeleteSnapshotRequest to name value pairs
         */
        private IDictionary<String, String> ConvertDeleteSnapshot(DeleteSnapshotRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "DeleteSnapshot");
            if (request.IsSetSnapshotId())
            {
                parameters.Add("SnapshotId", request.SnapshotId);
            }

            return parameters;
        }
        
                        
        /**
         * Convert CreateSnapshotRequest to name value pairs
         */
        private IDictionary<String, String> ConvertCreateSnapshot(CreateSnapshotRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "CreateSnapshot");
            if (request.IsSetVolumeId())
            {
                parameters.Add("VolumeId", request.VolumeId);
            }

            return parameters;
        }
        
                        
        /**
         * Convert AttachVolumeRequest to name value pairs
         */
        private IDictionary<String, String> ConvertAttachVolume(AttachVolumeRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "AttachVolume");
            if (request.IsSetVolumeId())
            {
                parameters.Add("VolumeId", request.VolumeId);
            }
            if (request.IsSetInstanceId())
            {
                parameters.Add("InstanceId", request.InstanceId);
            }
            if (request.IsSetDevice())
            {
                parameters.Add("Device", request.Device);
            }

            return parameters;
        }
        
                                                                                                                                                                                                                
        /**
         * Convert DescribeRegionsRequest to name value pairs
         */
        private IDictionary<String, String> ConvertDescribeRegions(DescribeRegionsRequest request)
        {
            
            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "DescribeRegions");
            List<String> regionNameList  =  request.RegionName;
            foreach  (String regionName in regionNameList)
            {
                parameters.Add("RegionName" + "."  + (regionNameList.IndexOf(regionName) + 1), regionName);
            }

            return parameters;
        }
        
                                                                                                                                                                                                                                                
        /*
         *  Transforms response based on xslt template
         */
        private String transform(String responseBody, String actionName)
        {
            XslCompiledTransform transformer = new XslCompiledTransform();
            Stream template = Assembly.GetAssembly(this.GetType()).GetManifestResourceStream(actionName + "Response.xslt");
            transformer.Load(new XmlTextReader(template));
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            transformer.Transform(new XPathDocument(new XmlTextReader (new StringReader (responseBody))), null, sw);
            return new StringWriter(sb).ToString();
        }
    }
}