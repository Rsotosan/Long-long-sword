using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGuyController : MonoBehaviour
{

    public bool direction_right = false;

    public Rigidbody2D rb;

    public float waterGuySpeedFactor; 


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        
        if (direction_right) 
        { 
            rb.transform.Translate(Vector2.right * waterGuySpeedFactor * Time.deltaTime);
        }
        
        if (direction_right == false)
        {
            rb.transform.Translate(Vector2.left * waterGuySpeedFactor * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


       
        if (collision.gameObject.CompareTag("waterRightCollider"))
            {

        direction_right = false;

        }

        if (collision.gameObject.CompareTag("waterLeftCollider"))
        {

            direction_right = true;

        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Debug.Log("colision with player");
            gameObject.SetActive(false);
        }
    }



}
