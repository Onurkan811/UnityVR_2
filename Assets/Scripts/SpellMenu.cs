using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellMenu : MonoBehaviour
{
    public GameObject gjCam;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(gjCam.transform.position.x, gjCam.transform.position.y - 0.75f, gjCam.transform.position.z);
        if (gjCam.transform.eulerAngles.x < 60)
        {
            Quaternion q = transform.rotation;
            q = Quaternion.Euler(new Vector3(transform.rotation.x, gjCam.transform.eulerAngles.y, transform.rotation.z));
            transform.rotation = q;
        }

    }
}
