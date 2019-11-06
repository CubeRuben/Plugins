using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.API;

using System.Collections.Generic;

namespace PPlugin.EventHandlers
{
    class RoundEnd : IEventHandlerRoundEnd
    {
        PPlugin plugin;

        public RoundEnd(PPlugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnRoundEnd(RoundEndEvent ev)
        {
            this.plugin.round.ended = true;
            
        }
    }
}
