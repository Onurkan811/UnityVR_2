using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellHolder : MonoBehaviour
{
    public Spell spell;
    float cooldownTime;
    float activeTime;

    private GameObject gjCam;
    private Coroutine selectionDelay;
    public bool isSelected = false;
    public bool isCastableEnemy = true;
    public bool castSpell = false;
    public PointerDetect pointer;
    private Animator asaAnim;

    private void Start()
    {
        gjCam = GameObject.Find("Main Camera");
        asaAnim = GameObject.Find("Asa_Export").GetComponent<Animator>();
    }
    enum SpellState { 
        ready,
        active,
        cooldown
    }
    SpellState state = SpellState.ready;
    // Update is called once per frame
    void Update()
    {
        if (isCastableEnemy)
        {
            castSpell = pointer.castSpell;
            
        }
        else
        {
            castSpell = true;
        }

        

        switch (state)
        {
            case SpellState.ready:
                if (isSelected)
                {
                    gameObject.GetComponent<Renderer>().material.SetColor("_BaseColor", Color.gray);
                    activeTime = spell.activeTime;
                    if (castSpell)
                    {
                        spell.Activate(gjCam);
                        asaAnim.SetTrigger("spell");
                        Debug.Log("Activate Func.");
                        state = SpellState.active;
                        isSelected = false;
                        castSpell = false;
                    }
                    
                }
                break;
            case SpellState.active:
                if(activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                }
                else
                {
                    state = SpellState.cooldown;

                    cooldownTime = spell.cooldownTime;
                }
            break;
            case SpellState.cooldown:
                if (cooldownTime > 0)
                {
                    cooldownTime -= Time.deltaTime;
                }
                else
                {
                    gameObject.GetComponent<Renderer>().material.SetColor("_BaseColor", Color.white);

                    state = SpellState.ready;
                }

                break;


        }

    }

    public void OnPointerEnter()
    {
      if(state == SpellState.ready)
        {
            selectionDelay = StartCoroutine(SelectionDelay());
            Debug.Log("Selection Started");
        }
    }
    public void OnPointerExit()
    {
        if (!isSelected) 
        {
            StopCoroutine(selectionDelay);
            Debug.Log("Selection Canceled");
        }

    }

    IEnumerator SelectionDelay()
    {
        yield return new WaitForSeconds(0.5f);
        isSelected = true;
        Debug.Log("Selection Completed");
    }

}
