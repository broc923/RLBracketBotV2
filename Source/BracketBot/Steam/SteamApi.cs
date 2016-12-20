using Steam4NET;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BracketBot.Website;

namespace BracketBot.Steam
{
    /* Primary handler for anything Steam. */
    public class SteamApi
    {
        private static CSteamID admin = 76561198063539247;

        private RLBracketAPI website;

        private int m_pipe;
        private int m_user;

        // Gotta create those interface objects.
        private ISteamClient012 SteamClient012;
        private ISteamFriends002 SteamFriends002;
        private ISteamUser012 SteamUser012;

        public SteamApi()
        {
            if (!InitSteamworks())
                return;

            //Setup steam client
            SteamClient012 = Steamworks.CreateInterface<ISteamClient012>();
            if (SteamClient012 == null)
                throw new Exception("Failed to create SteamClient012 interface!"); // Should probably get a little bit more information.

            // setup pipe
            m_pipe = SteamClient012.CreateSteamPipe();
            if (m_pipe == 0)
                throw new Exception("Failed to create steam pipe!");

            // connect pipe
            m_user = SteamClient012.ConnectToGlobalUser(m_pipe);
            if (m_user == 0)
                throw new Exception("Failed to connect to global user!");

            //setup steam friends
            SteamFriends002 = SteamClient012.GetISteamFriends<ISteamFriends002>(m_user, m_pipe);
            if (SteamFriends002 == null)
                throw new Exception("Failed to create SteamFriends002 interface!");

            //setup steam user
            SteamUser012 = SteamClient012.GetISteamUser<ISteamUser012>(m_user, m_pipe);
            if (SteamUser012 == null)
                throw new Exception("Failed to create SteamUser012 interface!");

            Console.WriteLine("Steam API Interfaces Setup");

            //Website API Setup
            website = new RLBracketAPI();
        }


        #region Private Functions/Handlers

        private bool InitSteamworks()
        {
            if(!Steamworks.Load(true))
            {
                // log it
                return false;
                throw new Exception("Unable to load Steamworks!"); // include additional info about it
            }
            // Setup interfaces, etc?
            return true;
        }
        #endregion

