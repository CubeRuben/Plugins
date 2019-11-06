using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.API;


using System.Collections.Generic;

namespace PPlugin.EventHandlers
{
    class PlayerDie : IEventHandlerPlayerDie
    {
        PPlugin plugin;

        public PlayerDie(PPlugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnPlayerDie(PlayerDeathEvent ev)
        {
            if (ev.Player.GetPosition().y < -1750)
            {
                if (Func.RotVec(this.plugin.scp106Room.Forward, Vector.Forward))
                {
                    ev.Player.Teleport(this.plugin.scp106Room.Position + new Vector((float)(24 - this.plugin.random.NextDouble() * 32), 7, this.plugin.random.Next(4) - 2));
                }
                else if (Func.RotVec(this.plugin.scp106Room.Forward, Vector.Right))
                {
                    ev.Player.Teleport(this.plugin.scp106Room.Position + new Vector(this.plugin.random.Next(4) - 2, 7, (float)(-24 + this.plugin.random.NextDouble() * 32)));
                }
                else if (Func.RotVec(this.plugin.scp106Room.Forward, Vector.Back))
                {
                    ev.Player.Teleport(this.plugin.scp106Room.Position + new Vector((float)(-24 + this.plugin.random.NextDouble() * 32), 7, this.plugin.random.Next(4) - 2));
                }
                else if (Func.RotVec(this.plugin.scp106Room.Forward, Vector.Left))
                {
                    ev.Player.Teleport(this.plugin.scp106Room.Position + new Vector(this.plugin.random.Next(4) - 2, 7, (float)(24 - this.plugin.random.NextDouble() * 32)));
                }
            }

            if ((ev.Player.TeamRole.Team == ev.Killer.TeamRole.Team) && (ev.Player.PlayerId != ev.Killer.PlayerId) && (ev.Killer.TeamRole.Role != Role.CLASSD) && (ev.Player.TeamRole.Role != Role.CLASSD) && !this.plugin.round.ended)
            {
                bool founded = false;
                TeamKillPlayer killer = new TeamKillPlayer();

                for (int i = 0; i < this.plugin.teamKillPlayers.Count; i++)
                {
                    if (this.plugin.teamKillPlayers[i].id == ev.Killer.PlayerId)
                    {
                        founded = true;
                        killer = this.plugin.teamKillPlayers[i];
                        break;
                    }
                }

                if (founded)
                {
                    killer.count++;
                }
                else
                {
                    killer.id = ev.Killer.PlayerId;
                    killer.count = 1;
                    this.plugin.teamKillPlayers.Add(killer);
                }

                ev.Killer.SetHealth(ev.Killer.GetHealth() - 50);

                ev.Killer.SetRank("red", $"*Убил своих: {killer.count}*");
            }

            if ((ev.Player.TeamRole.Team == Team.SCP) && this.plugin.broadcastSCPDeath && !this.plugin.round.eventEnabled)
            {
                string name_scp;
                switch (ev.Player.TeamRole.Role)
                {
                    case Role.SCP_049:
                        name_scp = "SCP-049 \"Чумной Доктор\"";
                        break;
                    case Role.SCP_079:
                        name_scp = "SCP-079 \"Старый ИИ\"";
                        break;
                    case Role.SCP_096:
                        name_scp = "SCP-096 \"Скромник\"";
                        break;
                    case Role.SCP_106:
                        name_scp = "SCP-106 \"Старик\"";
                        break;
                    case Role.SCP_173:
                        name_scp = "SCP-173 \"Скульптура\"";
                        break;
                    case Role.SCP_939_53:
                        name_scp = "SCP-939 \"Со множеством голосов\"";
                        break;
                    case Role.SCP_939_89:
                        name_scp = "SCP-939 \"Со множеством голосов\"";
                        break;
                    default:
                        name_scp = "NONE";
                        break;
                }

                if (name_scp != "NONE")
                {
                    this.plugin.PluginManager.Server.Map.Broadcast(10, $"Условия содержания {name_scp} успешно восстановлены", true);
                }
            }

            if (this.plugin.round.eventEnabled)
            {
                ev.SpawnRagdoll = false;
                switch (this.plugin.round.type)
                {
                    case RoundType.BOMBARDMENT:

                        List<Player> players = this.plugin.PluginManager.Server.GetPlayers();

                        if (ev.Player.TeamRole.Role == Role.SCIENTIST)
                        {
                            List<Item> items = ev.Player.GetInventory();

                            for (int i = 0; i < items.Count; i++)
                            {
                                items[i].Remove();
                            }
                        }

                        int count = 0;

                        for (int i = 0; i < players.Count; i++)
                        {
                            if (players[i].TeamRole.Role == Role.CLASSD)
                            {
                                count++;
                            }
                        }

                        if (count <= 1)
                        {
                            for (int i = 0; i < players.Count; i++)
                            {
                                this.plugin.Round.EndRound();
                                if (players[i].TeamRole.Role == Role.CLASSD)
                                {
                                    this.plugin.winnersId.BOMBARDMENT = players[i].SteamId;
                                    Files.SetText("bombardmant.txt", players[i].SteamId);
                                    players[i].SetRank("red", "Выжил при бомбардировке");
                                    break;
                                }
                            }
                        }
                        break;
                }
            }
        }
    }
}
