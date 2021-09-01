using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleSoundEvent : MonoBehaviour
{
    public AudioSource audio1Thumping;
    public AudioSource audio2Glass;

    public AudioSource audio3Water;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("bottle"))
        {

        
        Debug.Log("botella ha caído");

        StartCoroutine(playSounds());
        }


    }
    IEnumerator playSounds()
    {

        Debug.Log("cae");
        yield return new WaitForSeconds(2.5f);
        audio2Glass.Play();
      

        yield return new WaitForSeconds(1);

        audio1Thumping.Play();

   

        yield return new WaitForSeconds(2);

        audio3Water.Play();

    }


}
