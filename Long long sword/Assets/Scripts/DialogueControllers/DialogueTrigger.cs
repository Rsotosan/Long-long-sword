using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueTrigger : MonoBehaviour
{

    private bool playerInRange;

    public GameObject dialogueBox;
    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && Input.GetKeyDown("z"))
        {

            dialogueBox.SetActive(true);
        }


    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("player here");

        }


    }
    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            Debug.Log("player left");

        }


    }
}
