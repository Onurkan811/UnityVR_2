using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellMenu : MonoBehaviour
{
    public GameObject gjCam;
    void Start()
    {
        foreach (var material in Resources.FindObjectsOfTypeAll<Material>())
        {
            if (material.shader.name.StartsWith("Universal Render Pipeline"))
            {
                material.shader = Shader.Find("Standard");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gjCam.transform.eulerAngles.x < 60)
        {
            Quaternion q = transform.rotation;
            q = Quaternion.Euler(new Vector3(transform.rotation.x, gjCam.transform.eulerAngles.y, transform.rotation.z));
            transform.rotation = q;
        }

    }
}
