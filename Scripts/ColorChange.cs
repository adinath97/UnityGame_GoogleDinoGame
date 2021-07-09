using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
     
     public Color color1 = Color.black;
     public Color color2 = Color.white;
     private Color lerpingColor;
     public float duration = 3f;
     private float deltaTime = 0.0f, cap = 25.0f, step;
     
     void Start () 
     {
         color1 = Color.black;
         color2 = Color.white;
         duration = 3f;
         deltaTime = 0.0f;
     }
     
     void Update () 
     {
        deltaTime += Time.deltaTime;
        if(deltaTime > cap)
        {
            deltaTime = 0f;
            StartCoroutine(LerpColorsOverTime(color1,color2,duration));
            //Color tempColor = color1;
            //color1 = color2;
            //color2 = tempColor;
        }
     }

     private IEnumerator LerpColorsOverTime(Color startingColor, Color endingColor, float time)
    {
        float inversedTime = 1 / time ; // Compute this value **once**
        for( step = 0.0f; step < 1.0f ; step += Time.deltaTime * inversedTime )
        {
            lerpingColor = Color.Lerp(color1, color2, step);
            GetComponent<Camera>().backgroundColor = lerpingColor;
            yield return null ;
        }
        Color tempColor = color1;
        color1 = color2;
        color2 = tempColor;
    }

}
