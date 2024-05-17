using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R3 : MonoBehaviour
{
    public GameObject dragon;
    public Transform dragonSpawn;
    public GameObject lights;
    private BoxCollider R3Collider;

    // Start is called before the first frame update
    void Start()
    {
        R3Collider = GetComponent<BoxCollider>();
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
            Instantiate(dragon, dragonSpawn.position, dragonSpawn.rotation);            
            lights.SetActive(true);
            R3Collider.enabled = false;
            
        }
    }
}
