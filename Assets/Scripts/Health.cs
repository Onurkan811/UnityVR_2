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

    public GameObject gameOver;
    public GameObject hurt;

    private CanvasGroup hurtCanvasGroup;
    
    private CanvasGroup gameOverCanvasGroup;

    private bool takingDamage = false;


    private void Start()
    {
        hurtCanvasGroup = hurt.GetComponent<CanvasGroup>();
        gameOverCanvasGroup = gameOver.GetComponent<CanvasGroup>();
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
        takingDamage = true;

        if (takingDamage)
        {
            StartCoroutine(ShowHurtPanel());
        }
        hp -= a;
        newHealthBar.fillAmount = hp / maxHP;
        Debug.Log("Can: " + hp);
        if (hp <= 0)
        {
            StartCoroutine(ShowgameOverPanel());
            //StartCoroutine(SceneDelay());
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
    
  /*  IEnumerator SceneDelay()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("ForestMap");
    }
    */
    IEnumerator ShowgameOverPanel()
    {
        if (gameOverCanvasGroup != null)
        {
            gameOver.SetActive(true);
float fadeSpeed = 0.3f; // Opaklık değişim hızı
float targetAlpha = 0.9f; // Hedef opaklık değeri
float currentAlpha = 0f; // Şu anki opaklık değeri
while (currentAlpha < targetAlpha) {
    currentAlpha += fadeSpeed * Time.deltaTime; // Opaklık artışı
    gameOverCanvasGroup.alpha = currentAlpha; // Opaklık değerini ayarla
    yield return null; // Bir sonraki çerçeveyi bekle
}
       
        yield return new WaitForSecondsRealtime(3f); // 3 saniye bekle (gerçek zamanla)
        Time.timeScale = 0f; // Zamanı durdur
        SceneManager.LoadScene("ForestMap");
        }
        else
        {
            Debug.LogError("CanvasGroup bileşeni bulunamadı!");
        }
    }
    IEnumerator ShowHurtPanel()
    {
        if (hurtCanvasGroup != null)
        {
            hurt.SetActive(true);
float fadeSpeed = 3f; // Opaklık değişim hızı
float targetAlpha = 0.8f; // Hedef opaklık değeri
float currentAlpha = 0f; // Şu anki opaklık değeri
while (currentAlpha < targetAlpha) {
    currentAlpha += fadeSpeed * Time.deltaTime; // Opaklık artışı
    hurtCanvasGroup.alpha = currentAlpha; // Opaklık değerini ayarla
    yield return null; // Bir sonraki çerçeveyi bekle
}
targetAlpha = 0f; // Hedef opaklık değerini sıfıra ayarla
currentAlpha = 0.8f; // Şu anki opaklık değerini bir yap
while (currentAlpha > targetAlpha) {
    currentAlpha -= fadeSpeed * Time.deltaTime; // Opaklık azalışı
    hurtCanvasGroup.alpha = currentAlpha; // Opaklık değerini ayarla
    yield return null; // Bir sonraki çerçeveyi bekle
}
hurt.SetActive(false); // Hasar nesnesini devre dışı bırak

        }
        

}
}

