using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;

namespace PPlugin.EventHandlers
{
    class CheckEscape : IEventHandlerCheckEscape
    {
        PPlugin plugin;

        public CheckEscape(PPlugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnCheckEscape(PlayerCheckEscapeEvent ev)
        {
            if (this.plugin.round.eventEnabled)
            {
                if (this.plugin.round.type == RoundType.BATTLE_ROYALE)
                {
                    ev.AllowEscape = false;
                }
            }
        }
    }
}
