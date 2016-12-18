// This file is automatically generated.
using System;
using System.Text;
using System.Runtime.InteropServices;
using Steam4NET.Attributes;

namespace Steam4NET
{

	[InterfaceVersion("SteamFriends013")]
	public interface ISteamFriends013
	{
		[VTableSlot(0)]
		string GetPersonaName();
		[VTableSlot(1)]
		UInt64 SetPersonaName(string pchPersonaName);
		[VTableSlot(2)]
		EPersonaState GetPersonaState();
		[VTableSlot(3)]
		Int32 GetFriendCount(Int32 iFriendFlags);
		[VTableSlot(4)]
		CSteamID GetFriendByIndex(Int32 iFriend, Int32 iFriendFlags);
		[VTableSlot(5)]
		EFriendRelationship GetFriendRelationship(CSteamID steamIDFriend);
		[VTableSlot(6)]
		EPersonaState GetFriendPersonaState(CSteamID steamIDFriend);
		[VTableSlot(7)]
		string GetFriendPersonaName(CSteamID steamIDFriend);
		[VTableSlot(8)]
		bool GetFriendGamePlayed(CSteamID steamIDFriend, ref FriendGameInfo_t pFriendGameInfo);
		[VTableSlot(9)]
		string GetFriendPersonaNameHistory(CSteamID steamIDFriend, Int32 iPersonaName);
		[VTableSlot(10)]
		bool HasFriend(CSteamID steamIDFriend, Int32 iFriendFlags);
		[VTableSlot(11)]
		Int32 GetClanCount();
		[VTableSlot(12)]
		CSteamID GetClanByIndex(Int32 iClan);
		[VTableSlot(13)]
		string GetClanName(CSteamID steamIDClan);
		[VTableSlot(14)]
		string GetClanTag(CSteamID steamIDClan);
		[VTableSlot(15)]
		bool GetClanActivityCounts(CSteamID steamID, ref Int32 pnOnline, ref Int32 pnInGame, ref Int32 pnChatting);
		[VTableSlot(16)]
		UInt64 DownloadClanActivityCounts(ref CSteamID groupIDs, Int32 nIds);
		[VTableSlot(17)]
		Int32 GetFriendCountFromSource(CSteamID steamIDSource);
		[VTableSlot(18)]
		CSteamID GetFriendFromSourceByIndex(CSteamID steamIDSource, Int32 iFriend);
		[VTableSlot(19)]
		bool IsUserInSource(CSteamID steamIDUser, CSteamID steamIDSource);
		[VTableSlot(20)]
		void SetInGameVoiceSpeaking(CSteamID steamIDUser, bool bSpeaking);
		[VTableSlot(21)]
		void ActivateGameOverlay(string pchDialog);
		[VTableSlot(22)]
		void ActivateGameOverlayToUser(string pchDialog, CSteamID steamID);
		[VTableSlot(23)]
		void ActivateGameOverlayToWebPage(string pchURL);
		[VTableSlot(24)]
		void ActivateGameOverlayToStore(UInt32 nAppID, EOverlayToStoreFlag eFlag);
		[VTableSlot(25)]
		void SetPlayedWith(CSteamID steamIDUserPlayedWith);
		[VTableSlot(26)]
		void ActivateGameOverlayInviteDialog(CSteamID steamIDLobby);
		[VTableSlot(27)]
		Int32 GetSmallFriendAvatar(CSteamID steamIDFriend);
		[VTableSlot(28)]
		Int32 GetMediumFriendAvatar(CSteamID steamIDFriend);
		[VTableSlot(29)]
		Int32 GetLargeFriendAvatar(CSteamID steamIDFriend);
		[VTableSlot(30)]
		bool RequestUserInformation(CSteamID steamIDUser, bool bRequireNameOnly);
		[VTableSlot(31)]
		UInt64 RequestClanOfficerList(CSteamID steamIDClan);
		[VTableSlot(32)]
		CSteamID GetClanOwner(CSteamID steamIDClan);
		[VTableSlot(33)]
		Int32 GetClanOfficerCount(CSteamID steamIDClan);
		[VTableSlot(34)]
		CSteamID GetClanOfficerByIndex(CSteamID steamIDClan, Int32 iOfficer);
		[VTableSlot(35)]
		EUserRestriction GetUserRestrictions();
		[VTableSlot(36)]
		bool SetRichPresence(string pchKey, string pchValue);
		[VTableSlot(37)]
		void ClearRichPresence();
		[VTableSlot(38)]
		string GetFriendRichPresence(CSteamID steamIDFriend, string pchKey);
		[VTableSlot(39)]
		Int32 GetFriendRichPresenceKeyCount(CSteamID steamIDFriend);
		[VTableSlot(40)]
		string GetFriendRichPresenceKeyByIndex(CSteamID steamIDFriend, Int32 iKey);
		[VTableSlot(41)]
		void RequestFriendRichPresence(CSteamID steamIDFriend);
		[VTableSlot(42)]
		bool InviteUserToGame(CSteamID steamIDFriend, string pchConnectString);
		[VTableSlot(43)]
		Int32 GetCoplayFriendCount();
		[VTableSlot(44)]
		CSteamID GetCoplayFriend(Int32 iCoplayFriend);
		[VTableSlot(45)]
		Int32 GetFriendCoplayTime(CSteamID steamIDFriend);
		[VTableSlot(46)]
		UInt32 GetFriendCoplayGame(CSteamID steamIDFriend);
		[VTableSlot(47)]
		UInt64 JoinClanChatRoom(CSteamID steamIDClan);
		[VTableSlot(48)]
		bool LeaveClanChatRoom(CSteamID steamIDClan);
		[VTableSlot(49)]
		Int32 GetClanChatMemberCount(CSteamID steamIDClan);
		[VTableSlot(50)]
		CSteamID GetChatMemberByIndex(CSteamID steamIDClan, Int32 iUser);
		[VTableSlot(51)]
		bool SendClanChatMessage(CSteamID steamIDClanChat, string pchText);
		[VTableSlot(52)]
		Int32 GetClanChatMessage(CSteamID steamIDClanChat, Int32 iMessage, Byte[] prgchText, Int32 cchTextMax, ref EChatEntryType peChatEntryType, ref CSteamID pSteamIDChatter);
		[VTableSlot(53)]
		bool IsClanChatAdmin(CSteamID steamIDClanChat, CSteamID steamIDUser);
		[VTableSlot(54)]
		bool IsClanChatWindowOpenInSteam(CSteamID steamIDClanChat);
		[VTableSlot(55)]
		bool OpenClanChatWindowInSteam(CSteamID steamIDClanChat);
		[VTableSlot(56)]
		bool CloseClanChatWindowInSteam(CSteamID steamIDClanChat);
		[VTableSlot(57)]
		bool SetListenForFriendsMessages(bool bInterceptEnabled);
		[VTableSlot(58)]
		bool ReplyToFriendMessage(CSteamID steamIDFriend, string pchMsgToSend);
		[VTableSlot(59)]
		Int32 GetFriendMessage(CSteamID steamIDFriend, Int32 iMessageID, Byte[] pvData, Int32 cubData, ref EChatEntryType peChatEntryType);
		[VTableSlot(60)]
		UInt64 GetFollowerCount(CSteamID steamID);
		[VTableSlot(61)]
		UInt64 IsFollowing(CSteamID steamID);
		[VTableSlot(62)]
		UInt64 EnumerateFollowingList(UInt32 unStartIndex);
	};
}
