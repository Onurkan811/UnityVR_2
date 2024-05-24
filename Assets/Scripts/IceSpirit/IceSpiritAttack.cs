using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IceSpiritAttack : MonoBehaviour
{

    private Health playerHealth;
    private Animator anim;
    private NavMeshAgent agent;
    private bool kamikaze= true;
    void Start()
    {
        playerHealth = GameObject.Find("Player").GetComponent<Health>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(agent.remainingDistance - agent.stoppingDistance <= 1 && kamikaze)
        {


        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && kamikaze) {
            anim.SetTrigger("attack");
            kamikaze = false;
            StartCoroutine(iceAttack());
            Debug.Log("Collision2");
        }
    }
    IEnumerator iceAttack()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Ice attack");
        playerHealth.DamagePlayer(50);
        gameObject.SetActive(false);
    }
}
