using Smod2;
using Smod2.Attributes;
using Smod2.API;
using Smod2.EventHandlers;

using UnityEngine;
using UnityEngine.Networking;


using System;
using System.Collections.Generic;

namespace RPPlugin
{
    [PluginDetails(author = "CubeRuben", name = "RPPlugin", description = "Role Play Plugin", id = "cuberuben.rpplugin", configPrefix = "rpp", langFile = "RPPlugin", version = "1.0", SmodMajor = 3, SmodMinor = 4, SmodRevision = 0)]
    public class RPPlugin : Plugin
    {
        //public int SCP106CanTeleportToPlayer = 0;

        //Счётчик тиков для для FixedUpdate
        public int tick = 0;

        //Массив имён для игроков
        public readonly string[] playersNames = { "Иванов",  "Смирнов", "Кузнецов", "Попов", "Васильев", "Петров", "Соколов", "Михайлов", "Новиков", "Федоров", "Морозов", "Волков", "Алексеев", "Лебедев", "Семенов", "Егоров", "Павлов", "Козлов", "Степанов", "Николаев", "Орлов", "Андреев", "Макаронов", "Никитин", "Захаров", "Зайцев", "Соловьев", "Борисов", "Яковлев", "Григорьев", "Романов", "Воробьев", "Сергеев", "Кузьмин", "Фролов", "Александров", "Дмитриев", "Королев", "Гусёв", "Киселев", "Ильин", "Максимов", "Поляков", "Сорокин", "Виноградов", "Ковалёв", "Белов", "Медведев", "Антонов", "Тарасов" };

        //Объект рандома
        public System.Random random = new System.Random();

        //Массив заблокированных лифтов
        public ElevatorsLockdown elevatorsLockdown = new ElevatorsLockdown();

        //public Item itemForRequestOfMtf;

        //Комната деда
        public Room scp106Room;

        //Положение зоны вызова МОГа в интеркоме
        public Vector intercom;

        //Для спавна МОГа
        public bool allowRespawnMTF = false;

        //Массив игроков, которые признаны на уничтожение
        public List<int> idPlayersForTermination = new List<int>();

        //Массив игроков с кровотечением
        public List<int> bleedingPlayers = new List<int>();

        //Массив игроков с гниением
        public List<int> rottingPlayers = new List<int>();

        //Поднятые трупы
        public List<PickedUpRagdoll> pickedUpRagdolls = new List<PickedUpRagdoll>();

        //IronBlyat
        public IronBlyat ironBlyat = new IronBlyat();

        public override void OnEnable()
        {
            this.Info($"{this.Details.name} has loaded");
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

        //Метод регистрации Handler-ов
        void RegEventHandlers()
        {
            this.AddEventHandler(typeof(IEventHandlerCallCommand), new EventHandlers.CallCommand(this));

            this.AddEventHandler(typeof(IEventHandlerElevatorUse), new EventHandlers.ElevatorUse(this));

            this.AddEventHandler(typeof(IEventHandlerFixedUpdate), new EventHandlers.FixedUpdate(this));

            this.AddEventHandler(typeof(IEventHandlerMedkitUse), new EventHandlers.MedkitUse(this));

            this.AddEventHandler(typeof(IEventHandlerNicknameSet), new EventHandlers.NicknameSet(this));

            this.AddEventHandler(typeof(IEventHandler106CreatePortal), new EventHandlers.Player106CreatePortal(this));

            this.AddEventHandler(typeof(IEventHandlerCheckEscape), new EventHandlers.PlayerCheckEscape(this));

            this.AddEventHandler(typeof(IEventHandlerPlayerDie), new EventHandlers.PlayerDie(this));

            this.AddEventHandler(typeof(IEventHandlerPlayerHurt), new EventHandlers.PlayerHurt(this));

            this.AddEventHandler(typeof(IEventHandlerPlayerPickupItem), new EventHandlers.PlayerPickupItem(this));

            this.AddEventHandler(typeof(IEventHandlerRoundRestart), new EventHandlers.RoundRestart(this));

            this.AddEventHandler(typeof(IEventHandlerRoundStart), new EventHandlers.RoundStart(this));

            this.AddEventHandler(typeof(IEventHandlerSceneChanged), new EventHandlers.SceneChanged(this));

            this.AddEventHandler(typeof(IEventHandlerSetRole), new EventHandlers.SetRole(this));

            this.AddEventHandler(typeof(IEventHandlerSetServerName), new EventHandlers.SetServerName(this));

            this.AddEventHandler(typeof(IEventHandlerSummonVehicle), new EventHandlers.SummonVehicle(this));

            this.AddEventHandler(typeof(IEventHandlerWaitingForPlayers), new EventHandlers.WaitingForPlayers(this));

            this.AddEventHandler(typeof(IEventHandlerWarheadChangeLever), new EventHandlers.WarheadChangeLever(this));

            //this.AddEventHandler(typeof(IEventHandlerBan), new EventHandlers.Ban(this));
        }

        //Метод регистрации комманд
        void RegCommands()
        {
            //this.AddCommand("SKIPEVENT", new Commands.SkipEvent(this));
        }

        
    }

