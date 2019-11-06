using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;

namespace PPlugin.EventHandlers
{
    class Ban : IEventHandlerBan
    {
        PPlugin plugin;

        public Ban(PPlugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnBan(BanEvent ev)
        {
            this.plugin.Server.Map.Broadcast(10, $"<color=red>{ ev.Player.Name }</color> был заблокирован на этом сервере", true);
        }
    }
}
