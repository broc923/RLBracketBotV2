using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BracketBot.Steam;
using System.Net;
using System.Collections.Specialized;
using Steam4NET;

namespace BracketBot.Website {
    class RLBracketAPI {
        private string website;
        public RLBracketAPI() {
            website = "http://rlbracket.com/api/";
        }

        public string GetInviteQueue() {
            using (WebClient client = new WebClient()) {
                return client.DownloadString(website + "inviteQueue.php");
            }
        }

        public void AddInviteQueue(CSteamID sender, bool addOrGet) {

        }

        public string GetItemsToReturn(CSteamID sender) {
            using (WebClient client = new WebClient()) {
                byte[] resp = client.UploadValues(website + "getItemsToReturn.php", new NameValueCollection() {
                    { "SteamID", sender.ToString() },
                });
                return client.DownloadString(website + "getItemsToReturn.php");
            }
        }
    }
}
