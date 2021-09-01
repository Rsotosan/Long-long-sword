using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class FinalScene : MonoBehaviour
{

    public Image blackFade;

    public GameObject sword;

    public float velocity = 4;
    private float direction;
    private Rigidbody2D rb;

    public GameObject dialogueBox;
    public GameObject canvas;
    public GameObject keys;

    public bool decisionMoment = false;
    public bool finalScene = false;
    public string decision = "";
    public bool firstIteration = true;

    void Start()
    {
        blackFade.canvasRenderer.SetAlpha(0.0f);
        rb = sword.GetComponent<Rigidbody2D>();
        dialogueBox.SetActive(true);
        direction = -velocity;
    }

    void Update()
    {
        if (!finalScene)
        {
            if (dialogueBox.GetComponent<DialogueController>().index == -1 && !finalScene)
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
    }

    private void decisionFunction(string decision)
    {
        this.decision = decision;
        decisionMoment = false;
        canvas.SetActive(false);
        keys.SetActive(false);
        finalScene = true;
    }

    private void FixedUpdate()
    {
        if (!finalScene)
        {
            if (rb.rotation < 30)
            {
                direction = velocity;
            }
            if (rb.rotation > 150)
            {
                direction = -velocity;
            }
            rb.MoveRotation(rb.rotation + direction);
        } else
        {
            finalSceneAnimation();
        }
    }

    private void finalSceneAnimation()
    {
        if (firstIteration)
        {
            rb.SetRotation(90);
            velocity = 2f;
            firstIteration = false;
        }
        if(decision == "village")
        {
            direction = velocity;
        } else
        {
            direction = -velocity;
        }
        rb.MoveRotation(rb.rotation + direction);
    }


    public void endOfScene()
    {

        if(decision == "village")
        {
            SceneManager.LoadScene("FinalGameCastle");
        } else
        {
            SceneManager.LoadScene("FinalGameVillage");
        }
        
    }
}
