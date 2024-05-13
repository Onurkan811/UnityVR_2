using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FireSpell : Spell
{
    public GameObject bullet;
    public override void Activate(GameObject parent)
    {
        Transform pointer = parent.transform.Find("CardboardReticlePointer");
        Instantiate(bullet, pointer.position, pointer.rotation);
    }
}