        #region Callback Handlers
        public void ChatHandler() {
            while (true) {
                CallbackMsg_t callbackMsg = new CallbackMsg_t();
                if (Steamworks.GetCallback(m_pipe, ref callbackMsg)) {
                    if (callbackMsg.m_iCallback == FriendChatMsg_t.k_iCallback) {
                        FriendChatMsg_t chatMsg = (FriendChatMsg_t)Marshal.PtrToStructure(callbackMsg.m_pubParam, typeof(FriendChatMsg_t));
                        EChatEntryType msgType = EChatEntryType.k_EChatEntryTypeChatMsg;
                        byte[] pvData = new byte[256];
                        Array.Clear(pvData, 0, 256);
                        string friendName = SteamFriends002.GetFriendPersonaName(chatMsg.m_ulSenderID);
                        SteamFriends002.GetChatMessage(chatMsg.m_ulSenderID, (int)chatMsg.m_iChatID, pvData, 256, ref msgType);
                        if (msgType == EChatEntryType.k_EChatEntryTypeChatMsg) {
                            if (chatMsg.m_ulFriendID.Equals(chatMsg.m_ulSenderID)) {
                                string command = Encoding.UTF8.GetString(pvData).Replace("\0", string.Empty);
                                switch (command) {
                                    #region help
                                    case "/help":
                                        Console.WriteLine("Command recieved from {0}: {1}", friendName, command);
                                        byte[] helpResponse = Encoding.UTF8.GetBytes("\n1. /help - shows all commands" +
                                            "\n2. /additems - adds you to a queue to be invited to a game so you can add items to your http://rlbracket.com inventory" +
                                            "\n3. /getitems - adds you to a queue to be invited to a game so we can give you your selected items on the website (Note: If nothing is selected to withdrawl on the site, you will not get an invite!)" +
                                            "\n\nPlease note you will be periodically deleted from my friends list to clear room.");
                                        SteamFriends002.SendMsgToFriend(chatMsg.m_ulSenderID, EChatEntryType.k_EChatEntryTypeChatMsg, helpResponse, helpResponse.Length + 1);
                                        break;
                                    #endregion
                                    #region additems
                                    case "/additems":

                                        //We need to add people to the invite queue when they type this so that they can be invited when it is their turn
                                        //I would suggest running the invite system on its own task thread so it is always inviting people from the queue and executing trades
                                        //If you call the GetInviteQueue function it'll return a list of people in order that should be invited with their steam ID and
                                        //whether or not they are looking to add items to the site or get their items back. 0 = add, 1 = get
                                        //if they want to get items back from the site call the get items to return function and it'll return the items the bot needs to give the
                                        //specified steam ID
                                        //website.GetItemsToReturn((CSteamID)chatMsg.m_ulSenderID);
                                        //see http://rlbracket.com/api/getItemsToReturn.php?&SteamID=76561198063539247
                                        //website.GetInviteQueue();
                                        //see http://rlbracket.com/api/inviteQueue.php

                                        //Broc will handle adding people to the queue when they type this command on 12/20/16 when I wake up

                                        break;
                                    #endregion
                                    #region getitems
                                    case "/getitems":
                                        //See comment in add items case
                                        break;
                                    #endregion
                                    #region removeall
                                    case "/removeall":
                                        Console.WriteLine("Command recieved from {0}: {1}", friendName, command);
                                        if (!(admin.Equals((CSteamID)chatMsg.m_ulSenderID))) {

                                            byte[] removeResponse = Encoding.UTF8.GetBytes("Stop trying to break shit.");
                                            SteamFriends002.SendMsgToFriend(chatMsg.m_ulSenderID, EChatEntryType.k_EChatEntryTypeChatMsg, removeResponse, removeResponse.Length + 1);
                                        } else {
                                            int numFriends = SteamFriends002.GetFriendCount(EFriendFlags.k_EFriendFlagAll);
                                            for (int count = 0; count < numFriends; count++) {
                                                CSteamID friendID = SteamFriends002.GetFriendByIndex(count, EFriendFlags.k_EFriendFlagAll);
                                                UInt64 friendID64 = friendID.ConvertToUint64();
                                                if (admin.Equals(friendID64)) {
                                                    Console.WriteLine("User {0} is admin. Skipping...", SteamFriends002.GetFriendPersonaName(SteamFriends002.GetFriendByIndex(count, EFriendFlags.k_EFriendFlagAll)));
                                                } else {
                                                    Console.WriteLine("User {0} is not admin. Deleting...", SteamFriends002.GetFriendPersonaName(SteamFriends002.GetFriendByIndex(count, EFriendFlags.k_EFriendFlagAll)));
                                                    SteamFriends002.RemoveFriend(friendID);
                                                    Thread.Sleep(500);
                                                }
                                            }
                                        }
                                        break;
                                        #endregion
                                }

                            }
                        }
                        pvData = null;
                    }
                    Steamworks.FreeLastCallback(m_pipe);
                }
                Thread.Sleep(100);
            }
        }

        public void FriendRequestHandler() {
            while (true) {
                byte[] addResponse = Encoding.UTF8.GetBytes("Thanks for using rlbracket.com\nType !help to see all of the commands!");
                int friendCount = SteamFriends002.GetFriendCount(EFriendFlags.k_EFriendFlagFriendshipRequested);
                Thread.Sleep(2500);
                for (int i = 0; i < friendCount; ++i) {
                    CSteamID friendSteamId = SteamFriends002.GetFriendByIndex(i, EFriendFlags.k_EFriendFlagFriendshipRequested);
                    SteamFriends002.AddFriend(friendSteamId);
                    Thread.Sleep(500);
                    SteamFriends002.SendMsgToFriend(friendSteamId, EChatEntryType.k_EChatEntryTypeChatMsg, addResponse, addResponse.Length + 1);
                }
            }
        }

        #endregion

        #region Public Functions/Handlers

        public void SetPersonaState(EPersonaState personaState) {
            SteamFriends002.SetPersonaState(personaState);
        }


        #endregion
    }
}
