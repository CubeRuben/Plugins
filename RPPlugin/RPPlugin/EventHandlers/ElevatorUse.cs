using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.API;

using System;

namespace RPPlugin.EventHandlers
{
    class ElevatorUse : IEventHandlerElevatorUse
    {
        RPPlugin plugin;

        public ElevatorUse(RPPlugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnElevatorUse(PlayerElevatorUseEvent ev)
        {
            //Блокировка лифтов
            if (ev.Player.GetCurrentItem().ItemType == ItemType.MTF_COMMANDER_KEYCARD)
            {
                if (ev.Elevator.ElevatorType == ElevatorType.GateA)
                {
                    ev.AllowUse = false;

                    if (this.plugin.elevatorsLockdown.timeOfReset >= DateTime.Now)
                    {
                        return;
                    }

                    if (this.plugin.elevatorsLockdown.elevatorA)
                    {
                        this.plugin.elevatorsLockdown.elevatorA = false;
                        this.plugin.Server.Map.AnnounceCustomMessage("GATE A ELEVATOR IS AVAILABLE NOW");
                        this.plugin.elevatorsLockdown.timeOfReset = DateTime.Now.AddMinutes(1);
                    }
                    else
                    {
                        if (this.plugin.elevatorsLockdown.elevatorB)
                        {
                            this.plugin.elevatorsLockdown.elevatorA = true;
                            this.plugin.elevatorsLockdown.elevatorB = false;
                            this.plugin.Server.Map.AnnounceCustomMessage("GATE A ELEVATOR IS LOCKDOWN AND GATE B ELEVATOR IS AVAILABLE NOW");
                            this.plugin.elevatorsLockdown.timeOfReset = DateTime.Now.AddMinutes(1);
                        }
                        else
                        {
                            this.plugin.elevatorsLockdown.elevatorA = true;
                            this.plugin.Server.Map.AnnounceCustomMessage("GATE A ELEVATOR IS LOCKDOWN");
                            this.plugin.elevatorsLockdown.timeOfReset = DateTime.Now.AddMinutes(1);
                        }
                    } 
                }

                if (ev.Elevator.ElevatorType == ElevatorType.GateB)
                {
                    ev.AllowUse = false;

                    if (this.plugin.elevatorsLockdown.timeOfReset >= DateTime.Now)
                    {
                        return;
                    }

                    if (this.plugin.elevatorsLockdown.elevatorB)
                    {
                        this.plugin.elevatorsLockdown.elevatorB = false;
                        this.plugin.Server.Map.AnnounceCustomMessage("GATE B ELEVATOR IS AVAILABLE NOW");
                        this.plugin.elevatorsLockdown.timeOfReset = DateTime.Now.AddMinutes(1);
                    }
                    else
                    {
                        if (this.plugin.elevatorsLockdown.elevatorA)
                        {
                            this.plugin.elevatorsLockdown.elevatorB = true;
                            this.plugin.elevatorsLockdown.elevatorA = false;
                            this.plugin.Server.Map.AnnounceCustomMessage("GATE B ELEVATOR IS LOCKDOWN AND GATE A ELEVATOR IS AVAILABLE NOW");
                            this.plugin.elevatorsLockdown.timeOfReset = DateTime.Now.AddMinutes(1);
                        }
                        else
                        {
                            this.plugin.elevatorsLockdown.elevatorB = true;
                            this.plugin.Server.Map.AnnounceCustomMessage("GATE B ELEVATOR IS LOCKDOWN");
                            this.plugin.elevatorsLockdown.timeOfReset = DateTime.Now.AddMinutes(1);
                        }
                    }
                }
            }
            else
            {
                if ((ev.Elevator.ElevatorType == ElevatorType.GateA) && this.plugin.elevatorsLockdown.elevatorA)
                {
                    ev.AllowUse = false;
                }

                if ((ev.Elevator.ElevatorType == ElevatorType.GateB) && this.plugin.elevatorsLockdown.elevatorB)
                {
                    ev.AllowUse = false;
                }
            }
        }
    }
}
