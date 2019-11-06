using System;
using System.IO;

using Smod2;
using Smod2.Events;
using Smod2.EventHandlers;

namespace OPlugin.EventHandlers
{
    public class PlayerJoin : IEventHandlerPlayerJoin
    {
        OPlugin plugin;
        public PlayerJoin(OPlugin plugin)
        {
            this.plugin = plugin;
        }
        public void OnPlayerJoin(PlayerJoinEvent ev)
        {
            File.WriteAllText("../server" + this.plugin.Server.Port + ".txt", this.plugin.PluginManager.Server.NumPlayers.ToString());

            Func.AddLog($"join `{ev.Player.Name}` `{ev.Player.SteamId}`;", this.plugin.Server.Port.ToString());

            string donaters = File.ReadAllText("../donaters.txt");

            string[] donater = donaters.Split(';');

            for (int i = 0; i < donater.Length; i++)
            {
                if (donater[i].Split(' ')[0] == ev.Player.SteamId)
                {
                    string[] donaterData = donater[i].Split(' ');

                    DateTime today = DateTime.Today;

                    DateTime dateEnd = new DateTime(Convert.ToInt32(donaterData[3]), Convert.ToInt32(donaterData[2]), Convert.ToInt32(donaterData[1]));

                    if (dateEnd <= today)
                    {
                        string removedOutDateDonater = "";

                        for (int a = 0; a < donater.Length; a++)
                        {
                            if (a != i)
                            {
                                removedOutDateDonater += $"{donater[a]};";
                            }
                        }

                        File.WriteAllText("../donaters.txt", removedOutDateDonater);
                        break;
                    }

                    if (donaterData[4] == "rainbow")
                    {
                        this.plugin.rainbowPlayers.Add(ev.Player.PlayerId);
                    }
                    else
                    {
                        ev.Player.SetRank(donaterData[4], "Донатер");
                    }
                    break;
                }
            }
        }
    }
}
