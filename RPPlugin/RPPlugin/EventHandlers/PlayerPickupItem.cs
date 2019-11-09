using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.API;


namespace RPPlugin.EventHandlers
{
    class PlayerPickupItem : IEventHandlerPlayerPickupItem
    {
        RPPlugin plugin;

        public PlayerPickupItem(RPPlugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnPlayerPickupItem(PlayerPickupItemEvent ev)
        { 
            /*if (ev.Item.GetHashCode() == this.plugin.itemForRequestOfMtf.GetHashCode())
            {
                ev.Allow = false;
                //this.plugin.PluginManager.Server.Map.SpawnItem(ItemType.WEAPON_MANAGER_TABLET, ev.Item.GetPosition(), new Vector(0, 0, 0));
                this.plugin.Server.Map.AnnounceCustomMessage("EPSILON 11");
            }*/

            //Признание Д на уничтожение
            if ((ev.Player.TeamRole.Role == Role.CLASSD) && ((ev.Item.ItemType == ItemType.COM15) || (ev.Item.ItemType == ItemType.LOGICER) || (ev.Item.ItemType == ItemType.MP7) || (ev.Item.ItemType == ItemType.E11_STANDARD_RIFLE) || (ev.Item.ItemType == ItemType.MICROHID) || (ev.Item.ItemType == ItemType.P90) || (ev.Item.ItemType == ItemType.USP) || (ev.Item.ItemType == ItemType.FRAG_GRENADE) || (ev.Item.ItemType == ItemType.FLASHBANG)))
            {
                for (int i = 0; i < this.plugin.idPlayersForTermination.Count; i++)
                {
                    if (this.plugin.idPlayersForTermination[i] == ev.Player.PlayerId)
                    {
                        goto playerTerminated;
                    }
                }

                this.plugin.idPlayersForTermination.Add(ev.Player.PlayerId);

                char[] nickname = ev.Player.Name.ToCharArray();

                this.plugin.PluginManager.Server.Map.AnnounceCustomMessage("CLASSD " + nickname[nickname.Length - 5] + " " + nickname[nickname.Length - 4] + " " + nickname[nickname.Length - 3] + " " + nickname[nickname.Length - 2] + " DESIGNATED FOR TERMINATION .");
            }
        playerTerminated:;
        }
    }
}
