using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HealSpell : Spell
{
    public GameObject bullet;
    public override void Activate(GameObject parent)
    {
        Transform pointer = parent.transform.Find("CardboardReticlePointer");
        Instantiate(bullet, new Vector3(pointer.position.x, pointer.position.y - 0.5f, pointer.position.z), Quaternion.identity);
    }
}
