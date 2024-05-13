using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : ScriptableObject
{
    public new string name;
    public float cooldownTime;
    public float activeTime;
    public int Damage;
    public virtual void Activate(GameObject parent)
    {
    }

}
