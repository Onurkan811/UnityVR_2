using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Animator wizardAnim;
    public GameObject wizard;
    public GameObject player;
    public GameObject r6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "AttackRegion")
        {
            wizardAnim.SetTrigger("basicAttack");
            r6.SetActive(false);
        }
    }
}
