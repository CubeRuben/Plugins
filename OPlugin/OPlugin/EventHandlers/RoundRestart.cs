using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;

namespace OPlugin.EventHandlers
{
    public class RoundRestart : IEventHandlerRoundRestart
    {
        OPlugin plugin;
        public RoundRestart(OPlugin plugin)
        {
            this.plugin = plugin;
        }
        public void OnRoundRestart(RoundRestartEvent ev)
        {
            this.plugin.rainbowPlayers.Clear();
            this.plugin.frozedPlayers.Clear();
        }
    }
}
