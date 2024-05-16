using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string spell;
    Rigidbody rb;
    public float speed = 5;
    public bool goOn = false;
    private GameObject yourTarget;
    public GameObject crosshair;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
        RaycastHit _hit = new RaycastHit();
        if (Physics.Raycast(crosshair.transform.position, crosshair.transform.forward, out _hit))
        {
            Debug.Log("Mermi:"+_hit.transform.gameObject);
            if (_hit.transform.tag == "Enemy")
            {
                yourTarget = _hit.transform.gameObject;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
        StartCoroutine(lezGo());

        // Update is called once per frame



    }

    void Update()
    {


        if (goOn == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, yourTarget.transform.position, speed * Time.deltaTime);
        }

    }

    IEnumerator lezGo()
    {
        yield return new WaitForSeconds(1);
        goOn = true;
    }
}
