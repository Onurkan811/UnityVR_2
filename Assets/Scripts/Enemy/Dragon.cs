using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.UI.Image;
using UnityEngine.SceneManagement;

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
    
    public AudioSource EnemySoundSource;
    public AudioClip[] EnemySounds;
    
    public AudioSource music;
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
            anim.SetTrigger("dead");
            EnemySoundSource.clip = EnemySounds[0];
            EnemySoundSource.Play();
            StartCoroutine(DestroyDelay(10));
            SceneManager.LoadScene("IceMap");
        }

        if(canWalk)
        {
            anim.SetTrigger("walk");
            agent.SetDestination(transPlayer.position);
            if (EnemySoundSource.isPlaying == false)
            {
                EnemySoundSource.clip = EnemySounds[1];
                EnemySoundSource.Play();
            }
            
            if(agent.remainingDistance <= 4 && agent.hasPath)
            {
                if (EnemySoundSource.isPlaying == false)
                {
                    EnemySoundSource.clip = EnemySounds[0];
                    EnemySoundSource.Play();
                }
                anim.SetTrigger("attack2");
                StartCoroutine(Attack2Delay());
            }
        }
        else
        {
            agent.SetDestination(transform.position);
            anim.SetTrigger("idle");
            if (EnemySoundSource.isPlaying == false)
            {
                EnemySoundSource.clip = EnemySounds[0];
                EnemySoundSource.Play();
            }
            if (music.isPlaying == false)
            {
                music.Play();
            }
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
        EnemySoundSource.clip = EnemySounds[3];
        EnemySoundSource.Play();
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
            anim.SetTrigger("attack1");
            EnemySoundSource.clip = EnemySounds[2];
            EnemySoundSource.Play();
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
