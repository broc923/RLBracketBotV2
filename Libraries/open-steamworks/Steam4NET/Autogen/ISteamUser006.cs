// This file is automatically generated.
using System;
using System.Text;
using System.Runtime.InteropServices;
using Steam4NET.Attributes;

namespace Steam4NET
{

	[InterfaceVersion("SteamUser006")]
	public interface ISteamUser006
	{
		[VTableSlot(0)]
		Int32 GetHSteamUser();
		[VTableSlot(1)]
		void LogOn(CSteamID steamID);
		[VTableSlot(2)]
		void LogOff();
		[VTableSlot(3)]
		bool BLoggedOn();
		[VTableSlot(4)]
		CSteamID GetSteamID();
		[VTableSlot(5)]
		bool SetRegistryString(ERegistrySubTree eRegistrySubTree, string pchKey, string pchValue);
		[VTableSlot(6)]
		bool GetRegistryString(ERegistrySubTree eRegistrySubTree, string pchKey, StringBuilder pchValue, Int32 cbValue);
		[VTableSlot(7)]
		bool SetRegistryInt(ERegistrySubTree eRegistrySubTree, string pchKey, Int32 iValue);
		[VTableSlot(8)]
		bool GetRegistryInt(ERegistrySubTree eRegistrySubTree, string pchKey, ref Int32 piValue);
		[VTableSlot(9)]
		Int32 InitiateGameConnection(Byte[] pBlob, Int32 cbMaxBlob, CSteamID steamID, CGameID nGameAppID, UInt32 unIPServer, UInt16 usPortServer, bool bSecure);
		[VTableSlot(10)]
		void TerminateGameConnection(UInt32 unIPServer, UInt16 usPortServer);
		[VTableSlot(11)]
		void TrackAppUsageEvent(CGameID gameID, EAppUsageEvent eAppUsageEvent, string pchExtraInfo);
	};
}
