using UnityEngine;
using UnityEngine.AI;

namespace RPPlugin.Scripts
{
    public class IronBlyat : MonoBehaviour
    {
        NavMeshAgent agent;
        Scp939PlayerScript[] players;


        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            players = GameObject.FindObjectsOfType<Scp939PlayerScript>();
        }

        void FixedUpdate()
        {
            float distance = Vector3.Distance(players[1].gameObject.transform.position, transform.position);

            if (distance <= 10)
            {
                agent.SetDestination(players[1].gameObject.transform.position);
                
            }
            //transform.position += new Vector3(0, 0.1f, 0);
        }

    }
}
