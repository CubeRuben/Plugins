using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;

using System.IO;

namespace OPlugin.EventHandlers
{
    public class RoundEnd : IEventHandlerRoundEnd
    {
        OPlugin plugin;
        public RoundEnd(OPlugin plugin)
        {
            this.plugin = plugin;
        }
        public void OnRoundEnd(RoundEndEvent ev)
        {
            this.plugin.roundEnded = true;

            Func.AddLog($"roundend {((int)ev.Status).ToString()} {ev.Round.Duration.ToString()};", this.plugin.Server.Port.ToString());
        }
    }
}
