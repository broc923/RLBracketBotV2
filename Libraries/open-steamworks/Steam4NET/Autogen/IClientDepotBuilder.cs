// This file is automatically generated.
using System;
using System.Text;
using System.Runtime.InteropServices;
using Steam4NET.Attributes;

namespace Steam4NET
{

	public enum EDepotBuildStatus : int
	{
		k_EDepotBuildStatusInvalid = 0,
		k_EDepotBuildStatusProcessingConfig = 1,
		k_EDepotBuildStatusBuildingFileList = 2,
		k_EDepotBuildStatusProcessingData = 3,
		k_EDepotBuildStatusUploadingData = 4,
		k_EDepotBuildStatusCompleted = 5,
		k_EDepotBuildStatusFailed = 6,
	};
	
	public enum EStatusDepotVersion : int
	{
		k_EStatusDepotVersionInvalid = 0,
		k_EStatusDepotVersionDisabled = 1,
		k_EStatusDepotVersionAvailable = 2,
		k_EStatusDepotVersionCurrent = 3,
	};
	
	[InterfaceVersion("CLIENTDEPOTBUILDER_INTERFACE_VERSION001")]
	public interface IClientDepotBuilder
	{
		[VTableSlot(0)]
		UInt32 RegisterAppBuild(UInt32 nAppID, bool bLocalCSBuild, string cszDescription);
		[VTableSlot(1)]
		UInt32 GetRegisteredBuildID(UInt32 arg0);
		[VTableSlot(2)]
		UInt32 StartDepotBuildFromConfigFile(string pchConfigFile, string arg1, string arg2, UInt32 arg3, UInt32 arg4, string arg5);
		[VTableSlot(3)]
		bool BGetDepotBuildStatus(UInt32 hDepotBuild, ref EDepotBuildStatus pStatusOut, ref UInt32 pPercentDone);
		[VTableSlot(4)]
		bool CloseDepotBuildHandle(UInt32 hDepotBuild);
		[VTableSlot(5)]
		UInt32 ReconstructDepotFromManifestAndChunks(string pchLocalManifestPath, string pchLocalChunkPath, string pchRestorePath, UInt32 arg3);
		[VTableSlot(6)]
		bool BGetChunkCounts(UInt32 hDepotBuild, ref UInt32 unTotalChunksInNewBuild, ref UInt32 unChunksAlsoInOldBuild);
		[VTableSlot(7)]
		bool GetManifestGIDs(UInt32 hDepotBuild, ref UInt64 pBaselineGID, ref UInt64 pNewGID, ref bool arg3);
		[VTableSlot(8)]
		UInt32 FinishAppBuild(UInt32 uBuildID, UInt32 nAppID, string cszBetaKey, bool bOnlyFinish, UInt32 cNumSkipDepots);
		[VTableSlot(9)]
		UInt32 VerifyChunkStore(UInt32 arg0, UInt32 arg1, string arg2);
		[VTableSlot(10)]
		UInt32 StartUploadTest(UInt32 arg0, UInt32 arg1);
		[VTableSlot(11)]
		UInt32 DownloadDepot(UInt32 arg0, UInt32 arg1);
	};
}