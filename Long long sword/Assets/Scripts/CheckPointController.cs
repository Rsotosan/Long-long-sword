using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{

    GameObject varGameObject;


    // Start is called before the first frame update
    void Start()
    {
        varGameObject = GameObject.FindWithTag("waterguy1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        varGameObject.GetComponent<NPCController>().checkpoint_forest = true;

    


    }
}
