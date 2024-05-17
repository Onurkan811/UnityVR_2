using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAttack : MonoBehaviour
{
    private NavMeshAgent agent;
    public float attackTimer = 1f;
    private float timer;
    private Animator anim;
    private Health playerHealth;
    private EnemyFollow follow;
    
    // Audio
    public AudioSource MushroomSoundSource;
    public AudioClip[] MushroomSounds;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        playerHealth = GameObject.Find("Player").GetComponent<Health>();
        follow = GetComponent<EnemyFollow>();
        timer = attackTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if(follow.enabled == true)
        {
            if (agent.hasPath)
            {
                if (agent.remainingDistance <= 0.1 + agent.stoppingDistance)
                {
                    timer -= Time.deltaTime;
                    if (timer <= 0)
                    {
                        anim.SetTrigger("attack");
                        timer = attackTimer;
                        playerHealth.DamagePlayer(20);
                        MushroomSoundSource.clip = MushroomSounds[0];
                        MushroomSoundSource.Play();
                    }
                }
            }

 
        }
        else
        {
            agent.SetDestination(transform.position);
            anim.SetTrigger("freeze");
        }

    }
}
