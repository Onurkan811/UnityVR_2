using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject hurt;
    public GameObject gameOver;
    public Slider easeHealthSlider;
    public Slider healthSlider;
    public float maxHealth = 100f;
    public float health;
    private float lerpSpeed = 0.005f;

    private bool takingDamage = false;
    private bool gameOverFlag = false;

    // CanvasGroup bileşeni
    private CanvasGroup hurtCanvasGroup;
    private CanvasGroup gameOverCanvasGroup;

    void Start()
    {
        health = maxHealth;

        // Hurt panelinin CanvasGroup bileşenini al
        hurtCanvasGroup = hurt.GetComponent<CanvasGroup>();

        // Eğer CanvasGroup bileşeni yoksa, hata mesajı yazdır
        if (hurtCanvasGroup == null)
        {
            Debug.LogError("CanvasGroup bileşeni bulunamadı!");
        }// Hurt panelinin CanvasGroup bileşenini al
        gameOverCanvasGroup = gameOver.GetComponent<CanvasGroup>();

        // Eğer CanvasGroup bileşeni yoksa, hata mesajı yazdır
        if (gameOverCanvasGroup == null)
        {
            Debug.LogError("CanvasGroup bileşeni bulunamadı!");
        }
    }

    void Update()
    {
        if (gameOverFlag)
        {
            return;
        }
        if (healthSlider.value != health)
        {
            healthSlider.value = health;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }
        if (easeHealthSlider.value != healthSlider.value)
        {
            easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, healthSlider.value, lerpSpeed);
        }

        if (takingDamage)
        {
            StartCoroutine(ShowHurtPanel());
        }
        if (health <= 0f && !gameOver.activeSelf)
        {
            gameOverFlag = true; // Set game over flag
            StartCoroutine(ShowgameOverPanel());
        }
    }
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
takingDamage = false; // Hasar alma durumunu sıfırla
hurt.SetActive(false); // Hasar nesnesini devre dışı bırak

        }
        else
        {
            Debug.LogError("CanvasGroup bileşeni bulunamadı!");
        }
    }

    void TakeDamage(float damage)
    {
        health -= damage;
        takingDamage = true;
    }
}
