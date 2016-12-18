// This file is automatically generated.
using System;
using System.Text;
using System.Runtime.InteropServices;
using Steam4NET.Attributes;

namespace Steam4NET
{

	[InterfaceVersion("STEAMUGC_INTERFACE_VERSION003")]
	public interface ISteamUGC003
	{
		[VTableSlot(0)]
		UInt64 CreateQueryUserUGCRequest(UInt32 unAccountID, EUserUGCList eListType, EUGCMatchingUGCType eMatchingUGCType, EUserUGCListSortOrder eSortOrder, UInt32 nCreatorAppID, UInt32 nConsumerAppID, UInt32 unPage);
		[VTableSlot(1)]
		UInt64 CreateQueryAllUGCRequest(EUGCQuery eQueryType, EUGCMatchingUGCType eMatchingeMatchingUGCTypeFileType, UInt32 nCreatorAppID, UInt32 nConsumerAppID, UInt32 unPage);
		[VTableSlot(2)]
		UInt64 SendQueryUGCRequest(UInt64 handle);
		[VTableSlot(3)]
		bool GetQueryUGCResult(UInt64 handle, UInt32 index, ref SteamUGCDetails_t pDetails);
		[VTableSlot(4)]
		bool ReleaseQueryUGCRequest(UInt64 handle);
		[VTableSlot(5)]
		bool AddRequiredTag(UInt64 handle, string pTagName);
		[VTableSlot(6)]
		bool AddExcludedTag(UInt64 handle, string pTagName);
		[VTableSlot(7)]
		bool SetReturnLongDescription(UInt64 handle, bool bReturnLongDescription);
		[VTableSlot(8)]
		bool SetReturnTotalOnly(UInt64 handle, bool bReturnTotalOnly);
		[VTableSlot(9)]
		bool SetAllowCachedResponse(UInt64 handle, UInt32 unMaxAgeSeconds);
		[VTableSlot(10)]
		bool SetCloudFileNameFilter(UInt64 handle, string pMatchCloudFileName);
		[VTableSlot(11)]
		bool SetMatchAnyTag(UInt64 handle, bool bMatchAnyTag);
		[VTableSlot(12)]
		bool SetSearchText(UInt64 handle, string pSearchText);
		[VTableSlot(13)]
		bool SetRankedByTrendDays(UInt64 handle, UInt32 unDays);
		[VTableSlot(14)]
		UInt64 RequestUGCDetails(UInt64 nPublishedFileID, UInt32 unMaxAgeSeconds);
		[VTableSlot(15)]
		UInt64 CreateItem(UInt32 nConsumerAppId, EWorkshopFileType eFileType);
		[VTableSlot(16)]
		UInt64 StartItemUpdate(UInt32 nConsumerAppId, UInt64 nPublishedFileID);
		[VTableSlot(17)]
		bool SetItemTitle(UInt64 handle, string pchTitle);
		[VTableSlot(18)]
		bool SetItemDescription(UInt64 handle, string pchDescription);
		[VTableSlot(19)]
		bool SetItemVisibility(UInt64 handle, ERemoteStoragePublishedFileVisibility eVisibility);
		[VTableSlot(20)]
		bool SetItemTags(UInt64 updateHandle, ref SteamParamStringArray_t pTags);
		[VTableSlot(21)]
		bool SetItemContent(UInt64 handle, string pszContentFolder);
		[VTableSlot(22)]
		bool SetItemPreview(UInt64 handle, string pszPreviewFile);
		[VTableSlot(23)]
		UInt64 SubmitItemUpdate(UInt64 handle, string pchChangeNote);
		[VTableSlot(24)]
		EItemUpdateStatus GetItemUpdateProgress(UInt64 handle, ref UInt64 punBytesProcessed, ref UInt64 punBytesTotal);
		[VTableSlot(25)]
		UInt64 SubscribeItem(UInt64 nPublishedFileID);
		[VTableSlot(26)]
		UInt64 UnsubscribeItem(UInt64 nPublishedFileID);
		[VTableSlot(27)]
		UInt32 GetNumSubscribedItems();
		[VTableSlot(28)]
		UInt32 GetSubscribedItems(ref UInt64 pvecPublishedFileID, UInt32 cMaxEntries);
		[VTableSlot(29)]
		bool GetItemInstallInfo(UInt64 nPublishedFileID, ref UInt64 punSizeOnDisk, StringBuilder pchFolder, UInt32 cchFolderSize, ref bool pbLegacyItem);
		[VTableSlot(30)]
		bool GetItemUpdateInfo(UInt64 nPublishedFileID, ref bool pbNeedsUpdate, ref bool pbIsDownloading, ref UInt64 punBytesDownloaded, ref UInt64 punBytesTotal);
	};
}
