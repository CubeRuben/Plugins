using Smod2;
using Smod2.Attributes;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.API;
using Smod2.Commands;

using System;
using System.IO;
using System.Collections.Generic;

namespace OPlugin
{
    [PluginDetails(author = "CubeRuben", name = "OtherPlugin", description = "Other Plugin", id = "cuberuben.otherplugin", configPrefix = "op", langFile = "OtherPlugin", version = "1.0", SmodMajor = 3, SmodMinor = 4, SmodRevision = 0)]
    public class OPlugin : Plugin
    {
        public List<int> rainbowPlayers = new List<int>();

        public List<FrozedPlayer> frozedPlayers = new List<FrozedPlayer>();

        public string[] colors = { "pink", "red", "brown", "silver", "light_green", "crimson", "cyan", "aqua", "deep_pink", "tomato", "yellow", "magenta", "blue_green", "orange", "lime", "green", "emerald", "carmine", "nickel", "mint", "army_green", "pumkin" };

        public Random random = new Random();

        public bool roundEnded = false;
        public override void OnEnable()
        {
            this.Info($"{this.Details.name} has loaded");
        }

        public override void OnDisable()
        {
            this.Info($"{this.Details.name} has not loaded");
        }

        public override void Register()
        {
            this.AddEventHandler(typeof(IEventHandlerAdminQuery), new EventHandlers.AdminQuery(this));

            this.AddEventHandler(typeof(IEventHandlerDisconnect), new EventHandlers.Disconnect(this));

            this.AddEventHandler(typeof(IEventHandlerFixedUpdate), new EventHandlers.FixedUpdate(this));

            this.AddEventHandler(typeof(IEventHandlerPlayerDie), new EventHandlers.PlayerDie(this));

            this.AddEventHandler(typeof(IEventHandlerPlayerHurt), new EventHandlers.PlayerHurt(this));

            this.AddEventHandler(typeof(IEventHandlerPlayerJoin), new EventHandlers.PlayerJoin(this));

            this.AddEventHandler(typeof(IEventHandlerRoundEnd), new EventHandlers.RoundEnd(this));

            this.AddEventHandler(typeof(IEventHandlerRoundRestart), new EventHandlers.RoundRestart(this));

            this.AddEventHandler(typeof(IEventHandlerRoundStart), new EventHandlers.RoundStart(this));

            this.AddEventHandler(typeof(IEventHandlerTeamRespawn), new EventHandlers.TeamRespawn(this));

            this.AddCommand("ADDDONATER2003", new Commands.AddDonater(this));

            this.AddCommand("ROOMTP", new Commands.RoomTp(this));

            this.AddCommand("FROZE", new Commands.Froze(this));

            this.AddCommand("UNFROZE", new Commands.UnFroze(this));
        }
    }

    public class FrozedPlayer
    {
        public int id;
        public Vector position;

        public FrozedPlayer(int id, Vector position)
        {
            this.id = id;
            this.position = position;
        }
    }

