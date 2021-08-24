using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{

    public GameObject target;

    public float rotationFactor = 4f;
    private float direction = 0;

    public Rigidbody2D rb;

    Vector2 vectorRotation;

    Vector2 movement;

    private Vector3 zAxis = new Vector3(0, 0, 1);
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        rb.freezeRotation = true;
        Vector2 inputVector = Vector2.zero;
        direction = 0;
        if (Input.GetKey("a"))
        {
            direction = rotationFactor;
        }

        if (Input.GetKey("d"))
        {
            direction = -rotationFactor;
        }


        vectorRotation = inputVector;

    }



    void FixedUpdate()
    {
        applyRotacion();
    }


    void applyRotacion()
    {
        //rb.transform.rotation.Set(rb.transform.rotation.x, rb.transform.rotation.y, rb.transform.rotation.z + rotationFactor * vectorRotation.x, rb.transform.rotation.w);

        if (direction != 0)
        {
            //rb.transform.eulerAngles = rb.transform.eulerAngles + Vector3.forward * direction;
            //rb.transform.Rotate(new Vector3(0, 0, direction * 20));

            target.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            rb.freezeRotation = false;
            rb.MoveRotation(rb.rotation + direction * 10);
            
            //Quaternion q = Quaternion.AngleAxis(direction * 10, Vector3.forward);
            //rb.MovePosition(q * (rb.transform.position - target.GetComponent<Rigidbody2D>().transform.position) + target.GetComponent<Rigidbody2D>().transform.position);
            //rb.MoveRotation(rb.transform.rotation * q);
            
        } else
        {
            target.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        //transform.RotateAround(target.transform.position, vectorRotation, 20 * Time.deltaTime);
    }

}
