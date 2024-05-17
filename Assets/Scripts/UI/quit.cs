using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit : MonoBehaviour
{
    private Coroutine selectionDelay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerEnter()
    {
        selectionDelay = StartCoroutine(SelectionDelay());
    }
    public void OnPointerExit()
    {
            StopCoroutine(selectionDelay);
            Debug.Log("Selection Canceled");
    }

    IEnumerator SelectionDelay()
    {
        yield return new WaitForSeconds(2f);
        Application.Quit();
        Debug.Log("Selection Completed");
        
    }
}
