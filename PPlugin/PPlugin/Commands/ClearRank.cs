using Smod2;
using Smod2.Commands;
using Smod2.API;

namespace PPlugin.Commands
{
    class ClearRank : ICommandHandler
    {
        PPlugin plugin;
        public ClearRank(PPlugin plugin)
        {
            this.plugin = plugin;
        }

        public string GetCommandDescription()
        {
            return "Clear rank of player";
        }

        public string GetUsage()
        {
            return "(PLAYERID)";
        }

        public string[] OnCall(ICommandSender sender, string[] args)
        {
            if (args.Length < 1)
            {
                return new[] { "No playerId" };
            }

            Player target_player;

            target_player = PluginManager.Manager.Server.GetPlayer(System.Convert.ToInt32(args[0]));

            if (target_player == null)
            {
                return new[] { "No player" };
            }

            target_player.SetRank("", "");

            return new[] { $"Rank of player {args[0]} clear and removed from team kill list" };
        }
    }
}
