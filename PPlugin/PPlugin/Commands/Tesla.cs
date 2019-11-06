using Smod2;
using Smod2.Commands;
using Smod2.API;

using System.Collections.Generic;

namespace PPlugin.Commands
{
    class Tesla : ICommandHandler
    {
        PPlugin plugin;
        public Tesla(PPlugin plugin)
        {
            this.plugin = plugin;
        }

        public string GetCommandDescription()
        {
            return "Turn tesla off and on";
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

            List<TeslaGate> teslas = this.plugin.PluginManager.Server.Map.GetTeslaGates();

            if (System.Convert.ToBoolean(args[0]))
            {
                for (int i = 0; i < teslas.Count; i++)
                {
                    teslas[i].TriggerDistance = 5.5f;
                }
            }
            else
            {
                for (int i = 0; i < teslas.Count; i++)
                {
                    teslas[i].TriggerDistance = 0;
                }
            }

            return new[] { "Turned" };
        }
    }
}
