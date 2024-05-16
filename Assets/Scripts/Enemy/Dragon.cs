using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.UI.Image;

public class Dragon : MonoBehaviour
{
    private string spellN;
    public bool castSpell = false;
    private Health health;
    Coroutine pointerDetected;
    private Animator anim;
    public bool canWalk = false;
    public Material matDragon;
    private NavMeshAgent agent;
    private Transform transPlayer;
    private Health playerHealth;
    public Transform fireSpawnP;
    public GameObject fireBreathFab;
    private bool dead;
    private void Start()
    {
        transPlayer = GameObject.Find("Player").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        health = GetComponent<Health>();
        playerHealth = GameObject.Find("Player").GetComponent<Health>();
        matDragon.color = Color.white;
        StartCoroutine(StartDelay());
    }

    private void Update()
    {
       
        if(health.hp <= 0)
        {
            dead = true;
        }

        if (health.hp <= 0) 
        {
            anim.SetTrigger("dead");
            StartCoroutine(DestroyDelay(10));
        }

        if(canWalk)
        {
            anim.SetTrigger("walk");
            agent.SetDestination(transPlayer.position);
            if(agent.remainingDistance - agent.stoppingDistance <= 0.01f)
            {
                anim.SetTrigger("attack2");
                StartCoroutine(Attack2Delay());
            }
        }
        else
        {
            agent.SetDestination(transform.position);
            anim.SetTrigger("idle");
        }
    }
    public void OnPointerEnter()
    {
        pointerDetected = StartCoroutine(PointerDetected());
    }
    public void OnPointerExit()
    {
        StopCoroutine(pointerDetected);
        castSpell = false;

    }
    IEnumerator PointerDetected()
    {
        yield return new WaitForSeconds(0.25f);
        castSpell = true;
        Debug.Log("True oldu");
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            spellN = collision.gameObject.GetComponent<Bullet>().spell;
            collision.gameObject.SetActive(false);
            switch (spellN)
            {
                case "fire":
                    health.DamageDragon(70);
                    break;

                case "ice":
                    health.DamageDragon(50);
                    Freeze();
                    break;


            }

        }
    }


    void Freeze()
    {
        anim.SetTrigger("stun");
        matDragon.color = Color.cyan;
        canWalk = false;
        StartCoroutine(FreezeTime());
    }

    IEnumerator FreezeTime()
    {
        yield return new WaitForSeconds(7.1f);
        matDragon.color = Color.white;
        StartCoroutine(ThrowFire());
    }

    IEnumerator DestroyDelay(float a)
    {
        yield return new WaitForSeconds(a);
        gameObject.SetActive(false);
    }
    IEnumerator Attack2Delay()
    {
        yield return new WaitForSeconds(1);
        playerHealth.DamagePlayer(100);
    }

    IEnumerator ThrowFire()
    {
        if (!dead) 
        {
            Instantiate(fireBreathFab, fireSpawnP.position, Quaternion.identity);
            yield return new WaitForSeconds(2.85f);
            canWalk = true;
        }

    }

    IEnumerator StartDelay() 
    {
        yield return new WaitForSeconds(2);
        canWalk = true;
    }
}
