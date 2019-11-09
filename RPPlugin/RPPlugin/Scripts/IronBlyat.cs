using UnityEngine;
using UnityEngine.AI;

namespace RPPlugin.Scripts
{
    public class IronBlyat : MonoBehaviour
    {
        NavMeshAgent agent;
        Scp939PlayerScript[] players;
        Transform target;

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            players = GameObject.FindObjectsOfType<Scp939PlayerScript>();
            target = null;
        }

        void Update()
        {
            players = GameObject.FindObjectsOfType<Scp939PlayerScript>();
            /*if (target != null)
            {
                if (Vector3.Distance(target.transform.position, transform.position) > 5)
                {
                    for (int i = 0; i < players.Length; i++)
                    {
                        if (Vector3.Distance(players[i].gameObject.transform.position, transform.position) <= 5)
                        {
                            target = players[i].gameObject.transform;
                            break;
                        }

                        target = null;
                    }
                }
            }
            else
            {
                for (int i = 0; i < players.Length; i++)
                {
                    if (Vector3.Distance(players[i].gameObject.transform.position, transform.position) <= 5)
                    {
                        target = players[i].gameObject.transform;
                        break;
                    }

                    target = null;
                }
            }*/

            /*if (target != null)
            {*/
            agent.destination = players[0].transform.position;
            /*for (int i = 0; i < players.Length; i++)
            {
                if (Vector3.Distance(target.transform.position, transform.position) <= 5)
                {
                   

                }
            }*/
            //}
            //transform.position += new Vector3(0, 0.1f, 0);
        }

    }
}
