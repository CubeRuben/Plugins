using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.API;

using System.Collections.Generic;

namespace PPlugin.EventHandlers
{
    class RoundStart : IEventHandlerRoundStart
    {
        PPlugin plugin;

        public RoundStart(PPlugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnRoundStart(RoundStartEvent ev)
        {
            if (this.plugin.round.eventEnabled)
            {
                VoteOfRoundType voteRoundType = new VoteOfRoundType();

                for (int i = 0; i < 4; i++)
                {
                    if (voteRoundType.count < this.plugin.round.vote[i].count)
                    {
                        voteRoundType = this.plugin.round.vote[i];
                    }
                }

                if (voteRoundType.roundType == RoundType.STANDART_ROUND)
                {
                    this.plugin.round.eventEnabled = false;
                }
                this.plugin.round.type = voteRoundType.roundType;
            }

            List<Player> players = ev.Server.GetPlayers();

            Room[] rooms = ev.Server.Map.Get079InteractionRooms(Scp079InteractionType.CAMERA);

            Rooms.RagdollSpawn ragdollRooms = new Rooms.RagdollSpawn();

            Player player = players[0];

            List<Door> doors = this.plugin.PluginManager.Server.Map.GetDoors();

            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].TeamRole.Role == Role.CLASSD)
                {
                    player = players[i];
                    break;
                }
            }

