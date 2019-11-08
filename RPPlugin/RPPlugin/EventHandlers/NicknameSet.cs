using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.API;

using System;

namespace RPPlugin.EventHandlers
{
    class NicknameSet : IEventHandlerNicknameSet
    {
        RPPlugin plugin;

        public NicknameSet(RPPlugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnNicknameSet(PlayerNicknameSetEvent ev)
        {
            //Игнорирование сервера
            if (ev.Player.IpAddress != "localClient")
            {
                //Установка ника
                ev.Nickname += " [" + this.plugin.playersNames[this.plugin.random.Next(this.plugin.playersNames.Length)] + "/" + this.plugin.random.Next(10).ToString() + this.plugin.random.Next(10).ToString() + this.plugin.random.Next(10).ToString() + this.plugin.random.Next(10).ToString() + "]";
            }
        }
    }
}
