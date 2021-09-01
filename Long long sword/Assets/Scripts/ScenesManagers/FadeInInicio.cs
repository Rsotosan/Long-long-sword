using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FadeInInicio : MonoBehaviour
{

    public Image blackFade;

    // Start is called before the first frame update
    void Start()
    {

        blackFade.canvasRenderer.SetAlpha(0.0f);
        black();

    }
    void Update()
    {

    }



    private void black()
    {

       
        blackFade.CrossFadeAlpha(1, 2, false);
    

     



    }
}
