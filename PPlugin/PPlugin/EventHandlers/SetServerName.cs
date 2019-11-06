using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;

namespace PPlugin.EventHandlers
{
    class SetServerName : IEventHandlerSetServerName
    {
        PPlugin plugin;

        public SetServerName(PPlugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnSetServerName(SetServerNameEvent ev)
        {
            switch (ev.Server.Port)
            {
                case 7777:
                    ev.ServerName = "<b><size=30>[<color=#ffffffff>R</color><color=#0000ffff>U</color><color=#ff0000ff>S</color>] <color=#ce4d4dff>Zone 19 staff #1</color> || <color=yellow>Авто-Ивенты</color></size></b>\n<size=20>| <color=#5e80ffff>Наш Discord сервер, присоединяйтесь - discord.gg/AdnbUZk</color> |</size>";
                    break;
            }
        }
    }
}
