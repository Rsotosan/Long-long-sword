using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatController : MonoBehaviour
{

    public Rigidbody2D rb;

    SpriteRenderer sprite;


    public float ratSpeed = 30;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        if (Input.GetKey("right"))
        {

            sprite.flipX = false;

            rb.transform.Translate(Vector2.right * ratSpeed * Time.deltaTime);

           // rb.MovePosition( Vector2.right * ratSpeed * Time.deltaTime);

            rb.GetComponent<Animator>().SetBool("RatWalking", true);
        } 
        
        else if(Input.GetKey("left"))
            {
           
            
           // rb.MovePosition(Vector2.left  * ratSpeed * Time.deltaTime);

           rb.transform.Translate(Vector2.left * ratSpeed * Time.deltaTime);

            rb.GetComponent<Animator>().SetBool("RatWalking", true);

            sprite.flipX = true;
        }

        if (!Input.GetKey("right") && !Input.GetKey("left"))

        {

           
            //   rb.MovePosition(Vector2.zero);

            
            rb.GetComponent<Animator>().SetBool("RatWalking", false);

        }


    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("ratFood"))
        {

            StartCoroutine(noMovementFunction());



        }


        IEnumerator noMovementFunction()
        {
            gameObject.GetComponent<RatController>().enabled = false;

            yield return new WaitForSeconds(1);

            gameObject.GetComponent<RatController>().enabled = true;

        }
    }
}
