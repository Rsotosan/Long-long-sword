using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSceneDialogue : MonoBehaviour
{

    public GameObject dialogueBox;
    public GameObject canvas;
    public GameObject keys;

    public bool decisionMoment = false;
    public bool finalScene = false;
    public string decision = "";
    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueBox.GetComponent<DialogueController>().index == -1 && !finalScene)
        {
            canvas.SetActive(true);
            keys.SetActive(true);
            decisionMoment = true;
        }
        if (decisionMoment)
        {
            if (Input.GetKeyDown("a"))
            {
               decisionFunction("village");
            }
            if (Input.GetKeyDown("d"))
            {
                decisionFunction("castle");
            }
        }
    }

    private void decisionFunction(string decision)
    {
        this.decision = decision;
        decisionMoment = false;
        canvas.SetActive(false);
        keys.SetActive(false);
        finalScene = true;
    }
    private void OnDisable()
    {
        
    }

     
}
