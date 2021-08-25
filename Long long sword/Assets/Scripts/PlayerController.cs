using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
       movement.x = Input.GetAxisRaw("Horizontal");
       movement.y = Input.GetAxisRaw("Vertical");

      animationController();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }




   public void animationController()
    {

        
        
        
        
        if(Input.GetKey("up") || Input.GetKey("down") || Input.GetKey("left") || Input.GetKey("right"))
        {
            rb.GetComponent<Animator>().SetBool("idleRight", false);
            rb.GetComponent<Animator>().SetBool("idleLeft", false);
            rb.GetComponent<Animator>().SetBool("idleUp", false);
        }
        
        //modifies bool. it uses an if and else if so u cannot play 2 animations at the same time

        if (Input.GetKey("up")){

            rb.GetComponent<Animator>().SetBool("up", true);
        }
        else if (Input.GetKey("down"))
        {
            rb.GetComponent<Animator>().SetBool("down", true);
        }
        else if (Input.GetKey("right"))
        {
            rb.GetComponent<Animator>().SetBool("right", true);
        }
        else if (Input.GetKey("left"))
        {
            rb.GetComponent<Animator>().SetBool("left", true);
        }

       /* else {
            rb.GetComponent<Animator>().SetBool("up", false);
            rb.GetComponent<Animator>().SetBool("down", false);
            rb.GetComponent<Animator>().SetBool("right", false);
            rb.GetComponent<Animator>().SetBool("left", false);

        } */

        //when you release the button the animation has to stop 

        if (Input.GetKeyUp("up"))
        {
            rb.GetComponent<Animator>().SetBool("up", false);
            rb.GetComponent<Animator>().SetBool("idleUp", true);
        }

        if (Input.GetKeyUp("down"))
        {
            rb.GetComponent<Animator>().SetBool("down", false);
        }
        if (Input.GetKeyUp("right"))
        {
            rb.GetComponent<Animator>().SetBool("right", false);
            rb.GetComponent<Animator>().SetBool("idleRight", true);
        }
        if (Input.GetKeyUp("left"))
        {
            rb.GetComponent<Animator>().SetBool("left", false);
            rb.GetComponent<Animator>().SetBool("idleLeft", true);
        }

    }

   

   
   
}
