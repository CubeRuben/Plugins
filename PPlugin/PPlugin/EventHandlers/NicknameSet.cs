using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;

namespace PPlugin.EventHandlers
{
    class NicknameSet : IEventHandlerNicknameSet
    {
        PPlugin plugin;

        public NicknameSet(PPlugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnNicknameSet(PlayerNicknameSetEvent ev)
        {
            if (this.plugin.rusNamesEnabled)
            {
                ev.Nickname = this.plugin.rusSecondNames[this.plugin.random.Next(this.plugin.rusSecondNames.Length)] + " " + this.plugin.rusNames[this.plugin.random.Next(this.plugin.rusNames.Length)];
            }
        }
    }
}
