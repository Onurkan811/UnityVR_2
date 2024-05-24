using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardSpell : MonoBehaviour
{
    private Animator wizardAnim;
    private GameObject wizard;
    public GameObject fireShield;

    public SpellHolder spellHolder;

    private bool spellFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        wizardAnim = GetComponent<Animator>();
        wizard = GameObject.Find("DarkWizard");
    }

    // Update is called once per frame
    void Update()
    {
        if (spellHolder.isSelected && spellFlag == false)
        {
            spellFlag = true;
            wizardAnim.SetTrigger("blastAttack");
            fireShield.SetActive(true);
            StartCoroutine(DelayedFunction());
        }
    }
    
    IEnumerator DelayedFunction()
    {
        yield return new WaitForSeconds(4);
        fireShield.SetActive(false);
        StartCoroutine(ShieldDelay());
    }
    
    IEnumerator ShieldDelay()
    {
        yield return new WaitForSeconds(12);
        spellFlag = false;
    }
    
}
