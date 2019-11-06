using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.API;

namespace PPlugin.EventHandlers
{
    class DoorAccess : IEventHandlerDoorAccess
    {
        PPlugin plugin;

        public DoorAccess(PPlugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnDoorAccess(PlayerDoorAccessEvent ev)
        {
            if (ev.Player.IsHandcuffed())
            {
                ev.Allow = false;
            }

            if ((ev.Player.TeamRole.Role == Role.SCP_173) && (ev.Player.GetHealth() <= 500))
            {
                if (!ev.Door.Open)
                {
                    ev.Destroy = true;
                }
            }

            if ((ev.Player.GetCurrentItem().ItemType == ItemType.CHAOS_INSURGENCY_DEVICE) && (ev.Door.Name == ""))
            {
                if (this.plugin.random.NextDouble() <= 0.6)
                {
                    ev.Player.GetCurrentItem().Remove();
                    ev.Player.GiveItem(ItemType.COIN);
                    ev.Player.PersonalBroadcast(4, "<color=red><b>Устройство сломалось</b></color>", true);
                }
                else
                {
                    ev.Destroy = true;
                    ev.Player.PersonalBroadcast(4, "<color=red><b>Устройство ударило вас током</b></color>", true);
                    ev.Player.Damage(this.plugin.random.Next(20) + 10, DamageType.TESLA);
                }
            }
        }
    }
}
