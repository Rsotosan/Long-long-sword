using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSceneDialogue : MonoBehaviour
{

    public GameObject dialogueBox;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueBox.GetComponent<DialogueController>().index == -1)
        {
            canvas.SetActive(true);
        }
    }

    private void OnDisable()
    {
        canvas.SetActive(true);
    }
}
