using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

using UnityEngine.SceneManagement;
public class ChangingSceneController : MonoBehaviour
{

 

    public Image blackFade;
    // Start is called before the first frame update
    void Start()
    {

        blackFade.canvasRenderer.SetAlpha(0.0f);
     
    }
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("5.5f para que fundido a negro");

        StartCoroutine(endOfScene());

    }

    IEnumerator endOfScene()
    {

        yield return new WaitForSeconds(7.5f);
        blackFade.CrossFadeAlpha(1, 2, false);
        yield return new WaitForSeconds(2.5f);
        
            SceneManager.LoadScene("FirstDungeon");

            Debug.Log("Cambio de escena");
        


    }

}
