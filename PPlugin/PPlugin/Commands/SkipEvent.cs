using Smod2;
using Smod2.Commands;
using Smod2.API;

using System.Collections.Generic;

namespace PPlugin.Commands
{
    class SkipEvent : ICommandHandler
    {
        PPlugin plugin;
        public SkipEvent(PPlugin plugin)
        {
            this.plugin = plugin;
        }

        public string GetCommandDescription()
        {
            return "Skip event";
        }

        public string GetUsage()
        {
            return "Nothing here";
        }

        public string[] OnCall(ICommandSender sender, string[] args)
        {
            this.plugin.round.eventEnabled = false;
            this.plugin.round.Clear();

            List<Player> players = this.plugin.PluginManager.Server.GetPlayers();

            for (int i = 0; i < players.Count; i++)
            {
                players[i].PersonalClearBroadcasts();
            }

            this.plugin.PluginManager.Server.Map.Broadcast(20, "<color=red>Ивент отменён</color>", false);
            

            return new[] { "Turned" };
        }
    }
}
