using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.API;

namespace PPlugin.EventHandlers
{
    class Spawn : IEventHandlerSpawn
    {
        PPlugin plugin;

        public Spawn(PPlugin plugin)
        {
            this.plugin = plugin;
        }
        
        public void OnSpawn(PlayerSpawnEvent ev)
        {
            ev.Player.PersonalClearBroadcasts();
            if (this.plugin.round.eventEnabled && (this.plugin.round.type != RoundType.STANDART_ROUND))
            {
                string broadcast = $"<b>Сейчас ивент: {this.plugin.round.TypesNames[(int)this.plugin.round.type]}\r\nВаша задача - ";
                switch (this.plugin.round.type)
                {
                    case RoundType.BATTLE_ROYALE:
                        broadcast += "убить весь <color=#ff7f00ff>Д-Класс</color>";
                        break;
                    case RoundType.INFECTION_049_2:
                        switch (ev.Player.TeamRole.Role)
                        {
                            case Role.CLASSD:
                                broadcast += "сбежать из комплекса";
                                break;
                            case Role.CHAOS_INSURGENCY:
                                broadcast += "помочь сбежать <color=#ff7f00ff>Д-Классу</color>";
                                break;
                            case Role.SCP_049_2:
                                broadcast += "заразить всех людей";
                                break;
                        }
                        break;
                    case RoundType.INFECTION_106:
                        switch (ev.Player.TeamRole.Role)
                        {
                            case Role.CLASSD:
                                broadcast += "сбежать из комплекса";
                                break;
                            case Role.CHAOS_INSURGENCY:
                                broadcast += "помочь сбежать <color=#ff7f00ff>Д-Классу</color>";
                                break;
                            case Role.SCP_106:
                                broadcast += "заразить всех людей";
                                break;
                        }
                        break;
                    case RoundType.INFECTION_939:
                        switch (ev.Player.TeamRole.Role)
                        {
                            case Role.CLASSD:
                                broadcast += "сбежать из комплекса";
                                break;
                            case Role.CHAOS_INSURGENCY:
                                broadcast += "помочь сбежать <color=#ff7f00ff>Д-Классу</color>";
                                break;
                            case Role.SCP_939_89:
                                broadcast += "заразить всех людей";
                                break;
                            case Role.SCP_939_53:
                                broadcast += "заразить всех людей";
                                break;
                        }
                        break;
                    case RoundType.INFECTION_173:
                        switch (ev.Player.TeamRole.Role)
                        {
                            case Role.CLASSD:
                                broadcast += "сбежать из комплекса";
                                break;
                            case Role.CHAOS_INSURGENCY:
                                broadcast += "помочь сбежать <color=#ff7f00ff>Д-Классу</color>";
                                break;
                            case Role.SCP_173:
                                broadcast += "заразить всех людей";
                                break;
                        }
                        break;
                    case RoundType.JAIL:
                        switch (ev.Player.TeamRole.Role)
                        {
                            case Role.CLASSD:
                                broadcast += "сбежать из комплекса или выполнять приказы охраны";
                                break;
                            case Role.NTF_COMMANDER:
                                broadcast += "не позволить <color=#ff7f00ff>Д-классу</color> сбежать";
                                break;
                            case Role.FACILITY_GUARD:
                                broadcast += "не позволить <color=#ff7f00ff>Д-классу</color> сбежать";
                                break;
                        }
                        break;
                    case RoundType.MTF_VS_CHAOS:
                        switch (ev.Player.TeamRole.Role)
                        {
                            case Role.CHAOS_INSURGENCY:
                                broadcast += "уничтожить весь <color=blue>МОГ</color>";
                                break;
                            case Role.NTF_COMMANDER:
                                broadcast += "уничтожить всех <color=green>Повстанцев Хаоса</color>";
                                break;
                        }
                        break;
                    case RoundType.HOSTAGES:
                        switch (ev.Player.TeamRole.Role)
                        {
                            case Role.SCIENTIST:
                                broadcast += "сбежать из плена <color=green>Повстанцев Хаоса</color>";
                                break;
                            case Role.NTF_COMMANDER:
                            case Role.NTF_LIEUTENANT:
                                broadcast += "спасти всех ученых из плена <color=green>Повстанцев Хаоса</color>";
                                break;
                            case Role.CHAOS_INSURGENCY:
                                broadcast += "заполучить карту O5 и не дать <color=yellow>Учённым</color> сбежать";
                                break;
                        }
                        break;
                    case RoundType.BOMBARDMENT:
                        switch (ev.Player.TeamRole.Role)
                        {
                            case Role.SCIENTIST:
                                broadcast += "обкидывать <color=#ff7f00ff>Д-Класс</color> гранатами";
                                break;
                            case Role.CLASSD:
                                broadcast += "выжить";
                                break;
                        }

                        if (ev.Player.TeamRole.Role == Role.SCIENTIST)
                        {
                            ev.SpawnPos = this.plugin.scp106Room.Position + new Vector(0, 1, 0);
                        }
                        break;
                }
                broadcast += "</b>";
                ev.Player.PersonalBroadcast(20, broadcast, false);
            }
            else
            {
                ev.Player.PersonalBroadcast(10, $"<b>{this.plugin.tips[this.plugin.random.Next(this.plugin.tips.Length)]}</b>", false);
            }
        }
    }
}
