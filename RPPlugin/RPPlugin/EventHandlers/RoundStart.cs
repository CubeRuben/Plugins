using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.API;

using System.Collections.Generic;

namespace RPPlugin.EventHandlers
{
    class RoundStart : IEventHandlerRoundStart
    {
        RPPlugin plugin;

        public RoundStart(RPPlugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnRoundStart(RoundStartEvent ev)
        {

        }
    }
}
