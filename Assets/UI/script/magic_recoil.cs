using System;
using System.Collections;
    using UnityEngine;
    using UnityEngine.UI;

    public class magic_recoil : MonoBehaviour
    {
        public Slider magic_fire_recoil;
        public Slider magic_frost_recoil;
        public Slider magic_heal_recoil;
        public GameObject CoolDownForntground;
        public GameObject CoolDownForntground2;
        public GameObject CoolDownForntground3;
        public float maxRecoil = 100f;
        public float recoil;
        private bool fireCooldown = false;
        private bool frostCooldown = false;
        private bool healCooldown = false;

        public float cooldownTimer1 = 5f;
        public float cooldownTimer2 = 5f;
        public float cooldownTimer3 = 5f;

        void Start()
        {
            recoil = maxRecoil;
        }

        void Update()
    {
      if (fireCooldown)
    {
    cooldownTimer1 -= Time.deltaTime;
    magic_fire_recoil.value = 0f;
    if (cooldownTimer1 <= 0f)
    {   

        CoolDownForntground.SetActive(true);
        fireCooldown = false;
        cooldownTimer1 = 20f;
        magic_fire_recoil.value += Time.deltaTime*maxRecoil;
        Debug.Log("Fire cooldown complete. Slider value: " + magic_fire_recoil.value);
        CoolDownForntground.SetActive(false);
    }
    }

      if (frostCooldown)
    {
    cooldownTimer2 -= Time.deltaTime;
    if (cooldownTimer2 <= 0f)
    {   
        CoolDownForntground2.SetActive(true);
        frostCooldown = false;
        cooldownTimer2 = 5f;
        magic_frost_recoil.value = maxRecoil;
        CoolDownForntground2.SetActive(false);
    }
    }
    if (healCooldown)
    {
    cooldownTimer3 -= Time.deltaTime;
    if (cooldownTimer3 <= 0f)
    {
        CoolDownForntground3.SetActive(true);
        healCooldown = false;
        cooldownTimer3 = 5f;
        magic_heal_recoil.value = maxRecoil;
        CoolDownForntground3.SetActive(false);
    }
    }

       if (Input.GetKeyDown(KeyCode.Q) && !fireCooldown)
{
    fireCooldown = true;
}

if (Input.GetKeyDown(KeyCode.W) && !frostCooldown)
{
    frostCooldown = true;
}

if (Input.GetKeyDown(KeyCode.E) && !healCooldown)
{
    healCooldown = true;
}

    }
    }
