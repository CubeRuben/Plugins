using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.API;

using System.Collections.Generic;
using System;

namespace PPlugin.EventHandlers
{
    class PlayerJoin : IEventHandlerPlayerJoin
    {
        PPlugin plugin;

        public PlayerJoin(PPlugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnPlayerJoin(PlayerJoinEvent ev)
        {
            if (this.plugin.waitingForPlayers)
            {
                if (!this.plugin.round.eventEnabled)
                {
                    ev.Player.PersonalBroadcast(40, "<color=#ce4d4dff>Добро пожаловать на сервер Zone 19 staff</color>\r\n<color=#5e80ffff>Присоединяйтесь к нашему Discord серверу</color>", false);
                    ev.Player.Teleport(this.plugin.cameraVectors[this.plugin.random.Next(this.plugin.cameraVectors.Count)]);
                }
                else
                {
                    ev.Player.PersonalBroadcast(120, $"<size=27><color=#ff5500ff>Проголосуйте за вид раунда в консоли(~) с помощью команды \".ev(Номер варианта)\"</color>\r\n<color=red>[1]</color> {this.plugin.round.TypesNames[(int)this.plugin.round.vote[0].roundType]} - {this.plugin.round.vote[0].count} | <color=red>[2]</color> {this.plugin.round.TypesNames[(int)this.plugin.round.vote[1].roundType]} - {this.plugin.round.vote[1].count}\r\n<color=red>[3]</color> {this.plugin.round.TypesNames[(int)this.plugin.round.vote[2].roundType]} - {this.plugin.round.vote[2].count} | <color=red>[4]</color> {this.plugin.round.TypesNames[(int)this.plugin.round.vote[3].roundType]} - {this.plugin.round.vote[3].count}</size>", false);
                    ev.Player.Teleport(this.plugin.cameraVectors[this.plugin.random.Next(this.plugin.cameraVectors.Count)]);
                }
            }

            if (this.plugin.winnersId.BATTLE_ROYALE == ev.Player.SteamId)
            { 
                ev.Player.SetRank("red", "Победитель битвы");
            }
            else if (this.plugin.winnersId.BOMBARDMENT == ev.Player.SteamId)
            {
                ev.Player.SetRank("red", "Выжил при бомбардировке");
            }

            if (this.plugin.round.eventEnabled && this.plugin.round.playing)
            {
                ev.Player.OverwatchMode = true;
            }
        }
    }
}
