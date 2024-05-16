using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem.Android;
using UnityEngine.InputSystem.XR;

public class Enemy : MonoBehaviour
{
    private string spellN;
    public bool castSpell = false;
    private Health health;
    Coroutine pointerDetected;
    public GameObject mushroom;
    private EnemyFollow follow;
    private void Start()
    {
        health = GetComponent<Health>();
        follow = GetComponent<EnemyFollow>();
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
                    health.Damage(50);
                    Freeze();
                    break;


            }
                
        }
    }

    
    void Freeze()
    {
        if (gameObject) 
        { 
            Debug.Log("mush BUZ");
            follow.enabled = false;
            mushroom.GetComponent<Renderer>().material.color = Color.blue;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.blue;
            StartCoroutine(FreezeTime());
        }

    }

    IEnumerator FreezeTime()
    {
        yield return new WaitForSeconds(2);
        GetComponent<Renderer>().material.color = Color.cyan;
    }
}