            for (int i = 0; i < rooms.Length; i++)
            {
                switch (rooms[i].RoomType)
                {
                    case RoomType.SCP_173:
                        if (ragdollRooms.SCP_173)
                        {
                            if (Func.RotVec(rooms[i].Forward, Vector.Forward))
                            {
                                player.Teleport(rooms[i].Position + new Vector(21.6f, (float)(17 + this.plugin.random.NextDouble()), 14.1f));
                                Func.ClearAmmo(player);
                                player.Kill(DamageType.SCP_173);
                                player.ChangeRole(Role.CLASSD);
                                player.Teleport(rooms[i].Position + new Vector(18.4f, (float)(17 + this.plugin.random.NextDouble()), 10.8f));
                                Func.ClearAmmo(player);
                                player.Kill(DamageType.SCP_173);
                                player.ChangeRole(Role.CLASSD);
                                player.Teleport(rooms[i].Position + new Vector(19f, (float)(17 + this.plugin.random.NextDouble()), 13.3f));
                                Func.ClearAmmo(player);
                                player.Kill(DamageType.SCP_173);
                                player.ChangeRole(Role.SCIENTIST);
                                player.Teleport(rooms[i].Position + new Vector(10.2f, (float)(21 + this.plugin.random.NextDouble()), 19.8f));
                                Func.ClearAmmo(player);
                                player.Kill(DamageType.SCP_173);
                                player.ChangeRole(Role.SCIENTIST);
                                player.Teleport(rooms[i].Position + new Vector(5.1f, (float)(21 + this.plugin.random.NextDouble()), 2.1f));
                                Func.ClearAmmo(player);
                                player.Kill(DamageType.SCP_173);
                            }
                            else if (Func.RotVec(rooms[i].Forward, Vector.Right))
                            {
                                player.Teleport(rooms[i].Position + new Vector(14.1f, (float)(17 + this.plugin.random.NextDouble()), -21.6f));
                                Func.ClearAmmo(player);
                                player.Kill(DamageType.SCP_173);
                                player.ChangeRole(Role.CLASSD);
                                player.Teleport(rooms[i].Position + new Vector(10.8f, (float)(17 + this.plugin.random.NextDouble()), -18.4f));
                                Func.ClearAmmo(player);
                                player.Kill(DamageType.SCP_173);
                                player.ChangeRole(Role.CLASSD);
                                player.Teleport(rooms[i].Position + new Vector(13.3f, (float)(17 + this.plugin.random.NextDouble()), -19f));
                                Func.ClearAmmo(player);
                                player.Kill(DamageType.SCP_173);
                                player.ChangeRole(Role.SCIENTIST);
                                player.Teleport(rooms[i].Position + new Vector(19.8f, (float)(21 + this.plugin.random.NextDouble()), -10.2f));
                                Func.ClearAmmo(player);
                                player.Kill(DamageType.SCP_173);
                                player.ChangeRole(Role.SCIENTIST);
                                player.Teleport(rooms[i].Position + new Vector(2.1f, (float)(21 + this.plugin.random.NextDouble()), -5.1f));
                                Func.ClearAmmo(player);
                                player.Kill(DamageType.SCP_173);
                            }
                            else if (Func.RotVec(rooms[i].Forward, Vector.Back))
                            {
                                player.Teleport(rooms[i].Position + new Vector(-21.6f, (float)(17 + this.plugin.random.NextDouble()), -14.1f));
                                Func.ClearAmmo(player);
                                player.Kill(DamageType.SCP_173);
                                player.ChangeRole(Role.CLASSD);
                                player.Teleport(rooms[i].Position + new Vector(-18.4f, (float)(17 + this.plugin.random.NextDouble()), -10.8f));
                                Func.ClearAmmo(player);
                                player.Kill(DamageType.SCP_173);
                                player.ChangeRole(Role.CLASSD);
                                player.Teleport(rooms[i].Position + new Vector(-19f, (float)(17 + this.plugin.random.NextDouble()), -13.3f));
                                Func.ClearAmmo(player);
                                player.Kill(DamageType.SCP_173);
                                player.ChangeRole(Role.SCIENTIST);
                                player.Teleport(rooms[i].Position + new Vector(-10.2f, (float)(21 + this.plugin.random.NextDouble()), -19.8f));
                                Func.ClearAmmo(player);
                                player.Kill(DamageType.SCP_173);
                                player.ChangeRole(Role.SCIENTIST);
                                player.Teleport(rooms[i].Position + new Vector(-5.1f, (float)(21 + this.plugin.random.NextDouble()), -2.1f));
                                Func.ClearAmmo(player);
                                player.Kill(DamageType.SCP_173);
                            }
                            else if (Func.RotVec(rooms[i].Forward, Vector.Left))
                            {
                                player.Teleport(rooms[i].Position + new Vector(-14.1f, (float)(17 + this.plugin.random.NextDouble()), 21.6f));
                                Func.ClearAmmo(player);
                                player.Kill(DamageType.SCP_173);
                                player.ChangeRole(Role.CLASSD);
                                player.Teleport(rooms[i].Position + new Vector(-10.8f, (float)(17 + this.plugin.random.NextDouble()), 18.4f));
                                Func.ClearAmmo(player);
                                player.Kill(DamageType.SCP_173);
                                player.ChangeRole(Role.CLASSD);
                                player.Teleport(rooms[i].Position + new Vector(-13.3f, (float)(17 + this.plugin.random.NextDouble()), 19f));
                                Func.ClearAmmo(player);
                                player.Kill(DamageType.SCP_173);
                                player.ChangeRole(Role.SCIENTIST);
                                player.Teleport(rooms[i].Position + new Vector(-19.8f, (float)(21 + this.plugin.random.NextDouble()), 10.2f));
                                Func.ClearAmmo(player);
                                player.Kill(DamageType.SCP_173);
                                player.ChangeRole(Role.SCIENTIST);
                                player.Teleport(rooms[i].Position + new Vector(-2.1f, (float)(21 + this.plugin.random.NextDouble()), 5.1f));
                                Func.ClearAmmo(player);
                                player.Kill(DamageType.SCP_173);
                            }
                            ragdollRooms.SCP_173 = false;
                        }
                        break;
                    case RoomType.SCP_096:
                        if (ragdollRooms.SCP_096)
                        {
                            if (Func.RotVec(rooms[i].Forward, Vector.Forward))
                            {
                                player.ChangeRole(Role.FACILITY_GUARD);
                                player.SetGodmode(false);
                                player.Teleport(rooms[i].Position + new Vector(-1, (float)(2.4 + this.plugin.random.NextDouble()), -1));
                                player.Kill(DamageType.SCP_096);
                                player.ChangeRole(Role.FACILITY_GUARD);
                                player.SetGodmode(false);
                                player.Teleport(rooms[i].Position + new Vector(-2, (float)(2.4 + this.plugin.random.NextDouble()), 1));
                                player.Kill(DamageType.SCP_096);
                            }
                            else if (Func.RotVec(rooms[i].Forward, Vector.Right))
                            {
                                player.ChangeRole(Role.FACILITY_GUARD);
                                player.SetGodmode(false);
                                player.Teleport(rooms[i].Position + new Vector(-1, (float)(2.4 + this.plugin.random.NextDouble()), 1));
                                player.Kill(DamageType.SCP_096);
                                player.ChangeRole(Role.FACILITY_GUARD);
                                player.SetGodmode(false);
                                player.Teleport(rooms[i].Position + new Vector(1, (float)(2.4 + this.plugin.random.NextDouble()), 2));
                                player.Kill(DamageType.SCP_096);
                            }
                            else if (Func.RotVec(rooms[i].Forward, Vector.Back))
                            {
                                player.ChangeRole(Role.FACILITY_GUARD);
                                player.SetGodmode(false);
                                player.Teleport(rooms[i].Position + new Vector(1, (float)(2.4 + this.plugin.random.NextDouble()), 1));
                                player.Kill(DamageType.SCP_096);
                                player.ChangeRole(Role.FACILITY_GUARD);
                                player.SetGodmode(false);
                                player.Teleport(rooms[i].Position + new Vector(2, (float)(2.4 + this.plugin.random.NextDouble()), -1));
                                player.Kill(DamageType.SCP_096);
                            }
                            else if (Func.RotVec(rooms[i].Forward, Vector.Left))
                            {
                                player.ChangeRole(Role.FACILITY_GUARD);
                                player.SetGodmode(false);
                                player.Teleport(rooms[i].Position + new Vector(1, (float)(2.4 + this.plugin.random.NextDouble()), -1));
                                player.Kill(DamageType.SCP_096);
                                player.ChangeRole(Role.FACILITY_GUARD);
                                player.SetGodmode(false);
                                player.Teleport(rooms[i].Position + new Vector(-1, (float)(2.4 + this.plugin.random.NextDouble()), -2));
                                player.Kill(DamageType.SCP_096);
                            }
                            ragdollRooms.SCP_096 = false;
                        }
                        break;
                    case RoomType.SCP_939:
                        if (ragdollRooms.SCP_939)
                        {
                            if (Func.RotVec(rooms[i].Forward, Vector.Forward))
                            {
                                player.ChangeRole(Role.SCIENTIST);
                                Func.ClearAmmo(player);
                                player.Teleport(rooms[i].Position + new Vector(1, (float)(-14 + this.plugin.random.NextDouble()), 0));
                                player.Kill(DamageType.SCP_939);
                                player.ChangeRole(Role.SCIENTIST);
                                Func.ClearAmmo(player);
                                player.Teleport(rooms[i].Position + new Vector(-1, (float)(-14 + this.plugin.random.NextDouble()), 0));
                                player.Kill(DamageType.SCP_939);
                            }
                            else if (Func.RotVec(rooms[i].Forward, Vector.Right))
                            {
                                player.ChangeRole(Role.SCIENTIST);
                                Func.ClearAmmo(player);
                                player.Teleport(rooms[i].Position + new Vector(0, (float)(-14 + this.plugin.random.NextDouble()), 1));
                                player.Kill(DamageType.SCP_939);
                                player.ChangeRole(Role.SCIENTIST);
                                Func.ClearAmmo(player);
                                player.Teleport(rooms[i].Position + new Vector(0, (float)(-14 + this.plugin.random.NextDouble()), -1));
                                player.Kill(DamageType.SCP_939);
                            }
                            else if (Func.RotVec(rooms[i].Forward, Vector.Back))
                            {
                                player.ChangeRole(Role.SCIENTIST);
                                Func.ClearAmmo(player);
                                player.Teleport(rooms[i].Position + new Vector(1, (float)(-14 + this.plugin.random.NextDouble()), 0));
                                player.Kill(DamageType.SCP_939);
                                player.ChangeRole(Role.SCIENTIST);
                                Func.ClearAmmo(player);
                                player.Teleport(rooms[i].Position + new Vector(-1, (float)(-14 + this.plugin.random.NextDouble()), 0));
                                player.Kill(DamageType.SCP_939);
                            }
                            else if (Func.RotVec(rooms[i].Forward, Vector.Left))
                            {
                                player.ChangeRole(Role.SCIENTIST);
                                Func.ClearAmmo(player);
                                player.Teleport(rooms[i].Position + new Vector(0, (float)(-14 + this.plugin.random.NextDouble()), 1));
                                player.Kill(DamageType.SCP_939);
                                player.ChangeRole(Role.SCIENTIST);
                                Func.ClearAmmo(player);
                                player.Teleport(rooms[i].Position + new Vector(0, (float)(-14 + this.plugin.random.NextDouble()), -1));
                                player.Kill(DamageType.SCP_939);
                            }
                            ragdollRooms.SCP_939 = false;
                        }
                        break;
                    case RoomType.SCP_012:
                        if (ragdollRooms.SCP_012)
                        {
                            player.ChangeRole(Role.CLASSD);
                            Func.ClearAmmo(player);
                            player.Teleport(rooms[i].Position + new Vector(0, (float)(-5 + this.plugin.random.NextDouble()), 0));
                            player.Kill(DamageType.NONE);
                            ragdollRooms.SCP_012 = false;
                        }
                        break;
                    case RoomType.TESLA_GATE:
                        if (ragdollRooms.TESLA_GATE)
                        {
                            player.ChangeRole(Role.SCIENTIST);
                            Func.ClearAmmo(player);
                            player.Teleport(rooms[i].Position + new Vector(0, 2, 0));
                            player.Kill(DamageType.TESLA);
                            ragdollRooms.TESLA_GATE = false;
                        }
                        break;
                }
            }

