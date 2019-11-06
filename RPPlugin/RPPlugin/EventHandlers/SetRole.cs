using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.API;

namespace RPPlugin.EventHandlers
{
    class SetRole : IEventHandlerSetRole
    {
        RPPlugin plugin;

        public SetRole(RPPlugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnSetRole(PlayerSetRoleEvent ev)
        {
            if ((ev.TeamRole.Team != Smod2.API.Team.SCP) && (ev.TeamRole.Team != Smod2.API.Team.SPECTATOR))
            {
                ev.Player.PersonalClearBroadcasts();
                ev.Player.PersonalBroadcast(7, $"<b>Ваши данные - {ev.Player.Name.Split(' ')[ev.Player.Name.Split(' ').Length - 1]}</b>", true);
            }

            switch (ev.Role)
            {
                case Role.SCIENTIST:
                case Role.CLASSD:
                    ev.Player.SetAmmo(AmmoType.DROPPED_5, 0);
                    ev.Player.SetAmmo(AmmoType.DROPPED_7, 0);
                    ev.Player.SetAmmo(AmmoType.DROPPED_9, 0);
                    break;
            }
        }
    }
}
