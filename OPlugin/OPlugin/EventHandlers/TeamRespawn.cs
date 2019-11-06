using Smod2;
using Smod2.EventHandlers;
using Smod2.EventSystem.Events;

using System.IO;

namespace OPlugin.EventHandlers
{
    public class TeamRespawn : IEventHandlerTeamRespawn
    {
        OPlugin plugin;
        public TeamRespawn(OPlugin plugin)
        {
            this.plugin = plugin;
        }
        public void OnTeamRespawn(TeamRespawnEvent ev)
        {
            Func.AddLog($"teamrespawn {ev.SpawnChaos};", this.plugin.Server.Port.ToString());
        }
    }
}