            if (Func.RotVec(this.plugin.scp106Room.Forward, Vector.Forward))
            {
                player.ChangeRole(Role.SCIENTIST);
                Func.ClearAmmo(player);
                player.Teleport(this.plugin.scp106Room.Position + new Vector((float)(24 - this.plugin.random.NextDouble() * 32), 7, this.plugin.random.Next(4) - 2));
                player.Kill(DamageType.SCP_106);
                player.ChangeRole(Role.SCIENTIST);
                Func.ClearAmmo(player);
                player.Teleport(this.plugin.scp106Room.Position + new Vector((float)(24 - this.plugin.random.NextDouble() * 32), 7, this.plugin.random.Next(4) - 2));
                player.Kill(DamageType.SCP_106);
            }
            else if (Func.RotVec(this.plugin.scp106Room.Forward, Vector.Right))
            {
                player.ChangeRole(Role.SCIENTIST);
                Func.ClearAmmo(player);
                player.Teleport(this.plugin.scp106Room.Position + new Vector(this.plugin.random.Next(4) - 2, 7, (float)(-24 + this.plugin.random.NextDouble() * 32)));
                player.Kill(DamageType.SCP_106);
                player.ChangeRole(Role.SCIENTIST);
                Func.ClearAmmo(player);
                player.Teleport(this.plugin.scp106Room.Position + new Vector(this.plugin.random.Next(4) - 2, 7, (float)(-24 + this.plugin.random.NextDouble() * 32)));
                player.Kill(DamageType.SCP_106);
            }
            else if (Func.RotVec(this.plugin.scp106Room.Forward, Vector.Back))
            {
                player.ChangeRole(Role.SCIENTIST);
                Func.ClearAmmo(player);
                player.Teleport(this.plugin.scp106Room.Position + new Vector((float)(-24 + this.plugin.random.NextDouble() * 32), 7, this.plugin.random.Next(4) - 2));
                player.Kill(DamageType.SCP_106);
                player.ChangeRole(Role.SCIENTIST);
                Func.ClearAmmo(player);
                player.Teleport(this.plugin.scp106Room.Position + new Vector((float)(-24 + this.plugin.random.NextDouble() * 32), 7, this.plugin.random.Next(4) - 2));
                player.Kill(DamageType.SCP_106);
            }
            else if (Func.RotVec(this.plugin.scp106Room.Forward, Vector.Left))
            {
                player.ChangeRole(Role.SCIENTIST);
                Func.ClearAmmo(player);
                player.Teleport(this.plugin.scp106Room.Position + new Vector(this.plugin.random.Next(4) - 2, 7, (float)(24 - this.plugin.random.NextDouble() * 32)));
                player.Kill(DamageType.SCP_106);
                player.ChangeRole(Role.SCIENTIST);
                Func.ClearAmmo(player);
                player.Teleport(this.plugin.scp106Room.Position + new Vector(this.plugin.random.Next(4) - 2, 7, (float)(24 - this.plugin.random.NextDouble() * 32)));
                player.Kill(DamageType.SCP_106);
            }

