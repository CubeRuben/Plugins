using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;

using System;

namespace RPPlugin.EventHandlers
{
    class SummonVehicle : IEventHandlerSummonVehicle
    {
        RPPlugin plugin;

        public SummonVehicle(RPPlugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnSummonVehicle(SummonVehicleEvent ev)
        {
            /*if (this.plugin.whenSummoned < DateTime.Now)
            {
                if (!this.plugin.allowRespawnMTF)
                {
                    ev.AllowSummon = false;
                }
                else
                {
                    this.plugin.allowRespawnMTF = false;
                }
            }*/
        }
    }
}
