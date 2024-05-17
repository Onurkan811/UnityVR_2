using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class play : MonoBehaviour
{
    private Coroutine selectionDelay;
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
        SceneManager.LoadScene("ForestMap");
        Debug.Log("Selection Completed");
        
    }
}
