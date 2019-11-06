using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;

namespace RPPlugin.EventHandlers
{
    class MedkitUse : IEventHandlerMedkitUse
    {
        RPPlugin plugin;

        public MedkitUse(RPPlugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnMedkitUse(PlayerMedkitUseEvent ev)
        {
            bool removed = this.plugin.bleedingPlayers.Remove(ev.Player.PlayerId);
            if (removed)
            {
                ev.Player.PersonalClearBroadcasts();
                ev.Player.PersonalBroadcast(4, "<b><color=light_green>Вы излечились</color></b>", true);
            }
        }
    }
}
