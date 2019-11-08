using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.API;

using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Networking;

namespace RPPlugin.EventHandlers
{
    class PlayerDie : IEventHandlerPlayerDie
    {
        RPPlugin plugin;

        public PlayerDie(RPPlugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnPlayerDie(PlayerDeathEvent ev)
        {
            //Удаление игрока из массива гниющих и кровоточущих
            this.plugin.bleedingPlayers.Remove(ev.Player.PlayerId);
            this.plugin.rottingPlayers.Remove(ev.Player.PlayerId);

            for (int i = 0; i < this.plugin.pickedUpRagdolls.Count; i++)
            {
                if (this.plugin.pickedUpRagdolls[i].playerId == ev.Player.PlayerId)
                {
                    this.plugin.pickedUpRagdolls.RemoveAt(i);
                }
            }
            /*if ((ev.DamageTypeVar == DamageType.SCP_106) || (ev.DamageTypeVar == DamageType.POCKET))
            {
                if (this.plugin.SCP106CanTeleportToPlayer == 0)
                {
                    List<Player> players = this.plugin.PluginManager.Server.GetPlayers();
                    Player scp106 = players[0];

                    for (int i = 0; i < players.Count; i++)
                    {
                        if (players[i].TeamRole.Role == Role.SCP_106)
                        {
                            scp106 = players[i];
                            break;
                        }
                    }

                    if (scp106 == null) { return; }

                    scp106.PersonalClearBroadcasts();
                    scp106.PersonalBroadcast(10, "<b>Вы можете создать портал под случайным человеком</b>", false);

                    this.plugin.SCP106CanTeleportToPlayer = 2;
                }
            }*/

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

            /*if (ev.Killer.TeamRole.Role == Role.CLASSD)
            {
                for (int i = 0; i < this.plugin.idPlayersForTermination.Count; i++)
                {
                    if (this.plugin.idPlayersForTermination[i] == ev.Killer.PlayerId)
                    {
                        goto playerTerminated;
                    }
                }

                this.plugin.idPlayersForTermination.Add(ev.Killer.PlayerId);

                char[] nickname = ev.Killer.Name.ToCharArray();

                this.plugin.PluginManager.Server.Map.AnnounceCustomMessage("CLASSD " + nickname[nickname.Length - 5] + " " + nickname[nickname.Length - 4] + " " + nickname[nickname.Length - 3] + " " + nickname[nickname.Length - 2] + " DESIGNATED FOR TERMINATION .");
            }
        playerTerminated:;*/

        }   
    }
}
