using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.API;

using System.Collections.Generic;
using System;

namespace RPPlugin.EventHandlers
{
    class Player106CreatePortal : IEventHandler106CreatePortal
    {
        RPPlugin plugin;

        public Player106CreatePortal(RPPlugin plugin)
        {
            this.plugin = plugin;
        }

        public void On106CreatePortal(Player106CreatePortalEvent ev)
        {
            List<Elevator> allElevators = this.plugin.PluginManager.Server.Map.GetElevators();

            for (int i = 0; i < allElevators.Count; i++)
            {
                List<Vector> elevators = allElevators[i].GetPositions();
                for (int a = 0; a < elevators.Count; a++)
                {
                    if ((Math.Sqrt(Math.Pow(ev.Player.GetPosition().x - elevators[a].x, 2) + Math.Pow(ev.Player.GetPosition().z - elevators[a].z, 2)) <= 50) && (ev.Player.GetPosition().y <= elevators[a].y + 20) && (ev.Player.GetPosition().y >= elevators[a].y - 20))
                    {
                        ev.Position = new Vector(0, 0, 0);
                        ev.Player.PersonalClearBroadcasts();
                        ev.Player.PersonalBroadcast(5, "<color=red><b>Здесь нельзя создать портал</b></color>", true);
                        return;
                    }
                }
            }


            /*if (this.plugin.SCP106CanTeleportToPlayer != 0)
            {
                List<Player> players = this.plugin.PluginManager.Server.GetPlayers();

                List<Player> playersOnlyHumans = new List<Player>();

                for (int i = 0; i < players.Count; i++)
                {
                    if ((players[i].TeamRole.Team != Team.SCP) && (players[i].TeamRole.Role != Role.SPECTATOR) && (players[i].TeamRole.Role != Role.TUTORIAL))
                    {
                        if (players[i].GetPosition().y >= -1900)
                        {
                            playersOnlyHumans.Add(players[i]);
                        }
                    }
                }

                if (playersOnlyHumans.Count == 0)
                {
                    ev.Player.PersonalClearBroadcasts();
                    ev.Player.PersonalBroadcast(10, "В комплексе нет людей", false);
                    return;
                }

                int randomNumber = this.plugin.random.Next(playersOnlyHumans.Count);

                ev.Player.PersonalBroadcast(10, "<b>Вы создали портал под человеком</b>", false);

                ev.Position = playersOnlyHumans[randomNumber].GetPosition() - new Vector(0, 2.3295f, 0);
                playersOnlyHumans[randomNumber].PersonalClearBroadcasts();
                playersOnlyHumans[randomNumber].PersonalBroadcast(10, "<b>Вы чувствуете запах гнили</b>", false);
                this.plugin.SCP106CanTeleportToPlayer--;
            }*/
        }
    }
}
