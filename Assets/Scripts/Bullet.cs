using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string spell;
    Rigidbody rb;
    public float speed = 215;
    public bool goOn = false;
    private GameObject yourTarget;
    public GameObject crosshair;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
        RaycastHit _hit = new RaycastHit();
        if (Physics.Raycast(crosshair.transform.position, crosshair.transform.forward, out _hit))
        {
            Debug.Log(_hit.transform.gameObject);
            if (_hit.transform.tag == "Enemy")
            {
                yourTarget = _hit.transform.gameObject;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        StartCoroutine(lezGo());

        // Update is called once per frame



    }

    void Update()
    {


        if (goOn == true)
        {
            Debug.Log("Çalýþýyor");
            transform.right = yourTarget.transform.position - transform.position;
            transform.position += transform.right * speed * Time.deltaTime;
        }

    }

    IEnumerator lezGo()
    {
        yield return new WaitForSeconds(1);
        goOn = true;
    }
}
