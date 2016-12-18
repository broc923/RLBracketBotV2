// This file is automatically generated.
using System;
using System.Text;
using System.Runtime.InteropServices;
using Steam4NET.Attributes;

namespace Steam4NET
{

	[InterfaceVersion("STEAMREMOTESTORAGE_INTERFACE_VERSION011")]
	public interface ISteamRemoteStorage011
	{
		[VTableSlot(0)]
		bool FileWrite(string pchFile, Byte[] pvData, Int32 cubData);
		[VTableSlot(1)]
		Int32 FileRead(string pchFile, Byte[] pvData, Int32 cubDataToRead);
		[VTableSlot(2)]
		bool FileForget(string pchFile);
		[VTableSlot(3)]
		bool FileDelete(string pchFile);
		[VTableSlot(4)]
		UInt64 FileShare(string pchFile);
		[VTableSlot(5)]
		bool SetSyncPlatforms(string pchFile, ERemoteStoragePlatform eRemoteStoragePlatform);
		[VTableSlot(6)]
		UInt64 FileWriteStreamOpen(string pchFile);
		[VTableSlot(7)]
		EResult FileWriteStreamWriteChunk(UInt64 hStream, Byte[] pvData, Int32 cubData);
		[VTableSlot(8)]
		EResult FileWriteStreamClose(UInt64 hStream);
		[VTableSlot(9)]
		EResult FileWriteStreamCancel(UInt64 hStream);
		[VTableSlot(10)]
		bool FileExists(string pchFile);
		[VTableSlot(11)]
		bool FilePersisted(string pchFile);
		[VTableSlot(12)]
		Int32 GetFileSize(string pchFile);
		[VTableSlot(13)]
		Int64 GetFileTimestamp(string pchFile);
		[VTableSlot(14)]
		ERemoteStoragePlatform GetSyncPlatforms(string pchFile);
		[VTableSlot(15)]
		Int32 GetFileCount();
		[VTableSlot(16)]
		string GetFileNameAndSize(Int32 iFile, ref Int32 pnFileSizeInBytes);
		[VTableSlot(17)]
		bool GetQuota(ref Int32 pnTotalBytes, ref Int32 puAvailableBytes);
		[VTableSlot(18)]
		bool IsCloudEnabledForAccount();
		[VTableSlot(19)]
		bool IsCloudEnabledForApp();
		[VTableSlot(20)]
		void SetCloudEnabledForApp(bool bEnabled);
		[VTableSlot(21)]
		UInt64 UGCDownload(UInt64 hContent, UInt32 uUnk);
		[VTableSlot(22)]
		bool GetUGCDownloadProgress(UInt64 hContent, ref UInt32 puDownloadedBytes, ref UInt32 puTotalBytes);
		[VTableSlot(23)]
		bool GetUGCDetails(UInt64 hContent, ref UInt32 pnAppID, StringBuilder ppchName, ref Int32 pnFileSizeInBytes, ref CSteamID pSteamIDOwner);
		[VTableSlot(24)]
		Int32 UGCRead(UInt64 hContent, Byte[] pvData, Int32 cubDataToRead, UInt32 uOffset);
		[VTableSlot(25)]
		Int32 GetCachedUGCCount();
		[VTableSlot(26)]
		UInt64 GetCachedUGCHandle(Int32 iCachedContent);
		[VTableSlot(27)]
		UInt64 PublishWorkshopFile(string pchFile, string pchPreviewFile, UInt32 nConsumerAppId, string pchTitle, string pchDescription, ERemoteStoragePublishedFileVisibility eVisibility, ref SteamParamStringArray_t pTags, EWorkshopFileType eWorkshopFileType);
		[VTableSlot(28)]
		UInt64 CreatePublishedFileUpdateRequest(UInt64 unPublishedFileId);
		[VTableSlot(29)]
		bool UpdatePublishedFileFile(UInt64 hUpdateRequest, string pchFile);
		[VTableSlot(30)]
		bool UpdatePublishedFilePreviewFile(UInt64 hUpdateRequest, string pchPreviewFile);
		[VTableSlot(31)]
		bool UpdatePublishedFileTitle(UInt64 hUpdateRequest, string pchTitle);
		[VTableSlot(32)]
		bool UpdatePublishedFileDescription(UInt64 hUpdateRequest, string pchDescription);
		[VTableSlot(33)]
		bool UpdatePublishedFileVisibility(UInt64 hUpdateRequest, ERemoteStoragePublishedFileVisibility eVisibility);
		[VTableSlot(34)]
		bool UpdatePublishedFileTags(UInt64 hUpdateRequest, ref SteamParamStringArray_t pTags);
		[VTableSlot(35)]
		UInt64 CommitPublishedFileUpdate(UInt64 hUpdateRequest);
		[VTableSlot(36)]
		UInt64 GetPublishedFileDetails(UInt64 unPublishedFileId, UInt32 arg1);
		[VTableSlot(37)]
		UInt64 DeletePublishedFile(UInt64 unPublishedFileId);
		[VTableSlot(38)]
		UInt64 EnumerateUserPublishedFiles(UInt32 uStartIndex);
		[VTableSlot(39)]
		UInt64 SubscribePublishedFile(UInt64 unPublishedFileId);
		[VTableSlot(40)]
		UInt64 EnumerateUserSubscribedFiles(UInt32 uStartIndex);
		[VTableSlot(41)]
		UInt64 UnsubscribePublishedFile(UInt64 unPublishedFileId);
		[VTableSlot(42)]
		bool UpdatePublishedFileSetChangeDescription(UInt64 hUpdateRequest, string cszDescription);
		[VTableSlot(43)]
		UInt64 GetPublishedItemVoteDetails(UInt64 unPublishedFileId);
		[VTableSlot(44)]
		UInt64 UpdateUserPublishedItemVote(UInt64 unPublishedFileId, bool bVoteUp);
		[VTableSlot(45)]
		UInt64 GetUserPublishedItemVoteDetails(UInt64 unPublishedFileId);
		[VTableSlot(46)]
		UInt64 EnumerateUserSharedWorkshopFiles(UInt32 nAppId, CSteamID creatorSteamID, UInt32 uStartIndex, ref SteamParamStringArray_t pRequiredTags, ref SteamParamStringArray_t pExcludedTags);
		[VTableSlot(47)]
		UInt64 PublishVideo(EWorkshopVideoProvider eVideoProvider, string cszVideoAccountName, string cszVideoIdentifier, string cszFileName, UInt32 nConsumerAppId, string cszTitle, string cszDescription, ERemoteStoragePublishedFileVisibility eVisibility, ref SteamParamStringArray_t pTags);
		[VTableSlot(48)]
		UInt64 SetUserPublishedFileAction(UInt64 unPublishedFileId, EWorkshopFileAction eAction);
		[VTableSlot(49)]
		UInt64 EnumeratePublishedFilesByUserAction(EWorkshopFileAction eAction, UInt32 uStartIndex);
		[VTableSlot(50)]
		UInt64 EnumeratePublishedWorkshopFiles(EWorkshopEnumerationType eType, UInt32 uStartIndex, UInt32 cDays, UInt32 cCount, ref SteamParamStringArray_t pTags, ref SteamParamStringArray_t pUserTags);
		[VTableSlot(51)]
		UInt64 UGCDownloadToLocation(UInt64 hContent, string cszLocation, UInt32 uUnk);
	};
}
