using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.API;

using System.IO;

namespace OPlugin.EventHandlers
{
    public class PlayerDie : IEventHandlerPlayerDie
    {
        OPlugin plugin;
        public PlayerDie(OPlugin plugin)
        {
            this.plugin = plugin;
        }
        public void OnPlayerDie(PlayerDeathEvent ev)
        {
            Func.AddLog($"kill {((int)ev.DamageTypeVar).ToString()} `{ev.Killer.Name}` `{ev.Killer.SteamId}` {ev.Killer.TeamRole.Role} `{ev.Player.Name}` `{ev.Player.SteamId}` {ev.Player.TeamRole.Role};", this.plugin.Server.Port.ToString());
        }
    }
}
