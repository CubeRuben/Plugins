using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.API;

using System.Collections.Generic;

namespace PPlugin.EventHandlers
{
    class WaitingForPlayers : IEventHandlerWaitingForPlayers
    {
        PPlugin plugin;

        public WaitingForPlayers(PPlugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnWaitingForPlayers(WaitingForPlayersEvent ev)
        {
            this.plugin.waitingForPlayers = true;
            this.plugin.round.ended = false;

            if (this.plugin.round.eventEnabled)
            {
                int i, ii, iii;

                this.plugin.round.vote[0].roundType = RoundType.STANDART_ROUND;

                i = this.plugin.random.Next(this.plugin.round.TypesNames.Length - 1) + 1;

                this.plugin.round.vote[1].roundType = (RoundType)i;

                while (true)
                {
                    ii = this.plugin.random.Next(this.plugin.round.TypesNames.Length - 1) + 1;
                    if (i != ii)
                    {
                        this.plugin.round.vote[2].roundType = (RoundType)ii;
                        break;
                    }

                }

                while (true)
                {
                    iii = this.plugin.random.Next(this.plugin.round.TypesNames.Length - 1) + 1;
                    if ((i != iii) && (ii != iii))
                    {
                        this.plugin.round.vote[3].roundType = (RoundType)iii;
                        break;
                    }

                }
            }

            Room[] rooms = ev.Server.Map.Get079InteractionRooms(Scp079InteractionType.CAMERA);

            Rooms.ItemSpawn itemSpawnRooms = new Rooms.ItemSpawn();

            Rooms.Camera cameraRooms = new Rooms.Camera();

            //Нахождение комнаты SCP-106
            for (int i = 0; i < rooms.Length; i++)
            {
                if (rooms[i].RoomType == RoomType.SCP_106)
                {
                    this.plugin.scp106Room = rooms[i];
                    break;
                }
            }

            //Раскидывание вещей
            for (int i = 0; i < rooms.Length; i++)
            {
                switch (rooms[i].RoomType)
                {
                    case RoomType.SCP_914:
                        if (itemSpawnRooms.SCP_914)
                        {
                            if (Func.RotVec(rooms[i].Forward, Vector.Forward))
                            {
                                ev.Server.Map.SpawnItem(ItemType.MEDKIT, rooms[i].Position + new Vector(0, 1.5f, -10), new Vector(0, 0, 0));
                                ev.Server.Map.SpawnItem(ItemType.SCIENTIST_KEYCARD, rooms[i].Position + new Vector(0, 2.5f, -10), new Vector(0, 0, 0));
                                ev.Server.Map.SpawnItem(ItemType.JANITOR_KEYCARD, rooms[i].Position + new Vector(6.5f, 1, -8), new Vector(0, 15, 0));
                                ev.Server.Map.SpawnItem(ItemType.COIN, rooms[i].Position + new Vector(6.5f, 1, -8), new Vector(0, 15, 0));
                            }
                            else if (Func.RotVec(rooms[i].Forward, Vector.Right))
                            {
                                ev.Server.Map.SpawnItem(ItemType.MEDKIT, rooms[i].Position + new Vector(-10, 1.5f, 0), new Vector(0, 90, 0));
                                ev.Server.Map.SpawnItem(ItemType.SCIENTIST_KEYCARD, rooms[i].Position + new Vector(-10, 2.5f, 0), new Vector(0, 90, 0));
                                ev.Server.Map.SpawnItem(ItemType.JANITOR_KEYCARD, rooms[i].Position + new Vector(-8, 1, -6.5f), new Vector(0, 15, 0));
                                ev.Server.Map.SpawnItem(ItemType.COIN, rooms[i].Position + new Vector(-8, 1, -6.5f), new Vector(0, 15, 0));
                            }
                            else if (Func.RotVec(rooms[i].Forward, Vector.Back))
                            {
                                ev.Server.Map.SpawnItem(ItemType.MEDKIT, rooms[i].Position + new Vector(0, 1.5f, 10), new Vector(0, 0, 0));
                                ev.Server.Map.SpawnItem(ItemType.SCIENTIST_KEYCARD, rooms[i].Position + new Vector(0, 2.5f, 10), new Vector(0, 0, 0));
                                ev.Server.Map.SpawnItem(ItemType.JANITOR_KEYCARD, rooms[i].Position + new Vector(-6.5f, 1, 8), new Vector(0, 15, 0));
                                ev.Server.Map.SpawnItem(ItemType.COIN, rooms[i].Position + new Vector(-6.5f, 1, 8), new Vector(0, 15, 0));
                            }
                            else if (Func.RotVec(rooms[i].Forward, Vector.Left))
                            {
                                ev.Server.Map.SpawnItem(ItemType.MEDKIT, rooms[i].Position + new Vector(10, 1.5f, 0), new Vector(0, 90, 0));
                                ev.Server.Map.SpawnItem(ItemType.SCIENTIST_KEYCARD, rooms[i].Position + new Vector(10, 2.5f, 0), new Vector(0, 90, 0));
                                ev.Server.Map.SpawnItem(ItemType.JANITOR_KEYCARD, rooms[i].Position + new Vector(8, 1, 6.5f), new Vector(0, 15, 0));
                                ev.Server.Map.SpawnItem(ItemType.COIN, rooms[i].Position + new Vector(8, 1, 6.5f), new Vector(0, 15, 0));
                            }
                            else
                            {
                                this.plugin.Info("Error");
                            }
                            itemSpawnRooms.SCP_914 = false;
                        }
                        break;
                    case RoomType.CHECKPOINT_A:
                        if (itemSpawnRooms.CHECKPOINT_A)
                        {
                            if (Func.RotVec(rooms[i].Forward, Vector.Forward))
                            {
                                ev.Server.Map.SpawnItem(ItemType.JANITOR_KEYCARD, rooms[i].Position + new Vector(0.75f, 2, 5), new Vector(0, 0, 0));
                                ev.Server.Map.SpawnItem(ItemType.COIN, rooms[i].Position + new Vector(0.78f, 2.1f, 5), new Vector(0, 0, 0));
                            }
                            else if (Func.RotVec(rooms[i].Forward, Vector.Right))
                            {
                                ev.Server.Map.SpawnItem(ItemType.JANITOR_KEYCARD, rooms[i].Position + new Vector(5, 2, -0.75f), new Vector(0, 90, 0));
                                ev.Server.Map.SpawnItem(ItemType.COIN, rooms[i].Position + new Vector(5, 2.1f, -0.78f), new Vector(0, 0, 0));
                            }
                            else if (Func.RotVec(rooms[i].Forward, Vector.Back))
                            {
                                ev.Server.Map.SpawnItem(ItemType.JANITOR_KEYCARD, rooms[i].Position + new Vector(-0.75f, 2, -5), new Vector(0, 0, 0));
                                ev.Server.Map.SpawnItem(ItemType.COIN, rooms[i].Position + new Vector(-0.78f, 2.1f, -5), new Vector(0, 0, 0));
                            }
                            else if (Func.RotVec(rooms[i].Forward, Vector.Left))
                            {
                                ev.Server.Map.SpawnItem(ItemType.JANITOR_KEYCARD, rooms[i].Position + new Vector(-5, 2, 0.75f), new Vector(0, 90, 0));
                                ev.Server.Map.SpawnItem(ItemType.COIN, rooms[i].Position + new Vector(-5, 2.1f, 0.78f), new Vector(0, 0, 0));
                            }
                            else
                            {
                                this.plugin.Info("Error");
                            }
                            itemSpawnRooms.CHECKPOINT_A = false;
                        }
                        break;
                    case RoomType.CHECKPOINT_B:
                        if (itemSpawnRooms.CHECKPOINT_B)
                        {
                            if (Func.RotVec(rooms[i].Forward, Vector.Forward))
                            {
                                ev.Server.Map.SpawnItem(ItemType.SCIENTIST_KEYCARD, rooms[i].Position + new Vector(0.75f, 2, 6), new Vector(0, 90, 0));
                            }
                            else if (Func.RotVec(rooms[i].Forward, Vector.Right))
                            {
                                ev.Server.Map.SpawnItem(ItemType.SCIENTIST_KEYCARD, rooms[i].Position + new Vector(6, 2, -0.75f), new Vector(0, 0, 0));
                            }
                            else if (Func.RotVec(rooms[i].Forward, Vector.Back))
                            {
                                ev.Server.Map.SpawnItem(ItemType.SCIENTIST_KEYCARD, rooms[i].Position + new Vector(-0.75f, 2, -6), new Vector(0, 90, 0));
                            }
                            else if (Func.RotVec(rooms[i].Forward, Vector.Left))
                            {
                                ev.Server.Map.SpawnItem(ItemType.SCIENTIST_KEYCARD, rooms[i].Position + new Vector(-6, 2, 0.75f), new Vector(0, 0, 0));
                            }
                            else
                            {
                                this.plugin.Info("Error");
                            }
                            itemSpawnRooms.CHECKPOINT_B = false;
                        }
                        break;
                    case RoomType.WC00:
                        if (itemSpawnRooms.WC00)
                        {
                            if (Func.RotVec(rooms[i].Forward, Vector.Forward))
                            {
                                ev.Server.Map.SpawnItem(ItemType.COIN, rooms[i].Position + new Vector(7, 2, -8), new Vector(0, 0, 0));
                                ev.Server.Map.SpawnItem(ItemType.COIN, rooms[i].Position + new Vector(7, 2, -8), new Vector(0, 0, 0));
                            }
                            else if (Func.RotVec(rooms[i].Forward, Vector.Right))
                            {
                                ev.Server.Map.SpawnItem(ItemType.COIN, rooms[i].Position + new Vector(-8, 2, -7), new Vector(0, 0, 0));
                                ev.Server.Map.SpawnItem(ItemType.COIN, rooms[i].Position + new Vector(-8, 2, -7), new Vector(0, 0, 0));
                            }
                            else if (Func.RotVec(rooms[i].Forward, Vector.Back))
                            {
                                ev.Server.Map.SpawnItem(ItemType.COIN, rooms[i].Position + new Vector(-7, 2, 8), new Vector(0, 0, 0));
                                ev.Server.Map.SpawnItem(ItemType.COIN, rooms[i].Position + new Vector(-7, 2, 8), new Vector(0, 0, 0));
                            }
                            else if (Func.RotVec(rooms[i].Forward, Vector.Left))
                            {
                                ev.Server.Map.SpawnItem(ItemType.COIN, rooms[i].Position + new Vector(8, 2, 7), new Vector(0, 0, 0));
                                ev.Server.Map.SpawnItem(ItemType.COIN, rooms[i].Position + new Vector(8, 2, 7), new Vector(0, 0, 0));
                            }
                            else
                            {
                                this.plugin.Info("Error");
                            }
                            itemSpawnRooms.WC00 = false;
                        }
                        break;
                    case RoomType.HCZ_ARMORY:
                        if (itemSpawnRooms.HCZ_ARMORY)
                        {
                            if (Func.RotVec(rooms[i].Forward, Vector.Forward))
                            {
                                ev.Server.Map.SpawnItem(ItemType.E11_STANDARD_RIFLE, rooms[i].Position + new Vector(4.58f, 3, 0), new Vector(0, 0, 0));
                                ev.Server.Map.SpawnItem(ItemType.WEAPON_MANAGER_TABLET, rooms[i].Position + new Vector(4.58f, 3, 0), new Vector(0, 0, 0));
                            }
                            else if (Func.RotVec(rooms[i].Forward, Vector.Right))
                            {
                                ev.Server.Map.SpawnItem(ItemType.E11_STANDARD_RIFLE, rooms[i].Position + new Vector(0, 3, -4.58f), new Vector(0, 90, 0));
                                ev.Server.Map.SpawnItem(ItemType.WEAPON_MANAGER_TABLET, rooms[i].Position + new Vector(0, 3, -4.58f), new Vector(0, 90, 0));
                            }
                            else if (Func.RotVec(rooms[i].Forward, Vector.Back))
                            {
                                ev.Server.Map.SpawnItem(ItemType.E11_STANDARD_RIFLE, rooms[i].Position + new Vector(-4.58f, 3, 0), new Vector(0, 0, 0));
                                ev.Server.Map.SpawnItem(ItemType.WEAPON_MANAGER_TABLET, rooms[i].Position + new Vector(-4.58f, 3, 0), new Vector(0, 0, 0));
                            }
                            else if (Func.RotVec(rooms[i].Forward, Vector.Left))
                            {
                                ev.Server.Map.SpawnItem(ItemType.E11_STANDARD_RIFLE, rooms[i].Position + new Vector(0, 3, 4.58f), new Vector(0, 90, 0));
                                ev.Server.Map.SpawnItem(ItemType.WEAPON_MANAGER_TABLET, rooms[i].Position + new Vector(0, 3, 4.58f), new Vector(0, 90, 0));
                            }
                            else
                            {
                                this.plugin.Info("Error");
                            }
                            itemSpawnRooms.HCZ_ARMORY = false;
                        }
                        break;
                    case RoomType.LCZ_ARMORY:
                        if (itemSpawnRooms.LCZ_ARMORY)
                        {
                            if (Func.RotVec(rooms[i].Forward, Vector.Forward))
                            {
                                ev.Server.Map.SpawnItem(ItemType.E11_STANDARD_RIFLE, rooms[i].Position + new Vector(4.44f, 2, 0), new Vector(0, 0, 0));
                                ev.Server.Map.SpawnItem(ItemType.DROPPED_5, rooms[i].Position + new Vector(4.44f, 2, 0), new Vector(0, 0, 0));
                                ev.Server.Map.SpawnItem(ItemType.DROPPED_5, rooms[i].Position + new Vector(4.44f, 2, 0), new Vector(0, 0, 0));
                                ev.Server.Map.SpawnItem(ItemType.RADIO, rooms[i].Position + new Vector(0.35f, 2, 3.47f), new Vector(0, 0, 0));
                                ev.Server.Map.SpawnItem(ItemType.RADIO, rooms[i].Position + new Vector(0.35f, 2, -3.47f), new Vector(0, 0, 0));
                                ev.Server.Map.SpawnItem(ItemType.DISARMER, rooms[i].Position + new Vector(0.35f, 2, -3.47f), new Vector(0, 0, 0));
                            }
                            else if (Func.RotVec(rooms[i].Forward, Vector.Right))
                            {
                                ev.Server.Map.SpawnItem(ItemType.E11_STANDARD_RIFLE, rooms[i].Position + new Vector(0, 2, -4.44f), new Vector(0, 90, 0));
                                ev.Server.Map.SpawnItem(ItemType.DROPPED_5, rooms[i].Position + new Vector(0, 2, -4.44f), new Vector(0, 0, 0));
                                ev.Server.Map.SpawnItem(ItemType.DROPPED_5, rooms[i].Position + new Vector(0, 2, -4.44f), new Vector(0, 0, 0));
                                ev.Server.Map.SpawnItem(ItemType.RADIO, rooms[i].Position + new Vector(3.47f, 2, -0.35f), new Vector(0, 0, 0));
                                ev.Server.Map.SpawnItem(ItemType.RADIO, rooms[i].Position + new Vector(-3.47f, 2, -0.35f), new Vector(0, 0, 0));
                                ev.Server.Map.SpawnItem(ItemType.DISARMER, rooms[i].Position + new Vector(-3.47f, 2, -0.35f), new Vector(0, 0, 0));
                            }
                            else if (Func.RotVec(rooms[i].Forward, Vector.Back))
                            {
                                ev.Server.Map.SpawnItem(ItemType.E11_STANDARD_RIFLE, rooms[i].Position + new Vector(-4.44f, 2, 0), new Vector(0, 0, 0));
                                ev.Server.Map.SpawnItem(ItemType.DROPPED_5, rooms[i].Position + new Vector(-4.44f, 2, 0), new Vector(0, 0, 0));
                                ev.Server.Map.SpawnItem(ItemType.DROPPED_5, rooms[i].Position + new Vector(-4.44f, 2, 0), new Vector(0, 0, 0));
                                ev.Server.Map.SpawnItem(ItemType.RADIO, rooms[i].Position + new Vector(-0.35f, 2, -3.47f), new Vector(0, 0, 0));
                                ev.Server.Map.SpawnItem(ItemType.RADIO, rooms[i].Position + new Vector(-0.35f, 2, 3.47f), new Vector(0, 0, 0));
                                ev.Server.Map.SpawnItem(ItemType.DISARMER, rooms[i].Position + new Vector(-0.35f, 2, 3.47f), new Vector(0, 0, 0));
                            }
                            else if (Func.RotVec(rooms[i].Forward, Vector.Left))
                            {
                                ev.Server.Map.SpawnItem(ItemType.E11_STANDARD_RIFLE, rooms[i].Position + new Vector(0, 2, 4.44f), new Vector(0, 90, 0));
                                ev.Server.Map.SpawnItem(ItemType.DROPPED_5, rooms[i].Position + new Vector(0, 2, 4.44f), new Vector(0, 0, 0));
                                ev.Server.Map.SpawnItem(ItemType.DROPPED_5, rooms[i].Position + new Vector(0, 2, 4.44f), new Vector(0, 0, 0));
                                ev.Server.Map.SpawnItem(ItemType.RADIO, rooms[i].Position + new Vector(-3.47f, 2, 0.357f), new Vector(0, 0, 0));
                                ev.Server.Map.SpawnItem(ItemType.RADIO, rooms[i].Position + new Vector(3.47f, 2, 0.357f), new Vector(0, 0, 0));
                                ev.Server.Map.SpawnItem(ItemType.DISARMER, rooms[i].Position + new Vector(3.47f, 2, 0.357f), new Vector(0, 0, 0));
                            }
                            else
                            {
                                this.plugin.Info("Error");
                            }
                            itemSpawnRooms.LCZ_ARMORY = false;
                        }
                        break;
                    case RoomType.PC_LARGE:
                        if (itemSpawnRooms.PC_LARGE)
                        {
                            if (Func.RotVec(rooms[i].Forward, Vector.Forward))
                            {
                                ev.Server.Map.SpawnItem(ItemType.WEAPON_MANAGER_TABLET, rooms[i].Position + new Vector(9.23f, 6.6f, 8.73f), new Vector(0, 0, 0));
                            }
                            else if (Func.RotVec(rooms[i].Forward, Vector.Right))
                            {
                                ev.Server.Map.SpawnItem(ItemType.WEAPON_MANAGER_TABLET, rooms[i].Position + new Vector(-8.73f, 6.6f, -9.23f), new Vector(0, 0, 0));
                            }
                            else if (Func.RotVec(rooms[i].Forward, Vector.Back))
                            {
                                ev.Server.Map.SpawnItem(ItemType.WEAPON_MANAGER_TABLET, rooms[i].Position + new Vector(-9.23f, 6.6f, -8.73f), new Vector(0, 0, 0));
                            }
                            else if (Func.RotVec(rooms[i].Forward, Vector.Left))
                            {
                                ev.Server.Map.SpawnItem(ItemType.WEAPON_MANAGER_TABLET, rooms[i].Position + new Vector(8.73f, 6.6f, 9.23f), new Vector(0, 0, 0));
                            }
                            else
                            {
                                this.plugin.Info("Error");
                            }
                            itemSpawnRooms.PC_LARGE = false;
                        }
                        break;
                    case RoomType.T_INTERSECTION:
                        if (itemSpawnRooms.T_INTERSECTION)
                        {
                            ev.Server.Map.SpawnItem(ItemType.JANITOR_KEYCARD, rooms[i].Position + new Vector(0, 1, 0), new Vector(0, 0, 0));
                            ev.Server.Map.SpawnItem(ItemType.COIN, rooms[i].Position + new Vector(0, 1, 0), new Vector(0, 0, 0));
                            itemSpawnRooms.T_INTERSECTION = false;
                        }
                        break;
                    case RoomType.X_INTERSECTION:
                        if (itemSpawnRooms.X_INTERSECTION)
                        {
                            ev.Server.Map.SpawnItem(ItemType.SCIENTIST_KEYCARD, rooms[i].Position + new Vector(this.plugin.random.Next(2) - 1, 1, this.plugin.random.Next(2) - 1), new Vector(0, 0, 0));
                            ev.Server.Map.SpawnItem(ItemType.RADIO, rooms[i].Position + new Vector(this.plugin.random.Next(2) - 1, 1, this.plugin.random.Next(2) - 1), new Vector(0, 0, 0));
                            itemSpawnRooms.X_INTERSECTION = false;
                        }
                        break;
                    case RoomType.SCP_012:
                        if (itemSpawnRooms.SCP_012)
                        {
                            if (Func.RotVec(rooms[i].Forward, Vector.Forward))
                            {
                                ev.Server.Map.SpawnItem(ItemType.SCIENTIST_KEYCARD, rooms[i].Position + new Vector(-5.45f, 6, 1.75f), new Vector(0, 0, 0));
                            }
                            else if (Func.RotVec(rooms[i].Forward, Vector.Right))
                            {
                                ev.Server.Map.SpawnItem(ItemType.SCIENTIST_KEYCARD, rooms[i].Position + new Vector(1.75f, 6, 5.45f), new Vector(0, 0, 0));
                            }
                            else if (Func.RotVec(rooms[i].Forward, Vector.Back))
                            {
                                ev.Server.Map.SpawnItem(ItemType.SCIENTIST_KEYCARD, rooms[i].Position + new Vector(5.45f, 6, -1.75f), new Vector(0, 0, 0));
                            }
                            else if (Func.RotVec(rooms[i].Forward, Vector.Left))
                            {
                                ev.Server.Map.SpawnItem(ItemType.SCIENTIST_KEYCARD, rooms[i].Position + new Vector(-1.75f, 6, -5.45f), new Vector(0, 0, 0));
                            }
                            else
                            {
                                this.plugin.Info("Error");
                            }
                            itemSpawnRooms.SCP_012 = false;
                        }
                        break;
                    case RoomType.SCP_106:
                        if (itemSpawnRooms.SCP_106)
                        {
                            if (Func.RotVec(rooms[i].Forward, Vector.Forward))
                            {
                                ev.Server.Map.SpawnItem(ItemType.O5_LEVEL_KEYCARD, rooms[i].Position + new Vector(33.16f, -13, -4.2f), new Vector(0, 45, 0));
                                ev.Server.Map.SpawnItem(ItemType.P90, rooms[i].Position + new Vector(21.32f, -18, -8.91f), new Vector(0, 45, 0));
                                ev.Server.Map.SpawnItem(ItemType.RADIO, rooms[i].Position + new Vector(21.32f, -18, -8.91f), new Vector(0, 45, 0));
                                ev.Server.Map.SpawnItem(ItemType.MEDKIT, rooms[i].Position + new Vector(21.32f, -18, -8.91f), new Vector(0, 45, 0));
                            }
                            else if (Func.RotVec(rooms[i].Forward, Vector.Right))
                            {
                                ev.Server.Map.SpawnItem(ItemType.O5_LEVEL_KEYCARD, rooms[i].Position + new Vector(-4.2f, -13, -33.16f), new Vector(0, 45, 0));
                                ev.Server.Map.SpawnItem(ItemType.P90, rooms[i].Position + new Vector(-8.91f, -18, -21.32f), new Vector(0, 45, 0));
                                ev.Server.Map.SpawnItem(ItemType.RADIO, rooms[i].Position + new Vector(-8.91f, -18, -21.32f), new Vector(0, 45, 0));
                                ev.Server.Map.SpawnItem(ItemType.MEDKIT, rooms[i].Position + new Vector(-8.91f, -18, -21.32f), new Vector(0, 45, 0));
                            }
                            else if (Func.RotVec(rooms[i].Forward, Vector.Back))
                            {
                                ev.Server.Map.SpawnItem(ItemType.O5_LEVEL_KEYCARD, rooms[i].Position + new Vector(-33.16f, -13, 4.2f), new Vector(0, 45, 0));
                                ev.Server.Map.SpawnItem(ItemType.P90, rooms[i].Position + new Vector(-21.32f, -18, 8.91f), new Vector(0, 45, 0));
                                ev.Server.Map.SpawnItem(ItemType.RADIO, rooms[i].Position + new Vector(-21.32f, -18, 8.91f), new Vector(0, 45, 0));
                                ev.Server.Map.SpawnItem(ItemType.MEDKIT, rooms[i].Position + new Vector(-21.32f, -18, 8.91f), new Vector(0, 45, 0));
                            }
                            else if (Func.RotVec(rooms[i].Forward, Vector.Left))
                            {
                                ev.Server.Map.SpawnItem(ItemType.O5_LEVEL_KEYCARD, rooms[i].Position + new Vector(4.2f, -13, 33.16f), new Vector(0, 45, 0));
                                ev.Server.Map.SpawnItem(ItemType.P90, rooms[i].Position + new Vector(8.91f, -18, 21.32f), new Vector(0, 45, 0));
                                ev.Server.Map.SpawnItem(ItemType.RADIO, rooms[i].Position + new Vector(8.91f, -18, 21.32f), new Vector(0, 45, 0));
                                ev.Server.Map.SpawnItem(ItemType.MEDKIT, rooms[i].Position + new Vector(8.91f, -18, 21.32f), new Vector(0, 45, 0));
                            }
                            else
                            {
                                this.plugin.Info("Error");
                            }
                            itemSpawnRooms.SCP_106 = false;
                        }
                        break;
                }
            }

            //Добавление позиций камер
            this.plugin.cameraVectors.Add(new Vector(0, -1999, 0));
            this.plugin.cameraVectors.Add(new Vector(0, 1001, -45));
            this.plugin.cameraVectors.Add(new Vector(185, 994, -80));
            this.plugin.cameraVectors.Add(new Vector(182, 1000, -24));

            //Нахождение и добавление камер
            for (int i = 0; i < rooms.Length; i++)
            {
                switch (rooms[i].RoomType)
                {
                    case RoomType.X_INTERSECTION:
                        switch (rooms[i].ZoneType)
                        {
                            case ZoneType.LCZ:
                                if (cameraRooms.LCZ_X)
                                {
                                    this.plugin.cameraVectors.Add(rooms[i].Position + new Vector(0, 1, 0));
                                    cameraRooms.LCZ_X = false;
                                }
                                break;
                            case ZoneType.HCZ:
                                if (cameraRooms.HCZ_X)
                                {
                                    this.plugin.cameraVectors.Add(rooms[i].Position + new Vector(0, 1, 0));
                                    cameraRooms.HCZ_X = false;
                                }
                                break;
                            case ZoneType.ENTRANCE:
                                if (cameraRooms.ENTRANCE_X)
                                {
                                    this.plugin.cameraVectors.Add(rooms[i].Position + new Vector(0, 1, 0));
                                    cameraRooms.ENTRANCE_X = false;
                                }
                                break;
                        }
                        break;
                    case RoomType.SCP_372:
                        if (cameraRooms.SCP_372)
                        {
                            if (Func.RotVec(rooms[i].Forward, Vector.Left))
                            {
                                this.plugin.cameraVectors.Add(rooms[i].Position + new Vector(0, 1, 0));
                            }
                            cameraRooms.SCP_372 = false;
                        }
                        break;
                    case RoomType.SCP_914:
                        if (cameraRooms.SCP_914)
                        {
                            if (Func.RotVec(rooms[i].Forward, Vector.Left))
                            {
                                this.plugin.cameraVectors.Add(rooms[i].Position + new Vector(0, 1, 0));
                            }
                            cameraRooms.SCP_914 = false;
                        }
                        break;
                    case RoomType.PC_LARGE:
                        if (cameraRooms.PC_LARGE)
                        {
                            this.plugin.cameraVectors.Add(rooms[i].Position + new Vector(0, 1, 0));
                            cameraRooms.PC_LARGE = false;
                        }
                        break;
                    case RoomType.WC00:
                        if (cameraRooms.WC00)
                        {
                            this.plugin.cameraVectors.Add(rooms[i].Position + new Vector(0, 1, 0));
                            cameraRooms.WC00 = false;
                        }
                        break;
                    case RoomType.AIRLOCK_00:
                        if (cameraRooms.AIRLOCK_00)
                        {
                            this.plugin.cameraVectors.Add(rooms[i].Position + new Vector(0, 1, 0));
                            cameraRooms.AIRLOCK_00 = false;
                        }
                        break;
                    case RoomType.CLASS_D_CELLS:
                        if (cameraRooms.CLASS_D_CELLS)
                        {
                            this.plugin.cameraVectors.Add(rooms[i].Position + new Vector(0, 1, 0));
                            cameraRooms.CLASS_D_CELLS = false;
                        }
                        break;
                }
            }

            //Открытие генераторов
            Generator[] generators = ev.Server.Map.GetGenerators();
            generators[this.plugin.random.Next(5)].Unlock();
            generators[this.plugin.random.Next(5)].Unlock();

            List<Door> doors = ev.Server.Map.GetDoors();

            for (int i = 0; i < doors.Count; i++)
            {
                if (doors[i].Name == "")
                {
                    if (this.plugin.random.NextDouble() <= 0.1)
                    {
                        doors[i].Open = true;
                    }
                }
            }

            List<TeslaGate> teslaGates = ev.Server.Map.GetTeslaGates();

            teslaGates[this.plugin.random.Next(teslaGates.Count)].TriggerDistance += 1000;
        }
    }
}