            player.ChangeRole(Role.CLASSD);

            ev.Server.Map.AnnounceCustomMessage($"SCP pitch_0,5 {this.plugin.random.Next(10)} pitch_1,5 {this.plugin.random.Next(10)} pitch_0,5 {this.plugin.random.Next(10)} pitch_1 CONTAINMENT BREACH DETECTED IN FACILITY");

            //Окончание ожидания игроков
            this.plugin.waitingForPlayers = false;
            this.plugin.round.playing = true;

            if (this.plugin.round.eventEnabled && (this.plugin.round.type != RoundType.STANDART_ROUND))
            {
                List<TeslaGate> teslas = this.plugin.PluginManager.Server.Map.GetTeslaGates();

                for (int i = 0; i < teslas.Count; i++)
                {
                    teslas[i].TriggerDistance = 0;
                }
                
                for (int i = 0; i < players.Count; i++)
                {
                    players[i].ChangeRole(Role.CLASSD);
                }

                int temp = this.plugin.random.Next(players.Count);

                switch (this.plugin.round.type)
                {
                    case RoundType.INFECTION_173:
                        players[temp].ChangeRole(Role.SCP_173);
                        break;
                    case RoundType.INFECTION_106:
                        players[temp].ChangeRole(Role.SCP_106);
                        break;
                    case RoundType.INFECTION_049_2:
                        players[temp].ChangeRole(Role.SCP_049_2);
                        players[temp].Teleport(this.plugin.scp106Room.Position + new Vector(0, 1, 0));
                        break;
                    case RoundType.INFECTION_939:
                        players[temp].ChangeRole(Role.SCP_939_53);
                        break;
                    case RoundType.JAIL:
                        Room room = rooms[0];

                        for (int i = 0; i < rooms.Length; i++)
                        {
                            if (rooms[i].RoomType == RoomType.CLASS_D_CELLS)
                            {
                                room = rooms[i];
                                break;
                            }
                        }

                        int tjail = this.plugin.random.Next(players.Count);
                        players[tjail].ChangeRole(Role.NTF_COMMANDER);
                        players[tjail].Teleport(room.Position + new Vector(0, 1, 0));
                        if (this.plugin.PluginManager.Server.NumPlayers > 5)
                        {
                            int ttjail;
                            while (true)
                            {
                                ttjail = this.plugin.random.Next(players.Count);
                                if (tjail != ttjail)
                                {
                                    players[ttjail].ChangeRole(Role.FACILITY_GUARD);
                                    players[ttjail].Teleport(room.Position + new Vector(0, 1, 0));
                                    break;
                                }
                            }

                            while (true)
                            {
                                int tttjail = this.plugin.random.Next(players.Count);
                                if ((tjail != tttjail) && (tjail != ttjail))
                                {
                                    players[tttjail].ChangeRole(Role.FACILITY_GUARD);
                                    players[tttjail].Teleport(room.Position + new Vector(0, 1, 0));
                                    break;
                                }
                            }
                        }
                        break;
                    case RoundType.MTF_VS_CHAOS:
                        for (int i = 0; i < doors.Count; i++)
                        {
                            if (doors[i].Name == "SURFACE_GATE")
                            {
                                doors[i].LockCooldown = 120;
                                break;
                            }
                        }

                        for (int i = 0; i < players.Count; i++)
                        {
                            if (i % 2 == 0)
                            {
                                players[i].ChangeRole(Role.CHAOS_INSURGENCY);
                            }
                            else
                            {
                                players[i].ChangeRole(Role.NTF_COMMANDER);
                            }
                        }
                        break;
                    case RoundType.BATTLE_ROYALE:
                        break;
                    case RoundType.HOSTAGES:
                        Room room1 = rooms[0];

                        for (int i = 0; i < rooms.Length; i++)
                        {
                            if (rooms[i].RoomType == RoomType.CLASS_D_CELLS)
                            {
                                room1 = rooms[i];
                                break;
                            }
                        }

                        for (int i = 0; i < players.Count; i++)
                        {
                            switch (i)
                            {
                                case 0:
                                    players[i].ChangeRole(Role.SCIENTIST);
                                    players[i].Teleport(room1.Position + new Vector(0, 1, 0));
                                    List<Item> itemsBombFirst = players[i].GetInventory();
                                    for (int b = 0; b < itemsBombFirst.Count; b++)
                                    {
                                        itemsBombFirst[b].Remove();
                                    }
                                    break;
                                case 1:
                                    players[i].ChangeRole(Role.CHAOS_INSURGENCY);
                                    players[i].Teleport(room1.Position + new Vector(0, 1, 0));
                                    break;
                                case 2:
                                    players[i].ChangeRole(Role.NTF_COMMANDER);
                                    players[i].GetInventory()[0].Remove();
                                    players[i].GiveItem(ItemType.O5_LEVEL_KEYCARD);
                                    break;
                                case 3:
                                    players[i].ChangeRole(Role.CHAOS_INSURGENCY);
                                    players[i].Teleport(room1.Position + new Vector(0, 1, 0));
                                    break;
                                case 4:
                                    players[i].ChangeRole(Role.SCIENTIST);
                                    players[i].Teleport(room1.Position + new Vector(0, 1, 0));
                                    List<Item> itemsBombSecond = players[i].GetInventory();
                                    for (int b = 0; b < itemsBombSecond.Count; b++)
                                    {
                                        itemsBombSecond[b].Remove();
                                    }
                                    break;
                                case 5:
                                    players[i].ChangeRole(Role.NTF_COMMANDER);
                                    break;
                            }

                            if (i > 5)
                            {
                                if (System.Convert.ToBoolean(i % 2))
                                {
                                    players[i].ChangeRole(Role.CHAOS_INSURGENCY);
                                    players[i].Teleport(room1.Position + new Vector(0, 1, 0));
                                }
                                else
                                {
                                    players[i].ChangeRole(Role.NTF_LIEUTENANT);
                                }
                            }
                        }
                        break;
                    case RoundType.BOMBARDMENT:
                        List<Vector> spawn = this.plugin.PluginManager.Server.Map.GetSpawnPoints(Role.SCP_106);

                        for (int i = 0; i < players.Count; i++)
                        {
                            players[i].Teleport(spawn[this.plugin.random.Next(spawn.Count)]);
                        }

                        int a = this.plugin.random.Next(players.Count);
                        players[a].ChangeRole(Role.SCIENTIST, true, false, false);
                        players[a].Teleport(this.plugin.scp106Room.Position + new Vector(0, 1, 0));
                        List<Item> items = players[a].GetInventory();
                        for (int i = 0; i < items.Count; i++)
                        {
                            items[i].Remove();
                        }
                        players[a].GiveItem(ItemType.FRAG_GRENADE);

                        for (int i = 0; i < doors.Count; i++)
                        {
                            doors[i].Locked = true;
                        }
                        break;
                }
            }
        }
    }
}
