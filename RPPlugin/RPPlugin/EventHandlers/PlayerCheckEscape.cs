using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.API;

namespace RPPlugin.EventHandlers
{
    class PlayerCheckEscape : IEventHandlerCheckEscape
    {
        RPPlugin plugin;

        public PlayerCheckEscape(RPPlugin plugin)
        {
            this.plugin = plugin;
        }

        //Онвызывается только припобеге за Д и Учённых
        public void OnCheckEscape(PlayerCheckEscapeEvent ev)
        {
            //Переавод сбежавшего Учённого и Д-Класса
            ev.ChangeRole = Role.SPECTATOR;

            //Удаление игрока с трупом из массива
            for (int i = 0; i < this.plugin.pickedUpRagdolls.Count; i++)
            {
                if (this.plugin.pickedUpRagdolls[i].playerId == ev.Player.PlayerId)
                {
                    this.plugin.pickedUpRagdolls.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
