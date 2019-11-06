using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.API;

namespace OPlugin.EventHandlers
{
    public class FixedUpdate : IEventHandlerFixedUpdate
    {
        OPlugin plugin;
        public FixedUpdate(OPlugin plugin)
        {
            this.plugin = plugin;
        }
        public void OnFixedUpdate(FixedUpdateEvent ev)
        {
            for (int i = 0; i < this.plugin.rainbowPlayers.Count; i++)
            {
                Player player = this.plugin.PluginManager.Server.GetPlayer(this.plugin.rainbowPlayers[i]);
                if (player != null)
                {
                    player.SetRank(this.plugin.colors[this.plugin.random.Next(this.plugin.colors.Length)], "Гирлянда");
                }
                else
                {
                    this.plugin.rainbowPlayers.Remove(this.plugin.rainbowPlayers[i]);
                }
            }

            for (int i = 0; i < this.plugin.frozedPlayers.Count; i++)
            {
                Player player = this.plugin.PluginManager.Server.GetPlayer(this.plugin.frozedPlayers[i].id);
                if (player != null)
                {
                    player.Teleport(this.plugin.frozedPlayers[i].position);
                }
                else
                {
                    this.plugin.frozedPlayers.Remove(this.plugin.frozedPlayers[i]);
                }
            }
        }
    }

}
