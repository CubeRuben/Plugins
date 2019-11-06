using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.API;

using UnityEngine;
using UnityEngine.Networking;

namespace RPPlugin.EventHandlers
{
    class FixedUpdate : IEventHandlerFixedUpdate
    {
        RPPlugin plugin;

        public FixedUpdate(RPPlugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnFixedUpdate(FixedUpdateEvent ev)
        {
            //Получение урона кровотечения и гниения в 30 тиков
            if (this.plugin.tick < 30)
            {
                this.plugin.tick++;
            }
            else
            {
                this.plugin.tick = 0;

                for (int i = 0; i < this.plugin.bleedingPlayers.Count; i++)
                {
                    Player player = this.plugin.PluginManager.Server.GetPlayer(this.plugin.bleedingPlayers[i]);

                    if (player == null)
                    {
                        this.plugin.bleedingPlayers.Remove(this.plugin.bleedingPlayers[i]);
                    }
                    else
                    {
                        player.Damage(1, DamageType.NONE);
                    }
                }

                for (int i = 0; i < this.plugin.rottingPlayers.Count; i++)
                {
                    Player player = this.plugin.PluginManager.Server.GetPlayer(this.plugin.rottingPlayers[i]);

                    if (player == null)
                    {
                        this.plugin.rottingPlayers.Remove(this.plugin.rottingPlayers[i]);
                    }
                    else
                    {
                        player.Damage(1, DamageType.NONE);
                    }
                }
            }

            //Изменение положения трупов
            for (int i = 0; i < this.plugin.pickedUpRagdolls.Count; i++)
            {
                Player player = this.plugin.Server.GetPlayer(this.plugin.pickedUpRagdolls[i].playerId);

                if (player == null)
                {
                    this.plugin.pickedUpRagdolls.RemoveAt(i);
                }
                else
                {
                    GameObject playerGameObject = (GameObject)player.GetGameObject();

                    this.plugin.pickedUpRagdolls[i].ragdoll.transform.position = playerGameObject.transform.position;
                    GameObject ragdoll = GameObject.Instantiate<GameObject>(this.plugin.pickedUpRagdolls[i].ragdoll.gameObject, playerGameObject.transform.position + new Vector3(Mathf.Sin(this.plugin.pickedUpRagdolls[i].ragdoll.transform.rotation.eulerAngles.y * Mathf.PI / 180) * -0.3f, -1.0f, Mathf.Cos(this.plugin.pickedUpRagdolls[i].ragdoll.transform.rotation.eulerAngles.y * Mathf.PI / 180) * -0.3f), Quaternion.Euler(playerGameObject.transform.rotation.eulerAngles));
                    //GameObject ragdoll = GameObject.Instantiate<GameObject>(this.plugin.ragdolls[this.plugin.pickedUpRagdolls[i].ragdollId], playerGO.transform.position + new Vector3(Mathf.Sin(this.plugin.ragdolls[this.plugin.pickedUpRagdolls[i].ragdollId].transform.rotation.eulerAngles.y * Mathf.PI / 180 + 45) * 0.25f /*+ this.plugin.ragdolls[this.plugin.pickedUpRagdolls[i].ragdollId].transform.localScale.y / 2*/, 0.35f, Mathf.Cos(this.plugin.ragdolls[this.plugin.pickedUpRagdolls[i].ragdollId].transform.rotation.eulerAngles.y * Mathf.PI / 180 + 45) * 0.25f /*+ this.plugin.ragdolls[this.plugin.pickedUpRagdolls[i].ragdollId].transform.localScale.y / 2*/), Quaternion.Euler(playerGO.transform.rotation.eulerAngles + new Vector3(0, 0, 90)));*/
                    NetworkServer.Spawn(ragdoll);
                    NetworkServer.Destroy(this.plugin.pickedUpRagdolls[i].ragdoll.gameObject);
                    this.plugin.pickedUpRagdolls[i].ragdoll = ragdoll.GetComponent<Ragdoll>();
                }
            }
        }
    }
}
