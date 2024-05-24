using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IceSpiritFollow : MonoBehaviour
{
    private Transform targetObj;
    private NavMeshAgent enemy;
    void Start()
    {
        targetObj = GameObject.Find("Player").GetComponent<Transform>();
        enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, targetObj.position);
        if (dist <= 70)
        {
            enemy.SetDestination(targetObj.position);
        }

    }
}
