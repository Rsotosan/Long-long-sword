using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScene : MonoBehaviour
{

    public GameObject sword;
    public GameObject dialogueBox;

    private float direction = -4f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = sword.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (rb.rotation < 30) {
            direction = 4f;
        }
        if(rb.rotation > 150)
        {
            direction = -4f;
        }
        rb.MoveRotation(rb.rotation + direction );
    }
}
