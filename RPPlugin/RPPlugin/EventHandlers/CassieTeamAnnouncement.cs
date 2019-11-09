using Smod2;
using Smod2.API;
using Smod2.EventHandlers;
using Smod2.Events;

namespace RPPlugin.EventHandlers
{
    class CassieTeamAnnouncement : IEventHandlerCassieTeamAnnouncement
    {
        RPPlugin plugin;

        public CassieTeamAnnouncement(RPPlugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnCassieTeamAnnouncement(CassieTeamAnnouncementEvent ev)
        {
            /*if (this.plugin.MTFADisabled)
            {
                ev.Allow = false;
                this.plugin.MTFADisabled = false;
            }*/
        }
    }
}
