// This file is automatically generated.
using System;
using System.Text;
using System.Runtime.InteropServices;
using Steam4NET.Attributes;

namespace Steam4NET
{

	[InterfaceVersion("STEAMUSERSTATS_INTERFACE_VERSION007")]
	public interface ISteamUserStats007
	{
		[VTableSlot(0)]
		bool RequestCurrentStats();
		[VTableSlot(1)]
		bool GetStat(string pchName, ref float pData);
		[VTableSlot(2)]
		bool GetStat(string pchName, ref Int32 pData);
		[VTableSlot(3)]
		bool SetStat(string pchName, float fData);
		[VTableSlot(4)]
		bool SetStat(string pchName, Int32 nData);
		[VTableSlot(5)]
		bool UpdateAvgRateStat(string pchName, float flCountThisSession, double dSessionLength);
		[VTableSlot(6)]
		bool GetAchievement(string pchName, ref bool pbAchieved);
		[VTableSlot(7)]
		bool SetAchievement(string pchName);
		[VTableSlot(8)]
		bool ClearAchievement(string pchName);
		[VTableSlot(9)]
		bool GetAchievementAndUnlockTime(string pchName, ref bool pbAchieved, ref UInt32 prtTime);
		[VTableSlot(10)]
		bool StoreStats();
		[VTableSlot(11)]
		Int32 GetAchievementIcon(string pchName);
		[VTableSlot(12)]
		string GetAchievementDisplayAttribute(string pchName, string pchKey);
		[VTableSlot(13)]
		bool IndicateAchievementProgress(string pchName, UInt32 nCurProgress, UInt32 nMaxProgress);
		[VTableSlot(14)]
		UInt64 RequestUserStats(CSteamID steamIDUser);
		[VTableSlot(15)]
		bool GetUserStat(CSteamID steamIDUser, string pchName, ref float pData);
		[VTableSlot(16)]
		bool GetUserStat(CSteamID steamIDUser, string pchName, ref Int32 pData);
		[VTableSlot(17)]
		bool GetUserAchievement(CSteamID steamIDUser, string pchName, ref bool pbAchieved);
		[VTableSlot(18)]
		bool GetUserAchievementAndUnlockTime(CSteamID steamIDUser, string pchName, ref bool pbAchieved, ref UInt32 prtTime);
		[VTableSlot(19)]
		bool ResetAllStats(bool bAchievementsToo);
		[VTableSlot(20)]
		UInt64 FindOrCreateLeaderboard(string pchLeaderboardName, ELeaderboardSortMethod eLeaderboardSortMethod, ELeaderboardDisplayType eLeaderboardDisplayType);
		[VTableSlot(21)]
		UInt64 FindLeaderboard(string pchLeaderboardName);
		[VTableSlot(22)]
		string GetLeaderboardName(UInt64 hSteamLeaderboard);
		[VTableSlot(23)]
		Int32 GetLeaderboardEntryCount(UInt64 hSteamLeaderboard);
		[VTableSlot(24)]
		ELeaderboardSortMethod GetLeaderboardSortMethod(UInt64 hSteamLeaderboard);
		[VTableSlot(25)]
		ELeaderboardDisplayType GetLeaderboardDisplayType(UInt64 hSteamLeaderboard);
		[VTableSlot(26)]
		UInt64 DownloadLeaderboardEntries(UInt64 hSteamLeaderboard, ELeaderboardDataRequest eLeaderboardDataRequest, Int32 nRangeStart, Int32 nRangeEnd);
		[VTableSlot(27)]
		bool GetDownloadedLeaderboardEntry(UInt64 hSteamLeaderboardEntries, Int32 index, ref LeaderboardEntry001_t pLeaderboardEntry, ref Int32 pDetails, Int32 cDetailsMax);
		[VTableSlot(28)]
		UInt64 UploadLeaderboardScore(UInt64 hSteamLeaderboard, ELeaderboardUploadScoreMethod eLeaderboardUploadScoreMethod, Int32 nScore, ref Int32 pScoreDetails, Int32 cScoreDetailsCount);
		[VTableSlot(29)]
		UInt64 GetNumberOfCurrentPlayers();
	};
}
