This is a fork of http://s3.codeplex.com/

# Standalone Windows .EXE command line utility for Amazon S3 & EC2

A Windows command-line utility for Amazon's S3 & EC2 web services that requires no installation, is a single .EXE file with no DLLs, and requires only .NET 2.0 or Mono, so will work on a plain vanilla Windows 2003 installation.
Key Features

- Efficiently uploads and downloads large numbers of files (or whole directories) between Amazon S3 and Windows PCs.
- Everything is in one .EXE. Nothing to install or configure, just download it where it's needed and run.
- Doesn't require anything except .NET 2.0 or Mono [which version?] which you already have on all your machines (don't you?).
- Works well in an automated backup solution or as an ad-hoc system administration tool.
- Can split large files into chunks for upload without creating any temporary files on disk.
- Fast parallel file transfers (coming soon).
Can use HTTP HEAD command to quickly determine which files don't need to be uploaded because they haven't been updated (/sync).
Support for EC2 operations as well.

For usage info type 's3 help' at the command line.

Free & open source. There is no paid version.
