using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.API;

namespace PPlugin.EventHandlers
{
    class PlayerPickupItem : IEventHandlerPlayerPickupItem
    {
        PPlugin plugin;

        public PlayerPickupItem(PPlugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnPlayerPickupItem(PlayerPickupItemEvent ev)
        {
            if (this.plugin.round.type == RoundType.BOMBARDMENT)
            {
                if (ev.Item.ItemType == ItemType.P90)
                {
                    ev.Allow = false;
                }
            }
        }
    }
}
