using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.API;

using System.Collections.Generic;

namespace RPPlugin.EventHandlers
{
    class WaitingForPlayers : IEventHandlerWaitingForPlayers
    {
        RPPlugin plugin;

        public WaitingForPlayers(RPPlugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnWaitingForPlayers(WaitingForPlayersEvent ev)
        {
            Room[] rooms = this.plugin.PluginManager.Server.Map.Get079InteractionRooms(Scp079InteractionType.SPEAKER);

            for (int i = 0; i < rooms.Length; i++)
            {
                if (rooms[i].RoomType == RoomType.SCP_106)
                {
                    this.plugin.scp106Room = rooms[i];
                    break;
                }
            }

            for (int i = 0; i < rooms.Length; i++)
            {
                if (rooms[i].RoomType == RoomType.INTERCOM)
                {
                    if (Func.RotVec(rooms[i].Forward, Vector.Forward))
                    {
                        this.plugin.intercom = rooms[i].Position + new Vector(-5.65f, -6, -5.25f);
                    }
                    else if (Func.RotVec(rooms[i].Forward, Vector.Right))
                    {
                        this.plugin.intercom = rooms[i].Position + new Vector(-5.25f, -6, 5.25f);
                    }
                    else if (Func.RotVec(rooms[i].Forward, Vector.Back))
                    {
                        this.plugin.intercom = rooms[i].Position + new Vector(5.65f, -6, 5.25f);
                    }
                    else if (Func.RotVec(rooms[i].Forward, Vector.Left))
                    {
                        this.plugin.intercom = rooms[i].Position + new Vector(5.25f, -6, -5.65f);
                    }
                    else
                    {
                        this.plugin.Info("Error");
                    }
                    break;
                }
            }

            /*Room[] rooms = this.plugin.PluginManager.Server.Map.Get079InteractionRooms(Scp079InteractionType.SPEAKER);
            Room intercom = rooms[0];

            for (int i = 0; i < rooms.Length; i++)
            {
                if (rooms[i].RoomType == RoomType.INTERCOM)
                {
                    intercom = rooms[i];
                    break;
                }
            }

            this.plugin.PluginManager.Server.Map.SpawnItem(ItemType.WEAPON_MANAGER_TABLET, intercom.Position + new Vector(0, 1, 0), new Vector(0, 0, 0));

            List<Item> items = this.plugin.PluginManager.Server.Map.GetItems(ItemType.WEAPON_MANAGER_TABLET, true);

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].GetPosition() == intercom.Position + new Vector(0, 1, 0))
                {
                    this.plugin.itemForRequestOfMtf = items[i];
                    break;
                }
            }

            this.plugin.itemForRequestOfMtf.SetKinematic(true);
            this.plugin.itemForRequestOfMtf.SetPosition(intercom.Position + new Vector(0, 1, 0));
            this.plugin.Info($"{this.plugin.itemForRequestOfMtf.GetPosition().ToString()}");*/
        }
    }
}