    public static class Func
    {
        public static void AddLog(string content, string port)
        {
            File.WriteAllText($"../serverlogs{port}.txt", File.ReadAllText($"../serverlogs{port}.txt") + DateTime.Now.AddHours(3).Hour + " " + DateTime.Now.AddHours(3).Minute + " " + DateTime.Now.AddHours(3).Second + " " + content);
        }
    }
    

    
            /*public class RoundEnd : IEventHandlerRoundEnd
            {
                OPlugin plugin;
                public RoundEnd(OPlugin plugin)
                {
                    this.plugin = plugin;
                }
                public void OnRoundEnd(RoundEndEvent ev)
                {
                    List<Player> players = ev.Server.GetPlayers();
                    string fileData = File.ReadAllText("info/playerstime.txt");
                    string[] playersData = fileData.Split('\n');

                    for (int i = 0; i < players.Count; i++)
                    {
                        for (int x = 0; x < playersData.Length; x++)
                        {
                            this.plugin.Info(playersData[x].Split(' ')[0]);
                            if (players[i].SteamId == playersData[x].Split(' ')[1])
                            {
                                int minutes = Convert.ToInt32(playersData[x].Split(' ')[1]) + ev.Round.Duration; 
                                string playerstime = "";
                                for (int a = 0; a < playersData.Length; a++)
                                {
                                    if (a != x)
                                    {
                                        playerstime += $"\n{playersData[a]}";
                                    }
                                    else
                                    {
                                        playerstime += $"\n{players[i].SteamId} {minutes.ToString()}";
                                    }
                                }
                                File.WriteAllText("info/playerstime.txt", playerstime);
                                break;
                            }
                            else
                            {
                                int minutes = ev.Round.Duration;
                                string playerstime = File.ReadAllText("info/playerstime.txt") + "\r\n" + players[i].SteamId + " " + minutes;
                                File.WriteAllText("info/playerstime.txt", playerstime);
                                break;
                            }
                        }
                    }
                }
            }

            /*public class PlayerJoin : IEventHandlerPlayerJoin
            {
                OPlugin plugin;
                public PlayerJoin(OPlugin plugin)
                {
                    this.plugin = plugin;
                }
                public void OnPlayerJoin(PlayerJoinEvent ev)
                {
                    this.plugin.playerDatas.Add(new PlayerData(ev.Player.PlayerId, ev.Player.SteamId));
                }
            }

            public class Disconnect : IEventHandlerDisconnect
            {
                OPlugin plugin;
                public Disconnect(OPlugin plugin)
                {
                    this.plugin = plugin;
                }
                public void OnDisconnect(DisconnectEvent ev)
                {
                    string aaa = ev.Connection.IpAddress;
                    this.plugin.Info(aaa);
                    string fileData = File.ReadAllText("info/playerstime.txt");
                    string[] playersData = fileData.Split('\n');
                    PlayerData playerData = new PlayerData(0, "");
                    Player player = this.plugin.PluginManager.Server.GetPlayer(0);

                    for (int i = 0; i < this.plugin.playerDatas.Count; i++)
                    {
                        this.plugin.Info((this.plugin.PluginManager.Server.GetPlayer(this.plugin.playerDatas[i].ID) == null).ToString());
                        this.plugin.Info((this.plugin.PluginManager.Server.GetPlayer(this.plugin.playerDatas[i].ID) != null).ToString());
                        if (player == this.plugin.PluginManager.Server.GetPlayer(this.plugin.playerDatas[i].ID))
                        {
                            this.plugin.Info("Player Founded");
                            playerData = this.plugin.playerDatas[i];
                            break;
                        }
                    }

                    for (int i = 1; i < playersData.Length; i++)
                    {
                        string[] data = playersData[i].Split(' ');
                        this.plugin.Info(data[0] + " " + playerData.SteamID);
                        if (data[0] == playerData.SteamID)
                        {
                            int minutes = Convert.ToInt32(data[1]);
                            minutes += Convert.ToInt32((DateTime.Now - playerData.ConnectedTime).TotalMinutes);
                            string playerstime = "";
                            for (int a = 0; a < playersData.Length; a++)
                            {
                                if (a != i)
                                {
                                    playerstime += $"\n{playersData[a]}";
                                }
                                else
                                {
                                    playerstime += $"\n{data[0]} {minutes.ToString()}";
                                }
                            }
                            File.WriteAllText("info/playerstime.txt", playerstime);
                            break;
                        }
                        else
                        {
                            int minutes = Convert.ToInt32((DateTime.Now - playerData.ConnectedTime).TotalMinutes);
                            string playerstime = File.ReadAllText("info/playerstime.txt") + "\r\n" + playerData.SteamID + " " + minutes;
                            File.WriteAllText("info/playerstime.txt", playerstime);
                            break;
                        }
                    }
                }
            }

            public class PlayerData
            {
                public int ID;
                public string SteamID;
                public DateTime ConnectedTime;
                public PlayerData(int ID, string SteamID)
                {
                    this.ID = ID;
                    this.SteamID = SteamID;
                    this.ConnectedTime = DateTime.Now;
                }
            }*/
}
