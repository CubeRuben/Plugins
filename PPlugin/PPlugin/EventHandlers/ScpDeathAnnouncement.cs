using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;

namespace PPlugin.EventHandlers
{
    class ScpDeathAnnouncement : IEventHandlerScpDeathAnnouncement
    {
        PPlugin plugin;

        public ScpDeathAnnouncement(PPlugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnScpDeathAnnouncement(ScpDeathAnnouncementEvent ev)
        {
            if (this.plugin.round.eventEnabled)
            {
                ev.ShouldPlay = false;
            }
        }
    }
}
