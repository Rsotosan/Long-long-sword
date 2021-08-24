using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    public GameObject sword;

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

        if (Input.GetKeyDown("space"))
        {
            interactiveSword();
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    private void interactiveSword()
    {
        HingeJoint2D joint = sword.GetComponent<HingeJoint2D>();
        if(joint.enabled == true)
        {
            dropSword(joint);
        } else
        {
            catchSword(joint);
        }
    }

    private void dropSword(HingeJoint2D joint)
    {
        sword.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        joint.enabled = false;
    }

    private void catchSword(HingeJoint2D joint)
    {
        sword.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        joint.enabled = true;
    }
}
