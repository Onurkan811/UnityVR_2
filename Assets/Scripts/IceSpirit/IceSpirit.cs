using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IceSpirit : MonoBehaviour
{
    private string spellN;
    public bool castSpell = false;
    private Health health;
    Coroutine pointerDetected;
    private NavMeshAgent agent;
    private void Start()
    {
        health = GetComponent<Health>();
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
                    health.Damage(70);
                    break;

                case "ice":
                    Freeze();
                    break;


            }

        }
    }


    void Freeze()
    {
        agent.speed = 5f;
        GetComponent<Renderer>().material.color = Color.blue;
        StartCoroutine(FreezeTime());
    }

    IEnumerator FreezeTime()
    {
        yield return new WaitForSeconds(2);
        agent.speed = 3f;
        GetComponent<Renderer>().material.color = Color.white;
    }
}
