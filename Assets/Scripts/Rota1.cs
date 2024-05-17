using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Rota1 : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform R1,R2,R3;
    private int dest;
    public AudioSource walkSound;
    // Start is called before the first frame update
    void Start()
    {
    
        agent = GetComponent<NavMeshAgent>();
        R1 = GameObject.Find("R1").GetComponent<Transform>();
        R2 = GameObject.Find("R2").GetComponent<Transform>();
        R3 = GameObject.Find("R3").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.hasPath)
        {
            if(!walkSound.isPlaying)
                walkSound.Play();
        }
        else
        {
            walkSound.Stop();
        }
        if(agent.remainingDistance == 0)
        {
            dest++;
        }
        
        switch (dest)
        {
            case 1:
                agent.SetDestination(R1.position);
                agent.speed = 2;
                break;
            case 2:
                agent.SetDestination(R2.position);
                agent.speed = 4;
                break;
            case 3:
                agent.SetDestination(R3.position);
                agent.speed = 2;
                break;
        }
    }
}
