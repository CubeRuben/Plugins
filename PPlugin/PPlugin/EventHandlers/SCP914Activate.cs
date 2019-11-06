using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.API;

namespace PPlugin.EventHandlers
{
    class SCP914ChangeKnob : IEventHandlerSCP914ChangeKnob
    {
        PPlugin plugin;

        public SCP914ChangeKnob(PPlugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnSCP914ChangeKnob(PlayerSCP914ChangeKnobEvent ev)
        {
            if (this.plugin.round.type == RoundType.HOSTAGES)
            {
                ev.KnobSetting = KnobSetting.ROUGH;
            }
        }
    }
}
