using Smod2;
using Smod2.Commands;

namespace PPlugin.Commands
{
    class BroadcastSCPDeath : ICommandHandler
    {
        PPlugin plugin;
        public BroadcastSCPDeath(PPlugin plugin)
        {
            this.plugin = plugin;
        }

        public string GetCommandDescription()
        {
            return "Turn broadcast scp death off and on";
        }

        public string GetUsage()
        {
            return "(BOOL)";
        }

        public string[] OnCall(ICommandSender sender, string[] args)
        {
            if (args.Length < 1)
            {
                return new[] { "No bool data" };
            }

            if ((args[0].ToUpper() != "FALSE") && (args[0].ToUpper() != "TRUE"))
            {
                return new[] { "No bool data" };
            }

            this.plugin.broadcastSCPDeath = System.Convert.ToBoolean(args[0]);

            return new[] { "Turned" };
        }
    }
}
