using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using TMPro;
using System;

public class DialogueController : MonoBehaviour
{

    public TextMeshProUGUI textComponent;

    public string[] lines;

    public float textSpeed;

    public int index;

    public GameObject zPrefab;

    PlayerController player;
    SwordController sword;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        sword = GameObject.FindGameObjectWithTag("Sword").GetComponent<SwordController>();
        player.enabled = false;
        sword.enabled = false;
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("z"))
        {
                if (textComponent.text == lines[index])
                {
                    NextLine();
                }

                else
                {
                    StopAllCoroutines();
                    textComponent.text = lines[index];
                }
        }
    }


    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);

        }
    }

    void NextLine()
    {
    if (index < lines.Length-1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            index = -1;
            player.enabled = true;
            sword.enabled = true;
        }
    }

    private void OnEnable()
    {
        if (index == -1)
        {
            player.enabled = false;
            sword.enabled = false;
            textComponent.text = string.Empty;
            index = 0;
            StartCoroutine(TypeLine());
        }
    }
}
