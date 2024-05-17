using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public Image hpBar;
    public Image easeHealthBar;
    public float hp;
    float maxHP;
    private Animator anim;
    
    // Audio
    public AudioSource EnemySoundSource;
    public AudioClip[] EnemySounds;

    private float lerpSpeed = 0.01f;
    
    public Image newHealthBar;

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
            if (EnemySoundSource.isPlaying == false)
            {
                EnemySoundSource.clip = EnemySounds[1];
                EnemySoundSource.Play();
            }
        }
    }
    
    public void DamagePlayer(int a)
    {
        hp -= a;
        newHealthBar.fillAmount = hp / maxHP;
        Debug.Log("Can: " + hp);
        if (hp <= 0)
        {
            StartCoroutine(SceneDelay());
            Debug.Log("Öldün..");
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
    
    IEnumerator SceneDelay()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("ForestMap");
    }
}
