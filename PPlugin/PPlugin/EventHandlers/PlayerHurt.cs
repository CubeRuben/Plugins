using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.API;

using System.Collections.Generic;

namespace PPlugin.EventHandlers
{
    class PlayerHurt : IEventHandlerPlayerHurt
    {
        PPlugin plugin;

        public PlayerHurt(PPlugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnPlayerHurt(PlayerHurtEvent ev)
        {
            if (ev.DamageType == DamageType.SCP_939)
            {
                if ((ev.Attacker.TeamRole.Role == Role.SCP_939_53) || (ev.Attacker.TeamRole.Role == Role.SCP_939_89))
                {
                    ev.Attacker.AddHealth(50);
                }
            }

            if (ev.DamageType == DamageType.SCP_106)
            {
                List<Item> items = ev.Player.GetInventory();

                items[this.plugin.random.Next(items.Count)].Remove();
            }

            if (ev.DamageType == DamageType.POCKET)
            {
                List<Item> items = ev.Player.GetInventory();

                if (this.plugin.random.NextDouble() <= 0.05)
                {
                    items[this.plugin.random.Next(items.Count)].Remove();
                }
            }
        }
    }
}
