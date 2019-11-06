using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.API;

namespace PPlugin.EventHandlers
{
    class ThrowGrenade : IEventHandlerThrowGrenade
    {
        PPlugin plugin;

        public ThrowGrenade(PPlugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnThrowGrenade(PlayerThrowGrenadeEvent ev)
        {
            if (this.plugin.round.eventEnabled)
            {
                switch (this.plugin.round.type)
                {
                    case RoundType.BOMBARDMENT:
                        if (ev.GrenadeType == GrenadeType.FRAG_GRENADE)
                        {
                            ev.Player.GiveItem(ItemType.FRAG_GRENADE);
                        }
                        break;
                }
            }
        }
    }
}
