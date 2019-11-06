using Smod2;
using Smod2.Commands;
using Smod2.API;

using System;
using System.IO;

namespace OPlugin.Commands
{
    public class RoomTp : ICommandHandler
    {
        OPlugin plugin;
        public RoomTp(OPlugin plugin)
        {
            this.plugin = plugin;
        }

        public string GetCommandDescription()
        {
            return "Teleport to room";
        }

        public string GetUsage()
        {
            return "(PLAYERD) (ROOMID)";
        }

        public string[] OnCall(ICommandSender sender, string[] args)
        {
            if (args.Length < 1)
            {
                return new[] { "No player id" };
            }

            if (args.Length < 2)
            {
                return new[] { "No room id" };
            }

            Player player = this.plugin.PluginManager.Server.GetPlayer(Convert.ToInt32(args[0]));

            if (player == null)
            {
                return new[] { "No player detected" };
            }

            Room[] rooms = this.plugin.PluginManager.Server.Map.Get079InteractionRooms(Scp079InteractionType.CAMERA);
            
            for (int i = 0; i < rooms.Length; i++)
            {
                if (rooms[i].RoomType == (RoomType)(Convert.ToInt32(args[1])))
                {
                    player.Teleport(rooms[i].Position);
                    return new[] { "Teleported", $"{rooms[i].Forward}" };
                }
            }

            return new[] { "Room not found" };
        }
    }
}
