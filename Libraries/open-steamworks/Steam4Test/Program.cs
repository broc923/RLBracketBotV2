using System;
using System.Threading;
using Steam4NET;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Linq;

namespace Steam4Test {
    class Program {
        static UInt64[] admins = new UInt64[1];

        static void Main(string[] args) {
            admins[0] = 76561198063539247;
            if (Steamworks.Load(true))
                Console.WriteLine("Steamworks loaded");
            else
                error("Steamworks not loaded");

            ISteamClient008 steamClient = Steamworks.CreateInterface<ISteamClient008>();
            int pipe = steamClient.CreateSteamPipe();
            int user = steamClient.ConnectToGlobalUser(pipe);
            ISteamFriends002 steamFriends = steamClient.GetISteamFriends<ISteamFriends002>(user, pipe);
            ISteamUser012 steamUser = steamClient.GetISteamUser<ISteamUser012>(user, pipe);
            CSteamID cID = steamUser.GetSteamID();
            UInt64 ownID = cID.ConvertToUint64();

            CallbackMsg_t callbackMsg;

            EPersonaState state = EPersonaState.k_EPersonaStateOnline;
            steamFriends.SetPersonaState(state);

            do {
                while (!Console.KeyAvailable) {
                    callbackMsg = new CallbackMsg_t();
                    if (Steamworks.GetCallback(pipe, ref callbackMsg)) {
                        if (callbackMsg.m_iCallback == FriendChatMsg_t.k_iCallback) {
                            FriendChatMsg_t chatMsg = (FriendChatMsg_t)Marshal.PtrToStructure(callbackMsg.m_pubParam, typeof(FriendChatMsg_t));
                            EChatEntryType msgType;
                            msgType = EChatEntryType.k_EChatEntryTypeChatMsg;
                            byte[] pvData = new byte[256];
                            Array.Clear(pvData, 0, 256);

                            string friendName = steamFriends.GetFriendPersonaName(chatMsg.m_ulSenderID);
                            steamFriends.GetChatMessage(chatMsg.m_ulSenderID, (int)chatMsg.m_iChatID, pvData, 256, ref msgType);
                            if(msgType == EChatEntryType.k_EChatEntryTypeChatMsg) {
                                if (chatMsg.m_ulFriendID.Equals(chatMsg.m_ulSenderID)) {
                                    string command = Encoding.UTF8.GetString(pvData).Replace("\0",string.Empty);
                                    switch (command) {
                                        case "/help":
                                            Console.WriteLine("Command recieved from {0}: {1}", friendName, command);
                                            byte[] helpResponse = Encoding.UTF8.GetBytes("\n1. /help - shows all commands" +
                                                "\n2. /add - adds you to a queue to be invited to a game so you can add items to your rlbracket.com inventory" +
                                                "\n3. /withdrawl - adds you to a queue to be invited to a game so we can give you your selected withdrawl items on the website (Note: If nothing is selected to withdrawl on the site, you will not get an invite!)" +
                                                "\n\nPlease note you will be periodically deleted from my friends list to clear room.");
                                            steamFriends.SendMsgToFriend(chatMsg.m_ulSenderID, EChatEntryType.k_EChatEntryTypeChatMsg, helpResponse, helpResponse.Length + 1);
                                            break;
                                        case "/removeall":
                                            Console.WriteLine("Command recieved from {0}: {1}", friendName, command);
                                            byte[] removeResponse;

                                            if (!(admins[0].Equals(chatMsg.m_ulSenderID))) {
                                                removeResponse = Encoding.UTF8.GetBytes("Stop trying to break shit.");
                                                steamFriends.SendMsgToFriend(chatMsg.m_ulSenderID, EChatEntryType.k_EChatEntryTypeChatMsg, removeResponse, removeResponse.Length + 1);
                                            } else {
                                                int numFriends = steamFriends.GetFriendCount(EFriendFlags.k_EFriendFlagAll);
                                                for (int count = 0; count < numFriends; count++) {
                                                    CSteamID friendID = steamFriends.GetFriendByIndex(count, EFriendFlags.k_EFriendFlagAll);
                                                    UInt64 friendID64 = friendID.ConvertToUint64();
                                                    bool isAdmin = false;
                                                    if(admins[0].Equals(friendID64)) {
                                                        Console.WriteLine("User {0} is admin. Skipping...", steamFriends.GetFriendPersonaName(steamFriends.GetFriendByIndex(count, EFriendFlags.k_EFriendFlagAll)));
                                                        isAdmin = true;
                                                    }
                                                    if (isAdmin)
                                                        continue;
                                                    else {
                                                        steamFriends.RemoveFriend(friendID);
                                                        Console.WriteLine("User {0} is not admin. Deleting...", steamFriends.GetFriendPersonaName(steamFriends.GetFriendByIndex(count, EFriendFlags.k_EFriendFlagAll)));
                                                        Thread.Sleep(500);
                                                    }
                                                }
                                            }
                                            break;
                                    }
                                    
                                }
                            }
                            pvData = null;
                        }
                        Steamworks.FreeLastCallback(pipe);
                    }
                    Thread.Sleep(100);
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            Steamworks.Load(false);
        }
        static void error (string error) {
            Console.WriteLine("Error occured: {0}", error);
            Console.ReadLine();
            Environment.Exit(-1);
        }
    }
}
