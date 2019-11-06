using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.EventSystem.Events;

namespace PPlugin.EventHandlers
{
    class TeamRespawn : IEventHandlerTeamRespawn
    {
        PPlugin plugin;

        public TeamRespawn(PPlugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnTeamRespawn(TeamRespawnEvent ev)
        {
            if (this.plugin.round.eventEnabled)
            {
                ev.PlayerList.Clear();
            }
        }
    }
}
