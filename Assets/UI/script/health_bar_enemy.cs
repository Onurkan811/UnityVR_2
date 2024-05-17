    using System.Collections;
    using UnityEngine;
    using UnityEngine.UI;

    public class HealthBar_enemy : MonoBehaviour
    {
        public Slider easeHealthSlider;
        public Slider healthSlider;
        public float maxHealth = 100f;
        public float health;
        private float lerpSpeed = 0.005f;

        void Start()
        {
            health = maxHealth;
        }

        void Update()
        {
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

        }


        void TakeDamage(float damage)
        {
            health -= damage;
        }
    }
