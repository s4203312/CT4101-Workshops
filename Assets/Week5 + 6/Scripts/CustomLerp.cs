using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomLerp : MonoBehaviour{

    //Creates a list of eases that are displayed in the inspector
    public enum eases {     
        easeInSine, easeOutSine
    }
    public eases myEase;

    //Variables
    bool lerping;
    float lerpFloat;
    float xPos;
    public bool xMove;
    public float duration = 3;

    public void LerpButton(){
        if (lerping == false){
            StartCoroutine(LerpFloat(myEase));
        }
    }
    
    //Important code!!!!!!!!
    IEnumerator LerpFloat(eases ease){
        lerping = true;
        float time = 0;
        while (time < 1){        //While loop to continuously run this code until 1 second has passed
            float perc = 0;
            if (ease == eases.easeInSine){                          //Checks which ease is selected
                perc = 1f - Mathf.Cos(time * Mathf.PI * 0.5f);
            }
            else if (ease == eases.easeOutSine){
                perc = Mathf.Sin(time * Mathf.PI * 0.5f);
            }
            lerpFloat = Lerp(0, 10, perc);
            time += Time.deltaTime / duration;
            yield return null;
        }
        lerping = false;
    }
    public static float Lerp(float StartValue, float endValue, float t){    //Setting Lerp to a function to reduce code duplication
        return (StartValue + ( endValue - StartValue ) * t);        //The Lerp formula
    }

    void Update(){

        if (lerping && xMove){          //Moving the cube on the x-axis
            xPos += Time.deltaTime;
        }
        
        transform.position = new Vector3(xPos, 0, lerpFloat);  //Changing the position of the cube every frame
    }
}
