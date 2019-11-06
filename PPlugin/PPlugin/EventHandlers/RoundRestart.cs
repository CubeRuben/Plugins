using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;

namespace PPlugin.EventHandlers
{
    class RoundRestart : IEventHandlerRoundRestart
    {
        PPlugin plugin;

        public RoundRestart(PPlugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnRoundRestart(RoundRestartEvent ev)
        {
            this.plugin.teamKillPlayers.Clear();
            this.plugin.cameraVectors.Clear();
            this.plugin.round.Clear();
            this.plugin.broadcastSCPDeath = true;
            this.plugin.round.eventEnabled = !this.plugin.round.eventEnabled;
            this.plugin.round.playing = false;
            this.plugin.rusNamesEnabled = false;
            if (this.plugin.random.NextDouble() <= 0.01)
            {
                this.plugin.rusNamesEnabled = true;
            }
            //this.plugin.roundPlaying = false;
        }
    }
}
