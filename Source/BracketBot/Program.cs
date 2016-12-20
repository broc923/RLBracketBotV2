using Steam4NET;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BracketBot.Steam;
using BracketBot.Website;
using Newtonsoft.Json;

namespace BracketBot
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create object and initialize API.
            SteamApi steam = new SteamApi();
            Console.WriteLine("Steam API Setup Done");
            RLBracketAPI website = new RLBracketAPI();
            Console.WriteLine("Website API setup done");

            //sets the account's online status to be online
            steam.SetPersonaState(EPersonaState.k_EPersonaStateOnline);
            Console.WriteLine("Set persona state to online");

            // Handle callbacks (Chat, game invites, friend requests)
            //NOthing will execute past this point unless it's also a task
            Console.WriteLine("Starting Steam Callbacks beng Handled");
            List<Task> tasks = new List<Task>();
            tasks.Add(Task.Run(() => { steam.ChatHandler(); }));
            tasks.Add(Task.Run(() => { steam.FriendRequestHandler(); }));
            tasks.Add(Task.Run(() => { steam.FriendRequestHandler(); }));
            Task.WaitAll(tasks.ToArray());
        }
    }
}
