using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatFoodController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("rat")){


            gameObject.GetComponent<AudioSource>().Play();

            StartCoroutine(waitFunction());
    
         

        }
    }


    IEnumerator waitFunction()
    {
       
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);

    }
}
