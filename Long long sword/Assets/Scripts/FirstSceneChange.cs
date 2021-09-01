using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;







public class FirstSceneChange : MonoBehaviour
{
    public Image blackFade;

    GameObject varGameObject;


    void Start()
    {
        blackFade.canvasRenderer.SetAlpha(0.0f);
        varGameObject = GameObject.FindWithTag("Player");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

       
            StartCoroutine(endOfScene());
       

    }




    IEnumerator endOfScene()
    {

        varGameObject.GetComponent<PlayerController>().enabled = false;
        blackFade.CrossFadeAlpha(1, 2, false);
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("Inicio2");
    }
}
