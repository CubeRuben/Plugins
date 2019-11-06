using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;

namespace PPlugin.EventHandlers
{
    class ElevatorUse : IEventHandlerElevatorUse
    {
        PPlugin plugin;

        public ElevatorUse(PPlugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnElevatorUse(PlayerElevatorUseEvent ev)
        {
            if (ev.Player.IsHandcuffed())
            {
                ev.AllowUse = false;
            }
        }
    }
}
