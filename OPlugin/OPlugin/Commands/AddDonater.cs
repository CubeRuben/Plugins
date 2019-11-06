using Smod2;
using Smod2.Commands;

using System;
using System.IO;

namespace OPlugin.Commands
{
    public class AddDonater : ICommandHandler
    {
        OPlugin plugin;
        public AddDonater(OPlugin plugin)
        {
            this.plugin = plugin;
        }

        public string GetCommandDescription()
        {
            return "Set of tag for donater";
        }

        public string GetUsage()
        {
            return "(SteamID64)";
        }

        public string[] OnCall(ICommandSender sender, string[] args)
        {
            if (args.Length < 1)
            {
                return new[] { "No steam id" };
            }

            if (args.Length < 2)
            {
                return new[] { "No color" };
            }

            DateTime dateStart = DateTime.Now;

            DateTime dateEnd = dateStart.AddDays(28);

            string donators = File.ReadAllText("../donaters.txt");

            donators += $"{args[0]} {dateEnd.Day} {dateEnd.Month} {dateEnd.Year} {args[1]};";

            File.WriteAllText("../donaters.txt", donators);

            return new[] { "New donater added" };
        }

    }
}
