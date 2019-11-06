using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.API;

using System.Collections.Generic;

namespace PPlugin.EventHandlers
{
    class CheckRoundEnd : IEventHandlerCheckRoundEnd
    {
        PPlugin plugin;

        public CheckRoundEnd(PPlugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnCheckRoundEnd(CheckRoundEndEvent ev)
        {
            if (this.plugin.round.eventEnabled)
            {
                List<Player> players = this.plugin.PluginManager.Server.GetPlayers();

                switch (this.plugin.round.type)
                {
                    case RoundType.BATTLE_ROYALE:
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
                                if (players[i].TeamRole.Role == Role.CLASSD)
                                {
                                    this.plugin.winnersId.BATTLE_ROYALE = players[i].SteamId;
                                    Files.SetText("battle_royale.txt", players[i].SteamId);
                                    players[i].SetRank("red", "Победитель битвы");
                                    break;
                                }
                            }
                        }
                        else
                        {
                            ev.Status = ROUND_END_STATUS.ON_GOING;
                        }
                        break;
                    case RoundType.HOSTAGES:
                        bool haveMTF = false, haveChaos = false, haveScientist = false, haveNTF5 = false, haveChaos5 = false, haveNTFScientist = false;
                        for (int i = 0; i < players.Count; i++)
                        {
                            if (players[i].TeamRole.Role == Role.SCIENTIST)
                            {
                                haveScientist = true;
                            }

                            if (players[i].TeamRole.Role == Role.NTF_SCIENTIST)
                            {
                                haveNTFScientist = true;
                            }

                            if (players[i].TeamRole.Team == Team.NINETAILFOX)
                            {
                                haveMTF = true;
                            }

                            if (players[i].TeamRole.Role == Role.CHAOS_INSURGENCY)
                            {
                                haveChaos = true;
                            }

                            List<Item> items = players[i].GetInventory();
                            for (int a = 0; a < items.Count; a++)
                            {
                                if (items[a].ItemType == ItemType.O5_LEVEL_KEYCARD)
                                {
                                    switch (players[i].TeamRole.Team)
                                    {
                                        case Team.NINETAILFOX:
                                        case Team.SCIENTIST:
                                            haveNTF5 = true;
                                            break;
                                        case Team.CHAOS_INSURGENCY:
                                            haveChaos5 = true;
                                            break;
                                    }
                                }
                            }
                        }

                        if (haveNTFScientist)
                        {
                            ev.Status = ROUND_END_STATUS.MTF_VICTORY;
                        }
                        else if (!haveScientist && haveChaos5)
                        {
                            ev.Status = ROUND_END_STATUS.CI_VICTORY;
                        }
                        else if (!haveScientist && haveNTF5)
                        {
                            ev.Status = ROUND_END_STATUS.MTF_VICTORY;
                        }
                        else if (!haveScientist && !haveChaos5 && !haveNTF5)
                        {
                            ev.Status = ROUND_END_STATUS.NO_VICTORY;
                        }
                        else if (!haveMTF)
                        {
                            ev.Status = ROUND_END_STATUS.CI_VICTORY;
                        }
                        else if (!haveChaos)
                        {
                            ev.Status = ROUND_END_STATUS.MTF_VICTORY;
                        }
                        else
                        {
                            ev.Status = ROUND_END_STATUS.ON_GOING;
                        }
                        break;
                }
            }
        }
    }
}
