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
    }

    // Update is called once per frame
    private void Update()
    {
        Debug.Log(agent.remainingDistance - agent.stoppingDistance);
        if(agent.remainingDistance - agent.stoppingDistance <= 1 && kamikaze)
        {
            anim.SetTrigger("attack");
            StartCoroutine(iceAttack());
            kamikaze = false;
        }
    }
    IEnumerator iceAttack()
    {
        yield return new WaitForSeconds(0.5f);
        playerHealth.DamagePlayer(50);
        gameObject.SetActive(false);
    }
}
