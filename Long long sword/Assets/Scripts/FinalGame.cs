using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalGame : MonoBehaviour
{

    public GameObject dialogue;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(explosion());
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogue.GetComponent<DialogueController>().index == -1)
        {
            StartCoroutine(endGame());
        }
    }

    IEnumerator explosion()
    {
        yield return new WaitForSeconds(1);
        dialogue.SetActive(true);
    }

    IEnumerator endGame()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MainMenu");
    }
}
