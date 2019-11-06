using Smod2;
using Smod2.Commands;
using Smod2.API;

using System;

namespace PPlugin.Commands
{
    class SetRank : ICommandHandler
    {
        PPlugin plugin;
        public SetRank(PPlugin plugin)
        {
            this.plugin = plugin;
        }

        public string GetCommandDescription()
        {
            return "Set rank of player";
        }
        public string GetUsage()
        {
            return "(PLAYERID) (COLOR) (RANKNAME)";
        }
        public string[] OnCall(ICommandSender sender, string[] args)
        {
            if (args.Length < 1)
            {
                return new[] { "No player ID" };
            }

            if (args.Length < 2)
            {
                return new[] { "No rankname" };
            }

            if (args.Length < 3)
            {
                return new[] { "No rankname" };
            }

            string color = args[1];
            string rank = "";
            Player target_player = this.plugin.PluginManager.Server.GetPlayer(Convert.ToInt32(args[0]));

            for (int i = 2; i < args.Length; i++)
            {
                rank += args[i] + " ";
            }

            target_player.SetRank(color, rank);

            return new[] { "Rank seted" };
        }
    }
}
