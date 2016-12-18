// This file is automatically generated.
using System;
using System.Text;
using System.Runtime.InteropServices;
using Steam4NET.Attributes;

namespace Steam4NET
{

	[StructLayout(LayoutKind.Sequential,Pack=8)]
	public struct gameserveritem_t
	{
		public servernetadr_t m_NetAdr;
		public Int32 m_nPing;
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bHadSuccessfulResponse;
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bDoNotRefresh;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string m_szGameDir;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string m_szMap;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
		public string m_szGameDescription;
		public UInt32 m_nAppID;
		public Int32 m_nPlayers;
		public Int32 m_nMaxPlayers;
		public Int32 m_nBotPlayers;
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bPassword;
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bSecure;
		public UInt32 m_ulTimeLastPlayed;
		public Int32 m_nServerVersion;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
		public string m_szServerName;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		public string m_szGameTags;
		public SteamID_t m_steamID;
	};
	
}
