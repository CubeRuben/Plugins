using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.API;

namespace RPPlugin.EventHandlers
{
    class PlayerHurt : IEventHandlerPlayerHurt
    {
        RPPlugin plugin;

        public PlayerHurt(RPPlugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnPlayerHurt(PlayerHurtEvent ev)
        {
            //Проверка на кровотечение
            if (((ev.DamageType == DamageType.COM15) || (ev.DamageType == DamageType.E11_STANDARD_RIFLE) || (ev.DamageType == DamageType.FRAG) || (ev.DamageType == DamageType.LOGICER) || (ev.DamageType == DamageType.MP7) || (ev.DamageType == DamageType.P90) || (ev.DamageType == DamageType.SCP_939) || (ev.DamageType == DamageType.USP)) && (ev.Player.TeamRole.Team != Smod2.API.Team.SCP) && (ev.Player.TeamRole.Team != Smod2.API.Team.TUTORIAL) && (ev.Player.TeamRole.Team != Smod2.API.Team.SPECTATOR))
            {
                for (int i = 0; i < this.plugin.bleedingPlayers.Count; i++)
                {
                    if (this.plugin.bleedingPlayers[i] == ev.Player.PlayerId)
                    {
                        goto founded;
                    }
                }

                ev.Player.PersonalClearBroadcasts();
                ev.Player.PersonalBroadcast(10, "<b><color=red>Вы начали кровоточить</color></b>", true);
                this.plugin.bleedingPlayers.Add(ev.Player.PlayerId);
            }

            //Проверка на гниение
            if ((ev.DamageType == DamageType.SCP_106) && (ev.Player.TeamRole.Team != Smod2.API.Team.SCP) && (ev.Player.TeamRole.Team != Smod2.API.Team.TUTORIAL) && (ev.Player.TeamRole.Team != Smod2.API.Team.SPECTATOR))
            {
                for (int i = 0; i < this.plugin.rottingPlayers.Count; i++)
                {
                    if (this.plugin.rottingPlayers[i] == ev.Player.PlayerId)
                    {
                        goto founded;
                    }
                }

                ev.Player.PersonalClearBroadcasts();
                ev.Player.PersonalBroadcast(10, "<b><color=red>Вы начали гнить</color></b>", true);
                this.plugin.rottingPlayers.Add(ev.Player.PlayerId);
            }
        founded:;
        }
    }
}
