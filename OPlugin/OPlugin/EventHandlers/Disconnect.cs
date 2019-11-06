using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;

using System.IO;

namespace OPlugin.EventHandlers
{
    public class Disconnect : IEventHandlerDisconnect
    {
        OPlugin plugin;
        public Disconnect(OPlugin plugin)
        {
            this.plugin = plugin;
        }
        public void OnDisconnect(DisconnectEvent ev)
        {
            File.WriteAllText("../server" + this.plugin.Server.Port + ".txt", this.plugin.PluginManager.Server.NumPlayers.ToString());
        }
    }
   
}
