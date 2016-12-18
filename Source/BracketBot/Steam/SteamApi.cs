using Steam4NET;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BracketBot.Steam
{
    /* Primary handler for anything Steam. */
    public class SteamApi
    {
        private int m_pipe;
        private int m_user;

        // Gotta create those interface objects.
        public ISteamClient012 SteamClient012;
        public ISteamFriends014 SteamFriends014;

        public SteamApi()
        {
            if (!InitSteamworks())
                return;

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

            // setup callbacks
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
    }
}
