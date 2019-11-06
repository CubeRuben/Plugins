using Smod2;
using Smod2.Commands;
using Smod2.API;

using System;
using System.IO;

namespace OPlugin.Commands
{
    public class UnFroze : ICommandHandler
    {
        OPlugin plugin;
        public UnFroze(OPlugin plugin)
        {
            this.plugin = plugin;
        }

        public string GetCommandDescription()
        {
            return "Unfreze player";
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

            for (int i = 0; i < this.plugin.frozedPlayers.Count; i++)
            {
                if (this.plugin.frozedPlayers[i].id == player.PlayerId)
                {
                    this.plugin.frozedPlayers.Remove(this.plugin.frozedPlayers[i]);
                    return new[] { "Player unfrezed" };
                }
            }

            return new[] { "Player not founded" };
        }

    }
}
