using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LastLevelRoute : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform R1, R2, R3, R4, R5, R6;
    private int dest;
    public AudioSource walkSound;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        R1 = GameObject.Find("Rota1").GetComponent<Transform>();
        R2 = GameObject.Find("Rota2").GetComponent<Transform>();
        R3 = GameObject.Find("Rota3").GetComponent<Transform>();
        R4 = GameObject.Find("Rota4").GetComponent<Transform>();
        R5 = GameObject.Find("Rota5").GetComponent<Transform>();
        R6 = GameObject.Find("Rota6").GetComponent<Transform>();
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

        if(agent.isActiveAndEnabled && agent.isOnNavMesh && agent.remainingDistance == 0)
        {
            dest++;
        }

        switch (dest)
        {
            case 1:
                agent.SetDestination(R1.position);
                agent.speed = 10;
                break;
            case 2:
                agent.SetDestination(R2.position);
                agent.speed = 10;
                break;
            case 3:
                agent.SetDestination(R3.position);
                agent.speed = 10;
                break;
            case 4:
                agent.SetDestination(R4.position);
                agent.speed = 10;
                break;
            case 5:
                agent.SetDestination(R5.position);
                agent.speed = 10;
                break;
            case 6:
                agent.SetDestination(R6.position);
                agent.speed = 4;
                break;
        }
    }
}