using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image hpBar;
    public float hp;
    float maxHP;

    private void Start()
    {
        maxHP = hp;
    }
    public void Damage(int a)
    {
        hp -= a;
        hpBar.fillAmount = hp / maxHP;
        
        if (hp <= 0) 
        {
            hp = 0;
            hpBar.fillAmount = 0;
            gameObject.layer = 0;
            Destroy(gameObject);
        }
    }

    public void Heal(int a)
    {
        hp += a;
        hpBar.fillAmount = hp / maxHP; 
        if (hp > maxHP)
        {
            hp = maxHP;
        }
    }
}
