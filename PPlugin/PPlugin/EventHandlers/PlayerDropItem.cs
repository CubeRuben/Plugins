using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;

namespace PPlugin.EventHandlers
{
    class PlayerDropItem : IEventHandlerPlayerDropItem
    {
        PPlugin plugin;

        public PlayerDropItem(PPlugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnPlayerDropItem(PlayerDropItemEvent ev)
        {
            if (ev.Player.GetPosition().y < -1750)
            {
                ev.Allow = false;
            }

            if (this.plugin.round.type == RoundType.BOMBARDMENT)
            {
                ev.Allow = false;
            }
        }
    }
}
