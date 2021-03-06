﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using SIL.Extensions;
using SIL.IO;

namespace Bloom.WebLibraryIntegration
{
	/// <summary>
	/// This class is responsible for the key bits of information that are needed to access our backend sites.
	/// These keys are not very secret and could easily be found, for example, by packet snooping.
	/// However, we want to keep them out of source code where someone might be able to do a google search
	/// and easily find our keys and use our storage.
	/// The keys are currently stored in a file called connections.dll. The installer must place a version of this
	/// in the EXE directory. Developers must do so manually.
	/// You can see what keys are stored in what order by checking the constructor.
	/// Enhance: it may be helpful to use a distinct version of connections.dll for developers, testers,
	/// and others who should be working in a sandbox rather than modifying the live data.
	/// That will work for Parse.com, where we currently have different API keys for the sandbox.
	/// For the S3 data, we currently just use different buckets. If we wanted to, we could put the
	/// 'real data' bucket name here also, and put the appropriate one into the testing version of connections.dll.
	/// Todo: Some of the real keys are still in our version control history. Before we go live, we may want
	/// to change the keys so any keys discovered in our version control are obsolete.
	/// </summary>
	static class KeyManager
	{
		public static string S3AccessKey { get; private set; }
		public static string S3SecretAccessKey { get; private set; }
		public static string ParseApiKey { get; private set; }
		public static string ParseApplicationKey { get; private set; }
		public static string ParseUnitTestApiKey { get; private set; }
		public static string ParseUnitTextApplicationKey { get; private set; }

		static KeyManager()
		{
			var connectionsPath = FileLocator.GetFileDistributedWithApplication("connections.dll");
			var lines = File.ReadAllLines(connectionsPath);
			if (BookTransfer.UseSandbox)
			{
				// These lines contain the S3 keys for the 'uploaderDev' user, who has permission to use the BloomLibraryBooks-Sandbox bucket.
				S3AccessKey = lines[2];
				S3SecretAccessKey = lines[3];
				// These lines contain the Parse.com keys for the 'application' silbloomlibrarysandbox
				ParseApiKey = lines[6];
				ParseApplicationKey = lines[7];
			}
			else
			{
				// These lines contain the S3 keys for the 'uploader' user, who has permission to use the BloomLibraryBooks bucket.
				S3AccessKey = lines[0];
				S3SecretAccessKey = lines[1];
				// These lines contain the Parse.com keys for the 'application' silbloomlibrary
				ParseApiKey = lines[4];
				ParseApplicationKey = lines[5];
			}
			ParseUnitTestApiKey = lines[8];
			ParseUnitTextApplicationKey = lines[9];
		}
	}
}
