using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{

    public bool direction_right = false;

    public Rigidbody2D rb;
    public GameObject[] triggers;

    private Queue<GameObject> triggersQueue = new Queue<GameObject>();

    public float waterGuySpeedFactor; 


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        triggersQueue = new Queue<GameObject>(triggers);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (triggersQueue.Count == 0) {
            triggersQueue = new Queue<GameObject>(triggers);
        }
        Vector2 mov = ((Vector2)triggersQueue.Peek().transform.position - rb.position).normalized;
        //rb.transform.Translate(mov * waterGuySpeedFactor * Time.deltaTime);
        rb.MovePosition(rb.position + mov * waterGuySpeedFactor);
        //rb.velocity = mov * waterGuySpeedFactor;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.Equals(triggersQueue.Peek()))
        {
            GameObject trigger = triggersQueue.Dequeue();
            triggersQueue.Enqueue(trigger);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {

            Debug.Log("colision with sword");
            gameObject.SetActive(false);
        }
    }



}
