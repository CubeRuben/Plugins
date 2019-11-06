using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.API;

using System.Collections.Generic;

namespace PPlugin.EventHandlers
{
    class CallCommand : IEventHandlerCallCommand
    {
        PPlugin plugin;

        public CallCommand(PPlugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnCallCommand(PlayerCallCommandEvent ev)
        {
            if (this.plugin.round.eventEnabled && this.plugin.waitingForPlayers)
            {
                for (int i = 0; i < this.plugin.round.votedPlayers.Count; i++)
                {
                    if (this.plugin.round.votedPlayers[i] == ev.Player.PlayerId)
                    {
                        ev.ReturnMessage = "Вы уже проголосовали";
                        goto voted;
                    }
                }

                List<Player> players = this.plugin.PluginManager.Server.GetPlayers();

                switch (ev.Command)
                {
                    case "ev1":
                        ev.ReturnMessage = "Вы проголосовали за первое";
                        this.plugin.round.vote[0].count++;
                        this.plugin.round.votedPlayers.Add(ev.Player.PlayerId);

                        for (int i = 0; i < players.Count; i++)
                        {
                            players[i].PersonalClearBroadcasts();
                            players[i].PersonalBroadcast(120, $"<size=27><color=#ff5500ff>Проголосуйте за вид раунда в консоли(~) с помощью команды \".ev(Номер варианта)\"</color>\r\n<color=red>[1]</color> {this.plugin.round.TypesNames[(int)this.plugin.round.vote[0].roundType]} - {this.plugin.round.vote[0].count} | <color=red>[2]</color> {this.plugin.round.TypesNames[(int)this.plugin.round.vote[1].roundType]} - {this.plugin.round.vote[1].count}\r\n<color=red>[3]</color> {this.plugin.round.TypesNames[(int)this.plugin.round.vote[2].roundType]} - {this.plugin.round.vote[2].count} | <color=red>[4]</color> {this.plugin.round.TypesNames[(int)this.plugin.round.vote[3].roundType]} - {this.plugin.round.vote[3].count}</size>", false);
                        }
                        break;
                    case "ev2":
                        ev.ReturnMessage = "Вы проголосовали за второе";
                        this.plugin.round.vote[1].count++;
                        this.plugin.round.votedPlayers.Add(ev.Player.PlayerId);

                        for (int i = 0; i < players.Count; i++)
                        {
                            players[i].PersonalClearBroadcasts();
                            players[i].PersonalBroadcast(120, $"<size=27><color=#ff5500ff>Проголосуйте за вид раунда в консоли(~) с помощью команды \".ev(Номер варианта)\"</color>\r\n<color=red>[1]</color> {this.plugin.round.TypesNames[(int)this.plugin.round.vote[0].roundType]} - {this.plugin.round.vote[0].count} | <color=red>[2]</color> {this.plugin.round.TypesNames[(int)this.plugin.round.vote[1].roundType]} - {this.plugin.round.vote[1].count}\r\n<color=red>[3]</color> {this.plugin.round.TypesNames[(int)this.plugin.round.vote[2].roundType]} - {this.plugin.round.vote[2].count} | <color=red>[4]</color> {this.plugin.round.TypesNames[(int)this.plugin.round.vote[3].roundType]} - {this.plugin.round.vote[3].count}</size>", false);
                        }
                        break;
                    case "ev3":
                        ev.ReturnMessage = "Вы проголосовали за третье";
                        this.plugin.round.vote[2].count++;
                        this.plugin.round.votedPlayers.Add(ev.Player.PlayerId);

                        for (int i = 0; i < players.Count; i++)
                        {
                            players[i].PersonalClearBroadcasts();
                            players[i].PersonalBroadcast(120, $"<size=27><color=#ff5500ff>Проголосуйте за вид раунда в консоли(~) с помощью команды \".ev(Номер варианта)\"</color>\r\n<color=red>[1]</color> {this.plugin.round.TypesNames[(int)this.plugin.round.vote[0].roundType]} - {this.plugin.round.vote[0].count} | <color=red>[2]</color> {this.plugin.round.TypesNames[(int)this.plugin.round.vote[1].roundType]} - {this.plugin.round.vote[1].count}\r\n<color=red>[3]</color> {this.plugin.round.TypesNames[(int)this.plugin.round.vote[2].roundType]} - {this.plugin.round.vote[2].count} | <color=red>[4]</color> {this.plugin.round.TypesNames[(int)this.plugin.round.vote[3].roundType]} - {this.plugin.round.vote[3].count}</size>", false);
                        }
                        break;
                    case "ev4":
                        ev.ReturnMessage = "Вы проголосовали за четвёртое";
                        this.plugin.round.vote[3].count++;
                        this.plugin.round.votedPlayers.Add(ev.Player.PlayerId);

                        for (int i = 0; i < players.Count; i++)
                        {
                            players[i].PersonalClearBroadcasts();
                            players[i].PersonalBroadcast(120, $"<size=27><color=#ff5500ff>Проголосуйте за вид раунда в консоли(~) с помощью команды \".ev(Номер варианта)\"</color>\r\n<color=red>[1]</color> {this.plugin.round.TypesNames[(int)this.plugin.round.vote[0].roundType]} - {this.plugin.round.vote[0].count} | <color=red>[2]</color> {this.plugin.round.TypesNames[(int)this.plugin.round.vote[1].roundType]} - {this.plugin.round.vote[1].count}\r\n<color=red>[3]</color> {this.plugin.round.TypesNames[(int)this.plugin.round.vote[2].roundType]} - {this.plugin.round.vote[2].count} | <color=red>[4]</color> {this.plugin.round.TypesNames[(int)this.plugin.round.vote[3].roundType]} - {this.plugin.round.vote[3].count}</size>", false);
                        }
                        break;
                }
            }
        voted:;
        }
    }
}
