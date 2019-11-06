using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.API;

namespace RPPlugin.EventHandlers
{
    class WarheadChangeLever : IEventHandlerWarheadChangeLever
    {
        RPPlugin plugin;

        public WarheadChangeLever(RPPlugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnChangeLever(WarheadChangeLeverEvent ev)
        {
            switch (ev.Player.TeamRole.Role)
            {
                case Role.SCP_173:
                case Role.SCP_939_53:
                case Role.SCP_939_89:
                case Role.SCP_096:
                    ev.Allow = false;
                    break;
            }
        }
    }
}
