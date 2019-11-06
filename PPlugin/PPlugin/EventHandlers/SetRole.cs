using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.API;

using System.Collections.Generic;

namespace PPlugin.EventHandlers
{
    class SetRole : IEventHandlerSetRole
    {
        PPlugin plugin;

        public SetRole(PPlugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnSetRole(PlayerSetRoleEvent ev)
        {

            if ((ev.Player.TeamRole.Role == Role.CLASSD) || (ev.Player.TeamRole.Role == Role.SCIENTIST))
            {
                Func.ClearAmmo(ev.Player);
            }

            if (ev.Player.TeamRole.Role == Role.FACILITY_GUARD)
            {
                ev.Player.SetAmmo(AmmoType.DROPPED_7, 140);
            }

            Player player = this.plugin.PluginManager.Server.GetPlayer(ev.Player.PlayerId);

            if (this.plugin.round.eventEnabled)
            {
                if (player == null)
                {
                    return;
                }

                if ((ev.Role == Role.SPECTATOR) && this.plugin.round.playing)
                {
                    switch (this.plugin.round.type)
                    {
                        case RoundType.INFECTION_173:
                            if (!this.plugin.PluginManager.Server.Map.LCZDecontaminated && !this.plugin.PluginManager.Server.Map.WarheadDetonated)
                            {
                                ev.Role = Role.SCP_173;
                                player.ChangeRole(Role.SCP_173);
                            }
                            break;
                        case RoundType.INFECTION_106:
                            if (!this.plugin.PluginManager.Server.Map.WarheadDetonated)
                            {
                                ev.Role = Role.SCP_106;
                                player.ChangeRole(Role.SCP_106);
                            }
                            break;
                        case RoundType.INFECTION_049_2:
                            if (!this.plugin.PluginManager.Server.Map.WarheadDetonated)
                            {
                                ev.Role = Role.SCP_049_2;
                                player.ChangeRole(Role.SCP_049_2, true, false);
                            }
                            break;
                        case RoundType.INFECTION_939:
                            if (!this.plugin.PluginManager.Server.Map.WarheadDetonated)
                            {
                                ev.Role = Role.SCP_939_89;
                                player.ChangeRole(Role.SCP_939_89);
                            }
                            break;
                        case RoundType.JAIL:
                            break;
                        case RoundType.MTF_VS_CHAOS:
                            if (ev.Player.TeamRole.Role == Role.CHAOS_INSURGENCY)
                            {
                                ev.Role = Role.NTF_COMMANDER;
                                player.ChangeRole(Role.NTF_COMMANDER);
                            }
                            else if (ev.Player.TeamRole.Role == Role.NTF_COMMANDER)
                            {
                                ev.Role = Role.CHAOS_INSURGENCY;
                                player.ChangeRole(Role.CHAOS_INSURGENCY);
                                
                            }
                            break;
                        case RoundType.BATTLE_ROYALE:
                            int count = 0;
                            List<Player> players = this.plugin.PluginManager.Server.GetPlayers();

                            for (int i = 0; i < players.Count; i++)
                            {
                                if (players[i].TeamRole.Role == Role.CLASSD)
                                {
                                    if (players[i].PlayerId != ev.Player.PlayerId)
                                    {
                                        count++;
                                    }
                                }
                            }

                            if (count <= 1)
                            {
                                this.plugin.PluginManager.Server.Map.AnnounceCustomMessage("LAST CLASSD . YOU WILL BE DEAD");
                            }
                            else
                            {
                                this.plugin.PluginManager.Server.Map.AnnounceCustomMessage($"{count} CLASSD LEFT");
                            }
                            break;
                        case RoundType.HOSTAGES:
                            break;
                        case RoundType.BOMBARDMENT:
                            ev.Role = Role.SCIENTIST;
                            player.ChangeRole(Role.SCIENTIST, true, false);
                            List<Item> items = player.GetInventory();
                            for (int i = 0; i< items.Count; i++)
                            {
                                items[i].Remove();
                            }

                            player.GiveItem(ItemType.FRAG_GRENADE);
                            break;
                    }
                }
            }
        }
    }
}
