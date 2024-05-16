using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBreath : MonoBehaviour
{
    private Transform playerTrans;
    private Transform stay;
    private bool isStay= true;
    public float speed;
    void Start()
    {
        playerTrans = GameObject.Find("Player").GetComponent<Transform>();   
        stay = GameObject.Find("Bone022").GetComponent<Transform>();
        StartCoroutine(StayDelay());
        transform.Rotate(180, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isStay)
        {
            transform.position = stay.position;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, playerTrans.position, speed* Time.deltaTime);
        }
    }

    IEnumerator StayDelay()
    {
        yield return new WaitForSeconds(2.1f);
        isStay = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerTrans.gameObject.GetComponent<Health>().DamagePlayer(50);
            gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "Bullet" && collision.gameObject.GetComponent<Bullet>().spell == "fire")
        {
            gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
        }
    }
}
