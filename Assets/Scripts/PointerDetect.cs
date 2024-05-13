using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerDetect : MonoBehaviour
{
    public bool castSpell = false;

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position,transform.forward);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Enemy"))
        {

            castSpell = true;
        }
        else
        {
            castSpell = false;
        }

    }
}
