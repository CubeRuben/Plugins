using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;

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
            if (!this.plugin.allowRespawnMTF)
            {
                ev.AllowSummon = false;
            }
            else
            {
                this.plugin.allowRespawnMTF = false;
            }
        }
    }
}
