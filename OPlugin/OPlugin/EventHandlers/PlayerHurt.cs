using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.API;

using System.IO;

namespace OPlugin.EventHandlers
{
    public class PlayerHurt : IEventHandlerPlayerHurt
    {
        OPlugin plugin;
        public PlayerHurt(OPlugin plugin)
        {
            this.plugin = plugin;
        }
        public void OnPlayerHurt(PlayerHurtEvent ev)
        {
            Func.AddLog($"hurt {ev.DamageType} \"{ev.Attacker.Name}\" {ev.Attacker.SteamId} {ev.Attacker.TeamRole.Role} \"{ev.Player.Name}\" {ev.Player.SteamId} {ev.Player.TeamRole.Role};", this.plugin.Server.Port.ToString());
        }
    }
}
