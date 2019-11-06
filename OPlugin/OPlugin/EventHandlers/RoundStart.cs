using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;

namespace OPlugin.EventHandlers
{
    public class RoundStart : IEventHandlerRoundStart
    {
        OPlugin plugin;
        public RoundStart(OPlugin plugin)
        {
            this.plugin = plugin;
        }
        public void OnRoundStart(RoundStartEvent ev)
        {
            this.plugin.roundEnded = false;

            Func.AddLog($"roundstart;", this.plugin.Server.Port.ToString());
        }
    }
}
