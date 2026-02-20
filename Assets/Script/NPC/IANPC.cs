using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class IANPC : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;
    public float stopDinstance = 2f;
    public float NPCSalid = 0f;

    public bool order = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = stopDinstance;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SiguiendoOrdene();
        NPCState();
    }

    void SiguiendoOrdene()
    {
        FollowPlayer(order);
    }

    void FollowPlayer(bool order)
    {
        if (NPCSalid < 100)
        {
            //Debug.Log("No puedo seguirte estoy herido");

        }
        else if(target != null && order && NPCSalid >= 100)
        {
            agent.SetDestination(target.position);
        }
    }

    void NPCState()
    {
        if (NPCSalid < 100f)
        {
            //Debug.Log("Estoy herido");
        }
        else
        {
            NPCSalid = 100;
            //Debug.Log("Estoy curado");
        }
    }
}
