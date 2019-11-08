using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;

namespace RPPlugin.EventHandlers
{
    class RoundRestart : IEventHandlerRoundRestart
    {
        RPPlugin plugin;

        public RoundRestart(RPPlugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnRoundRestart(RoundRestartEvent ev)
        {
            //Очистка всего
            //this.plugin.SCP106CanTeleportToPlayer = 0;
            this.plugin.idPlayersForTermination.Clear();
            this.plugin.rottingPlayers.Clear();
            this.plugin.bleedingPlayers.Clear();
            this.plugin.elevatorsLockdown.elevatorA = false;
            this.plugin.elevatorsLockdown.elevatorB = false;
            this.plugin.pickedUpRagdolls.Clear();
            this.plugin.allowRespawnMTF = false;
            this.plugin.tick = 0;
        }
    }
}
