using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class NPCController : MonoBehaviour
{

    public bool direction_right = false;



    GameObject varGameObject;

    public bool checkpoint_forest = false;

    //for death cutscene
    public bool alive = true;

    public Rigidbody2D rb;
    public GameObject[] triggers;

    private Queue<GameObject> triggersQueue = new Queue<GameObject>();

    public float waterGuySpeedFactor;

    public Vector2 mov;


    // Start is called before the first frame update
    void Start()
    {
        varGameObject = GameObject.FindWithTag("Player");

        rb = GetComponent<Rigidbody2D>();
        triggersQueue = new Queue<GameObject>(triggers);
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {

        
        npcAnimationController();
        }

    }

    private void FixedUpdate()
    {


        if (alive)
        {

       
        if (triggersQueue.Count == 0) {
            triggersQueue = new Queue<GameObject>(triggers);
        }
         mov = ((Vector2)triggersQueue.Peek().transform.position - rb.position).normalized;
        //rb.transform.Translate(mov * waterGuySpeedFactor * Time.deltaTime);
        rb.MovePosition(rb.position + mov * waterGuySpeedFactor);
            //rb.velocity = mov * waterGuySpeedFactor;
        }


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
        if (collision.gameObject.CompareTag("Sword") || collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(dying());

        }
    }

    void npcAnimationController()
    {

        if (mov.x < 0)
        {
            if (mov.y < 0.5 && mov.y > -0.5)
            {
                //posicion = "izquierda";
                rb.GetComponent<Animator>().SetBool("osoLeft", true);

                      rb.GetComponent<Animator>().SetBool("osoRight", false);
                      rb.GetComponent<Animator>().SetBool("osoUp", false);
                      rb.GetComponent<Animator>().SetBool("osoDown", false);

            }
            else if (mov.y < -0.5)
            {
                //   posicion = "abajo";

                rb.GetComponent<Animator>().SetBool("osoDown", true);
                      rb.GetComponent<Animator>().SetBool("osoRight", false);
                      rb.GetComponent<Animator>().SetBool("osoUp", false);
                      rb.GetComponent<Animator>().SetBool("osoLeft", false);
            }
            else if (mov.y > 0.5)
            {
                //  posicion = "arriba";
                rb.GetComponent<Animator>().SetBool("osoUp", true);
                         rb.GetComponent<Animator>().SetBool("osoRight", false);
                         rb.GetComponent<Animator>().SetBool("osoDown", false);
                         rb.GetComponent<Animator>().SetBool("osoLeft", false);
            }
        }
        else if (mov.x > 0)
        {
            if (mov.y < 0.5 && mov.y > -0.5)
            {
               // posicion = "derecha";
                rb.GetComponent<Animator>().SetBool("osoRight", true);

                        rb.GetComponent<Animator>().SetBool("osoUp", false);
                        rb.GetComponent<Animator>().SetBool("osoDown", false);
                        rb.GetComponent<Animator>().SetBool("osoLeft", false);
            }
            else if (mov.y < -0.5)
            {
                //posicion = "abajo";
                rb.GetComponent<Animator>().SetBool("osoDown", true);
                        rb.GetComponent<Animator>().SetBool("osoUp", false);
                        rb.GetComponent<Animator>().SetBool("osoRight", false);
                        rb.GetComponent<Animator>().SetBool("osoLeft", false);

            }
            else if (mov.y > 0.5)
            {
             //   posicion = "arriba";
                rb.GetComponent<Animator>().SetBool("osoUp", true);
                        rb.GetComponent<Animator>().SetBool("osoDown", false);
                        rb.GetComponent<Animator>().SetBool("osoRight", false);
                        rb.GetComponent<Animator>().SetBool("osoLeft", false);
            }
        }
    }



    IEnumerator dying()
    {



        if (GameObject.FindWithTag("checkpoint").GetComponent<CheckPointValidator>().checkpoint_forest)
        {

            Debug.Log("checkpointforest activo");

            Time.timeScale = 0;
            varGameObject.GetComponent<PlayerController>().enabled = false;


           
            yield return new WaitForSecondsRealtime(0.3f);

           /* varGameObject.GetComponent<Transform>().Translate(17f, -5, 0.01f);

            Time.timeScale = 1f;
            varGameObject.GetComponent<PlayerController>().enabled = true; */



            SceneManager.LoadScene("ForestPuzzle2");
        }
        
        if (!checkpoint_forest){

        
        alive = false;


        Time.timeScale = 0;
        varGameObject.GetComponent<PlayerController>().enabled = false;

        gameObject.GetComponent<AudioSource>().Play();

        yield return new WaitForSecondsRealtime(0.3f);

        Time.timeScale = 1f;

        SceneManager.LoadScene("ForestPuzzle1");

        }
    }


}
