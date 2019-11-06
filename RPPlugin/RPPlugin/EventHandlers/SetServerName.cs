using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;

namespace RPPlugin.EventHandlers
{
    class SetServerName : IEventHandlerSetServerName
    {
        RPPlugin plugin;

        public SetServerName(RPPlugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnSetServerName(SetServerNameEvent ev)
        {
            ev.ServerName = "<b><size=30>[<color=#ffffffff>R</color><color=#0000ffff>U</color><color=#ff0000ff>S</color>] <color=#ce4d4dff>Zone 19 staff #2</color> || <color=yellow>LightRP \"Бета Тест\"</color></size></b>\n<size=20>| <color=#5e80ffff>Наш Discord сервер, присоединяйтесь - discord.gg/AdnbUZk</color> |</size>";
        }
    }
}
