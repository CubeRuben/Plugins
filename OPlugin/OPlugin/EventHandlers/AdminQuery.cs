using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;

using System.IO;

namespace OPlugin.EventHandlers
{
    public class AdminQuery : IEventHandlerAdminQuery
    {
        OPlugin plugin;
        public AdminQuery(OPlugin plugin)
        {
            this.plugin = plugin;
        }
        public void OnAdminQuery(AdminQueryEvent ev)
        {
            if (ev.Query != "REQUEST_DATA PLAYER_LIST SILENT")
            {
                Func.AddLog($"admin {ev.Admin.SteamId} \"{ev.Admin.Name}\" {ev.Query};", this.plugin.Server.Port.ToString());
            }
        }
    }
   
}