    //Класс с фуекциями
    class Func
    {
        public static bool RotVec(Vector a, Vector b)
        {
            if ((Convert.ToInt32(a.x) == Convert.ToInt32(b.x)) && (Convert.ToInt32(a.y) == Convert.ToInt32(b.y)) && (Convert.ToInt32(a.z) == Convert.ToInt32(b.z)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
   
    //Класс лифтов
    public class ElevatorsLockdown
    {
        public bool elevatorA;
        public bool elevatorB;
        public DateTime timeOfReset;
        public ElevatorsLockdown()
        {
            elevatorA = false;
            elevatorB = false;
        }
    }

    //Класс с трупом и игроком, который несёт труп
    public class PickedUpRagdoll
    {
        public PickedUpRagdoll(int pid, Ragdoll rid)
        {
            this.playerId = pid;
            this.ragdoll = rid;
        }

        public int playerId;
        public Ragdoll ragdoll;
    }

    public class IronBlyat
    {
        public GameObject ironBlyat;

        public void Create(Vector3 position, RPPlugin plugin)
        {
            ironBlyat = GameObject.Instantiate(GameObject.CreatePrimitive(PrimitiveType.Capsule), position, Quaternion.Euler(0, 0, 0));
            //ironBlyat.AddComponent<Scripts.IronBlyat>();
            //ironBlyat.AddComponent<Rigidbody>();
            NetworkServer.Spawn(ironBlyat);
            Pickup[] items = GameObject.FindObjectsOfType<Pickup>();

            Pickup p90 = null;
            Pickup flashbang = null;
            Pickup mp7 = null;
            Pickup ep11 = null;
            Pickup usp = null;
            Pickup com15 = null;

            for (int i = 0; i < items.Length; i++)
            {
                switch (items[i].info.itemId)
                {
                    case (int)ItemType.P90:
                        if (p90 == null)
                        {
                            p90 = items[i];
                        }
                        break;
                    case (int)ItemType.FLASHBANG:
                        if (flashbang == null)
                        {
                            flashbang = items[i];
                        }
                        break;
                    case (int)ItemType.MP4:
                        if (mp7 == null)
                        {
                            mp7 = items[i];
                        }
                        break;
                    case (int)ItemType.E11_STANDARD_RIFLE:
                        if (ep11 == null)
                        {
                            ep11 = items[i];
                        }
                        break;
                    case (int)ItemType.USP:
                        if (usp == null)
                        {
                            usp = items[i];
                        }
                        break;
                    case (int)ItemType.COM15:
                        if (com15 == null)
                        {
                            com15 = items[i];
                        }
                        break;
                }
            }

            /*for (int i = 0; i < 100; i++)
            {
                NetworkServer.Spawn(flashbang.gameObject);
            }*/
           
            SetTransformAndParent(ep11, new Vector3(0, 0, 0) + position, new Vector3(90, 0, 0), ironBlyat);
        }

        public void Destroy()
        {

        }

        private void SetTransformAndParent(Pickup pickup, Vector3 pos, Vector3 rot, GameObject parent)
        {
            GameObject item = GameObject.Instantiate<GameObject>(pickup.gameObject, pos, Quaternion.Euler(rot), parent.transform);
            item.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            NetworkServer.Spawn(item);
        }
    }

}
