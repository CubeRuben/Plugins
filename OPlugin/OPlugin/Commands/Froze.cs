using Smod2;
using Smod2.Commands;
using Smod2.API;

using System;
using System.IO;

namespace OPlugin.Commands
{
    public class Froze : ICommandHandler
    {
        OPlugin plugin;
        public Froze(OPlugin plugin)
        {
            this.plugin = plugin;
        }

        public string GetCommandDescription()
        {
            return "Stoping player";
        }

        public string GetUsage()
        {
            return "(PLAYERID)";
        }

        public string[] OnCall(ICommandSender sender, string[] args)
        {
            if (args.Length < 1)
            {
                return new[] { "No player id" };
            }

            Player player = this.plugin.PluginManager.Server.GetPlayer(Convert.ToInt32(args[0]));

            if (player == null)
            {
                return new[] { "Player no detected" };
            }

            this.plugin.frozedPlayers.Add(new FrozedPlayer(player.PlayerId, player.GetPosition()));

            return new[] { "Player stoped" };
        }

    }
}
