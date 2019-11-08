using Smod2;
using Smod2.API;
using Smod2.EventHandlers;
using Smod2.Events;

using System;

using UnityEngine;
using UnityEngine.Networking;

namespace RPPlugin.EventHandlers
{
    class CallCommand : IEventHandlerCallCommand
    {
        RPPlugin plugin;

        public CallCommand(RPPlugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnCallCommand(PlayerCallCommandEvent ev)
        {
            //Обработка комманд в консоли
            switch (ev.Command.Split(' ')[0])
            {
                //Вызов МОГа
                case "recallmtf":
                    if ((!this.plugin.allowRespawnMTF) && ((ev.Player.TeamRole.Team == Smod2.API.Team.NINETAILFOX) || (ev.Player.TeamRole.Team == Smod2.API.Team.SCIENTIST) || (ev.Player.TeamRole.Team == Smod2.API.Team.CLASSD)))
                    {
                        if (Math.Sqrt(Math.Pow(ev.Player.GetPosition().x - this.plugin.intercom.x, 2) + Math.Pow(ev.Player.GetPosition().y - this.plugin.intercom.y, 2) + Math.Pow(ev.Player.GetPosition().z - this.plugin.intercom.z, 2)) <= 3)
                        {
                            this.plugin.Round.MTFRespawn(false);
                            this.plugin.allowRespawnMTF = true;
                            this.plugin.PluginManager.Server.Map.AnnounceCustomMessage("MTFUNIT WILL BE IN FACILITY IN 2 MINUTES");
                            ev.ReturnMessage = "Вы вызвали мог";
                        }
                        else
                        {
                            ev.ReturnMessage = "Вы далеко от интеркома";
                        }
                    }
                    else
                    {
                        ev.ReturnMessage = "Вызов запрещён";
                    }
                    break;
                //Побег за SCP
                case "escape":
                    if ((ev.Player.GetPosition().x >= 174) && (ev.Player.GetPosition().x <= 186.63) && (ev.Player.GetPosition().y >= 983) && (ev.Player.GetPosition().y <= 990) && (ev.Player.GetPosition().z >= 35.34) && (ev.Player.GetPosition().z <= 40.46))
                    {
                        switch (ev.Player.TeamRole.Team)
                        {
                            case Smod2.API.Team.SCP:
                                ev.Player.ChangeRole(Role.SPECTATOR);
                                ev.ReturnMessage = "Вы сбежали";
                                this.plugin.Server.Map.AnnounceCustomMessage("SCP ESCAPE FROM FACILITY");
                                for (int i = 0; i < this.plugin.pickedUpRagdolls.Count; i++)
                                {
                                    if (this.plugin.pickedUpRagdolls[i].playerId == ev.Player.PlayerId)
                                    {
                                        this.plugin.pickedUpRagdolls.RemoveAt(i);
                                        break;
                                    }
                                }
                                break;
                            default:
                                ev.ReturnMessage = "Вам нельзя сбежать";
                                break;

                        }
                    }
                    else
                    {
                        ev.ReturnMessage = "Вы далеко от пункта побега";
                    }
                    break;
                //Поднятие тела
                case "pickupbody":
                    ev.ReturnMessage = "Рядом нет трупов";

                    Ragdoll[] ragdolls = GameObject.FindObjectsOfType<Ragdoll>();

                    if ((ev.Player.TeamRole.Role == Smod2.API.Role.SCP_049_2) || (ev.Player.TeamRole.Role == Smod2.API.Role.SCP_079) || (ev.Player.TeamRole.Role == Smod2.API.Role.SCP_096) || (ev.Player.TeamRole.Role == Smod2.API.Role.SCP_173) || (ev.Player.TeamRole.Role == Smod2.API.Role.SCP_939_53) || (ev.Player.TeamRole.Role == Smod2.API.Role.SCP_939_89))
                    {
                        ev.ReturnMessage = "Вы не можете носить трупы";
                        goto pickupbodyend;
                    }

                    for (int i = 0; i < this.plugin.pickedUpRagdolls.Count; i++)
                    {
                        if (ev.Player.PlayerId == this.plugin.pickedUpRagdolls[i].playerId)
                        {
                            ev.ReturnMessage = "Вы уже несёте труп";
                            goto pickupbodyend;
                        }
                    }

                    for (int i = 0; i < ragdolls.Length; i++)
                    {
                        if (Math.Sqrt(Math.Pow(ev.Player.GetPosition().x - ragdolls[i].transform.position.x, 2) + Math.Pow(ev.Player.GetPosition().y - ragdolls[i].transform.position.y, 2) + Math.Pow(ev.Player.GetPosition().z - ragdolls[i].transform.position.z, 2)) <= 3)
                        {
                            for (int a = 0; a < this.plugin.pickedUpRagdolls.Count; a++)
                            {
                                if (this.plugin.pickedUpRagdolls[a].ragdoll == ragdolls[i])
                                {
                                    ev.ReturnMessage = "Этот труп уже несёт другой человек";
                                    goto pickupbodyend;
                                }
                            }

                            if (ragdolls[i].owner.charclass == 0)
                            {
                                ev.ReturnMessage = "Эти камни очень тяжелые";
                                break;
                            }
                            else
                            {
                                this.plugin.pickedUpRagdolls.Add(new PickedUpRagdoll(ev.Player.PlayerId, ragdolls[i]));
                                ev.ReturnMessage = "Вы подняли труп";
                                if (ragdolls[i].owner.charclass == 3)
                                {
                                    for (int b = 0; b < this.plugin.rottingPlayers.Count; b++)
                                    {
                                        if (this.plugin.rottingPlayers[b] == ev.Player.PlayerId)
                                        {
                                            goto founded;
                                        }
                                    }

                                    ev.Player.PersonalClearBroadcasts();
                                    ev.Player.PersonalBroadcast(10, "<b><color=red>Вы начали гнить</color></b>", true);
                                    this.plugin.rottingPlayers.Add(ev.Player.PlayerId);
                                founded:;
                                }
                                break;
                            }
                        }
                    }
                pickupbodyend:;
                    break;
                //Сбрасывание тела
                case "dropbody":
                    ev.ReturnMessage = "Вы не несёте труп";
                    for (int i = 0; i < this.plugin.pickedUpRagdolls.Count; i++)
                    {
                        if (ev.Player.PlayerId == this.plugin.pickedUpRagdolls[i].playerId)
                        {
                            this.plugin.pickedUpRagdolls.RemoveAt(i);
                            ev.ReturnMessage = "Вы бросили труп";
                        }
                    }
                    break;
                /*case "cassie":
                    ev.ReturnMessage = "Вы не SCP-079";
                    if (ev.Player.TeamRole.Role == Role.SCP_079)
                    {
                        ev.ReturnMessage = "У вас не хватает уровня";
                        if (ev.Player.Scp079Data.Level >= 3)
                        {
                            ev.ReturnMessage = "У вас мало энергии";
                            if (ev.Player.Scp079Data.AP >= 100)
                            this.plugin.Server.Map.AnnounceCustomMessage("");
                        }
                    }
                    break;*/
                /*case "test":
                    GameObject.FindObjectOfType<ConfigFile>
                    break;*/
                case "test":
                    this.plugin.ironBlyat.Create(((GameObject)ev.Player.GetGameObject()).transform.position, plugin);
                    //GameObject shoot = GameObject.Instantiate(, (ev.Player.GetGameObject()));
                    //((GameObject)ev.Player.GetGameObject()).GetComponent<WeaponManager>().Sho;
                    //GameObject.FindObjectOfType<SoundtrackManager>().PlayOverlay(1);
                    break;
            }
        }
    }
}
