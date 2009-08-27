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
using System.Xml.Serialization;
using System.Collections.Generic;
using Amazon.EC2.Model;

namespace Amazon.EC2
{


    /// <summary>
    /// The Amazon Elastic Compute Cloud (Amazon EC2) web service provides you with
    /// the ability to execute your applications in Amazon's computing environment.
    /// To use Amazon EC2 you simply:
    /// 1. Create an Amazon Machine Image (AMI) containing all your software, including
    /// your operating system and associated configuration settings, applications,
    /// libraries, etc. Think of this as zipping up the contents of your hard drive. We
    /// provide all the necessary tools to create and package your AMI.
    /// 2. Upload this AMI to the Amazon S3 (Amazon Simple Storage Service) service. This
    /// gives us reliable, secure access to your AMI.
    /// 3. Register your AMI with Amazon EC2. This allows us to verify that your AMI has
    /// been uploaded correctly and to allocate a unique identifier for it.
    /// 4. Use this AMI ID and the Amazon EC2 web service APIs to run, monitor, and
    /// terminate as many instances of this AMI as required.
    /// You can also skip the first three steps and choose to launch an AMI that is
    /// provided by Amazon or shared by another user.
    /// While instances are running, you are billed for the computing and network
    /// resources that they consume.
    /// You can also skip the first three steps and choose to launch an AMI that is
    /// provided by Amazon or shared by another user.
    /// While instances are running, you are billed for the computing and network
    /// resources that they consume.
    /// 
    /// </summary>
    public interface  AmazonEC2 {
    
                
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
        AllocateAddressResponse AllocateAddress(AllocateAddressRequest request);

                
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
        AssociateAddressResponse AssociateAddress(AssociateAddressRequest request);

                
        /// <summary>
        /// Attach Volume 
        /// </summary>
        /// <param name="request">Attach Volume  request</param>
        /// <returns>Attach Volume  Response from the service</returns>
        /// <remarks>
        /// Attach a previously created volume to a running instance.
        ///   
        /// </remarks>
        AttachVolumeResponse AttachVolume(AttachVolumeRequest request);

                
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
        AuthorizeSecurityGroupIngressResponse AuthorizeSecurityGroupIngress(AuthorizeSecurityGroupIngressRequest request);

                
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
        BundleInstanceResponse BundleInstance(BundleInstanceRequest request);

                
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
        CancelBundleTaskResponse CancelBundleTask(CancelBundleTaskRequest request);

                
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
        ConfirmProductInstanceResponse ConfirmProductInstance(ConfirmProductInstanceRequest request);

                
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
        CreateKeyPairResponse CreateKeyPair(CreateKeyPairRequest request);

                
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
        CreateSecurityGroupResponse CreateSecurityGroup(CreateSecurityGroupRequest request);

                
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
        CreateSnapshotResponse CreateSnapshot(CreateSnapshotRequest request);

                
        /// <summary>
        /// Create Volume 
        /// </summary>
        /// <param name="request">Create Volume  request</param>
        /// <returns>Create Volume  Response from the service</returns>
        /// <remarks>
        /// Initializes an empty volume of a given size
        ///   
        /// </remarks>
        CreateVolumeResponse CreateVolume(CreateVolumeRequest request);

                
        /// <summary>
        /// Delete Key Pair 
        /// </summary>
        /// <param name="request">Delete Key Pair  request</param>
        /// <returns>Delete Key Pair  Response from the service</returns>
        /// <remarks>
        /// The DeleteKeyPair operation deletes a key pair.
        ///   
        /// </remarks>
        DeleteKeyPairResponse DeleteKeyPair(DeleteKeyPairRequest request);

                
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
        DeleteSecurityGroupResponse DeleteSecurityGroup(DeleteSecurityGroupRequest request);

                
        /// <summary>
        /// Delete Snapshot 
        /// </summary>
        /// <param name="request">Delete Snapshot  request</param>
        /// <returns>Delete Snapshot  Response from the service</returns>
        /// <remarks>
        /// Deletes the snapshot identitied by snapshotId.
        ///   
        /// </remarks>
        DeleteSnapshotResponse DeleteSnapshot(DeleteSnapshotRequest request);

                
        /// <summary>
        /// Delete Volume 
        /// </summary>
        /// <param name="request">Delete Volume  request</param>
        /// <returns>Delete Volume  Response from the service</returns>
        /// <remarks>
        /// Deletes a  previously created volume. Once successfully deleted, a new volume  can be created with the same name.
        ///   
        /// </remarks>
        DeleteVolumeResponse DeleteVolume(DeleteVolumeRequest request);

                
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
        DeregisterImageResponse DeregisterImage(DeregisterImageRequest request);

                
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
        DescribeAddressesResponse DescribeAddresses(DescribeAddressesRequest request);

                
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
        DescribeAvailabilityZonesResponse DescribeAvailabilityZones(DescribeAvailabilityZonesRequest request);

                
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
        DescribeBundleTasksResponse DescribeBundleTasks(DescribeBundleTasksRequest request);

                
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
        DescribeImageAttributeResponse DescribeImageAttribute(DescribeImageAttributeRequest request);

                
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
        DescribeImagesResponse DescribeImages(DescribeImagesRequest request);

                
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
        DescribeInstancesResponse DescribeInstances(DescribeInstancesRequest request);

                
        /// <summary>
        /// Describe Regions 
        /// </summary>
        /// <param name="request">Describe Regions  request</param>
        /// <returns>Describe Regions  Response from the service</returns>
        /// <remarks>
        /// The DescribeRegions operation describes regions zones that are currently available to the account.
        ///   
        /// </remarks>
        DescribeRegionsResponse DescribeRegions(DescribeRegionsRequest request);

                
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
        DescribeKeyPairsResponse DescribeKeyPairs(DescribeKeyPairsRequest request);

                
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
        DescribeSecurityGroupsResponse DescribeSecurityGroups(DescribeSecurityGroupsRequest request);

                
        /// <summary>
        /// Describe Snapshots 
        /// </summary>
        /// <param name="request">Describe Snapshots  request</param>
        /// <returns>Describe Snapshots  Response from the service</returns>
        /// <remarks>
        /// Describes the indicated snapshots, or in lieu of that, all snapshots owned by the caller.
        ///   
        /// </remarks>
        DescribeSnapshotsResponse DescribeSnapshots(DescribeSnapshotsRequest request);

                
        /// <summary>
        /// Describe Volumes 
        /// </summary>
        /// <param name="request">Describe Volumes  request</param>
        /// <returns>Describe Volumes  Response from the service</returns>
        /// <remarks>
        /// Describes the status of the indicated or, in lieu of any specified,  all volumes belonging to the caller. Volumes that have been deleted are not described.
        ///   
        /// </remarks>
        DescribeVolumesResponse DescribeVolumes(DescribeVolumesRequest request);

                
        /// <summary>
        /// Detach Volume 
        /// </summary>
        /// <param name="request">Detach Volume  request</param>
        /// <returns>Detach Volume  Response from the service</returns>
        /// <remarks>
        /// Detach a previously attached volume from a running instance.
        ///   
        /// </remarks>
        DetachVolumeResponse DetachVolume(DetachVolumeRequest request);

                
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
        DisassociateAddressResponse DisassociateAddress(DisassociateAddressRequest request);

                
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
        GetConsoleOutputResponse GetConsoleOutput(GetConsoleOutputRequest request);

                
        /// <summary>
        /// Modify Image Attribute 
        /// </summary>
        /// <param name="request">Modify Image Attribute  request</param>
        /// <returns>Modify Image Attribute  Response from the service</returns>
        /// <remarks>
        /// The ModifyImageAttribute operation modifies an attribute of an AMI.
        ///   
        /// </remarks>
        ModifyImageAttributeResponse ModifyImageAttribute(ModifyImageAttributeRequest request);

                
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
        RebootInstancesResponse RebootInstances(RebootInstancesRequest request);

                
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
        RegisterImageResponse RegisterImage(RegisterImageRequest request);

                
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
        ReleaseAddressResponse ReleaseAddress(ReleaseAddressRequest request);

                
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
        ResetImageAttributeResponse ResetImageAttribute(ResetImageAttributeRequest request);

                
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
        RevokeSecurityGroupIngressResponse RevokeSecurityGroupIngress(RevokeSecurityGroupIngressRequest request);

                
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
        RunInstancesResponse RunInstances(RunInstancesRequest request);

                
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
        TerminateInstancesResponse TerminateInstances(TerminateInstancesRequest request);

    }
}