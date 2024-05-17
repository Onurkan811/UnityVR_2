using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image hpBar;
    public Image easeHealthBar;
    public float hp;
    float maxHP;
    private Animator anim;

    private float lerpSpeed = 0.01f;

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
            gameObject.SetActive(false);
        }
    }
    
    public void DamagePlayer(int a)
    {
        hp -= a;
        Debug.Log("Can: " + hp);
        if (hp <= 0)
        {
            Debug.Log("�ld�n..");
        }
    }

    public void DamageDragon(int a)
    {
        hp -= a;
        hpBar.fillAmount = hp / maxHP;
        Debug.Log("Ejderha: " + hp);
        if (hp <= 0)
        {
            Debug.Log("Forest Dragon is Dead");
            hpBar.fillAmount = 0;
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
    void Update()
    {
        if (easeHealthBar.fillAmount != hpBar.fillAmount)
        {
            easeHealthBar.fillAmount = Mathf.Lerp(easeHealthBar.fillAmount, hpBar.fillAmount, lerpSpeed);
        }
    }
}
