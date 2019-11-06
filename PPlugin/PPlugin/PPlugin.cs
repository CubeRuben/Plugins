using Smod2;
using Smod2.Attributes;
using Smod2.EventHandlers;
using Smod2.API;

using System;
using System.Collections.Generic;


namespace PPlugin
{
    [PluginDetails( author = "CubeRuben", name = "PrivatePlugin", description = "Private Plugin", id = "cuberuben.plugin", configPrefix = "pp",langFile = "PrivatePlugin", version = "1.0", SmodMajor = 3, SmodMinor = 4, SmodRevision = 0 )]
    public class PPlugin : Plugin
    {
        public Round round = new Round();

        public List<TeamKillPlayer> teamKillPlayers = new List<TeamKillPlayer>();

        public List<Vector> cameraVectors = new List<Vector>();

        public Random random = new Random();

        public Room scp106Room;

        public WinnersId winnersId = new WinnersId();

        public bool waitingForPlayers, broadcastSCPDeath = true, rusNamesEnabled = false;

        public readonly string[] tips = new[] { "Из монеты в <color=red>SCP-914</color> можно сделать карту уборщика",
            "Противникам иногда очень везёт",
            "На КПП могут быть карты доступа",
            "Не закрывайте двери перед <color=red>SCP-173</color>, когда бежите от него",
            "Максимально старайтесь не смотреть на <color=red>SCP-096</color>",
            "Если целиться в противника, то шанс попадания увеличивается",
            "<color=red>SCP-939</color> ускоряется, если по нему стрелять",
            "<color=blue>МОГ</color> или <color=green>Повстанцы Хаоса</color> могут прибыть через 4-6 минут",
            "Избегайте <color=#ff7f00ff>Д-Класс</color>",
            "Выход из <color=#010101ff>Карманного измерения</color> случаен для каждого",
            "Стрелять в голову более эффективно",
            "Избегайте врагов",
            "Рации можно изменить радиус действия",
            "Обязательно смотрите на <color=red>SCP-173</color>",
            "Передвигайтесь шагом при виде <color=red>SCP-939</color>",
            "Иногда оборачиваться - полезно для шеи"
        };

        public readonly string[] rusNames = new[] { "Егор", "Влад", "Слава", "Ярослав", "Гена", "Женя", "Саша", "Артём", "Миша", "Иван", "Игорь", "Данил", "Кирил" };
        public readonly string[] rusSecondNames = new[] { "Петров", "Шумилов", "Смирнов", "Морозов", "Егоров", "Васильев", "Федоров", "Алеексеев", "Илларионов", "Лобанов", "Хохлов", "Ульянов", "Шиянов", "Кофтун", "Афанасьев", "Афонин", "Путин", "Медведев", "Рашидов" };

        public override void OnEnable()
        {
            this.Info($"{this.Details.name} has loaded");

            string battleRoyaleWinner = Files.GetText("battle_royale.txt");

            if (battleRoyaleWinner.Length < 1)
            {
                winnersId.BATTLE_ROYALE = battleRoyaleWinner;
            }

            string bombardmantWinner = Files.GetText("bombardmant.txt");

            if (bombardmantWinner.Length < 1)
            {
                winnersId.BOMBARDMENT = bombardmantWinner;
            }
        }

        public override void OnDisable()
        {
            this.Info($"{this.Details.name} has not loaded");
        }

        public override void Register()
        {
            this.Info($"{this.Details.name} registred");

            RegEventHandlers();

            RegCommands();
        }

        void RegEventHandlers()
        {
            this.AddEventHandler(typeof(IEventHandlerBan), new EventHandlers.Ban(this));

            this.AddEventHandler(typeof(IEventHandlerCallCommand), new EventHandlers.CallCommand(this));

            this.AddEventHandler(typeof(IEventHandlerCheckEscape), new EventHandlers.CheckEscape(this));

            this.AddEventHandler(typeof(IEventHandlerCheckRoundEnd), new EventHandlers.CheckRoundEnd(this));

            this.AddEventHandler(typeof(IEventHandlerDoorAccess), new EventHandlers.DoorAccess(this));

            this.AddEventHandler(typeof(IEventHandlerElevatorUse), new EventHandlers.ElevatorUse(this));

            this.AddEventHandler(typeof(IEventHandlerNicknameSet), new EventHandlers.NicknameSet(this));

            this.AddEventHandler(typeof(IEventHandlerPlayerDie), new EventHandlers.PlayerDie(this));

            this.AddEventHandler(typeof(IEventHandlerPlayerDropItem), new EventHandlers.PlayerDropItem(this));

            this.AddEventHandler(typeof(IEventHandlerPlayerHurt), new EventHandlers.PlayerHurt(this));

            this.AddEventHandler(typeof(IEventHandlerPlayerJoin), new EventHandlers.PlayerJoin(this));

            this.AddEventHandler(typeof(IEventHandlerPlayerPickupItem), new EventHandlers.PlayerPickupItem(this));

            this.AddEventHandler(typeof(IEventHandlerRoundEnd), new EventHandlers.RoundEnd(this));

            this.AddEventHandler(typeof(IEventHandlerRoundRestart), new EventHandlers.RoundRestart(this));

            this.AddEventHandler(typeof(IEventHandlerRoundStart), new EventHandlers.RoundStart(this));

            this.AddEventHandler(typeof(IEventHandlerSCP914ChangeKnob), new EventHandlers.SCP914ChangeKnob(this));

            this.AddEventHandler(typeof(IEventHandlerScpDeathAnnouncement), new EventHandlers.ScpDeathAnnouncement(this));

            this.AddEventHandler(typeof(IEventHandlerSetRole), new EventHandlers.SetRole(this));

            this.AddEventHandler(typeof(IEventHandlerSetServerName), new EventHandlers.SetServerName(this));

            this.AddEventHandler(typeof(IEventHandlerSpawn), new EventHandlers.Spawn(this));

            this.AddEventHandler(typeof(IEventHandlerTeamRespawn), new EventHandlers.TeamRespawn(this));

            this.AddEventHandler(typeof(IEventHandlerThrowGrenade), new EventHandlers.ThrowGrenade(this));

            this.AddEventHandler(typeof(IEventHandlerWaitingForPlayers), new EventHandlers.WaitingForPlayers(this));
        }

        void RegCommands()
        {
            this.AddCommand("SKIPEVENT", new Commands.SkipEvent(this));

            this.AddCommand("SETRANK", new Commands.SetRank(this));

            this.AddCommand("TESLA", new Commands.Tesla(this));

            this.AddCommand("CLEARRANK", new Commands.ClearRank(this));

            this.AddCommand("BROADCASTSCPDEATH", new Commands.BroadcastSCPDeath(this));
        }
    }
}
