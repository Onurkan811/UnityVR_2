using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R3 : MonoBehaviour
{
    public GameObject dragon;
    public GameObject lights;

    // Start is called before the first frame update
    void Start()
    {
        dragon.SetActive(false);
        lights.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            dragon.SetActive(true);
            lights.SetActive(true);
        }
    }
}
