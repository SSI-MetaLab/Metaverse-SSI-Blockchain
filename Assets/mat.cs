using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mat : MonoBehaviour
{
    public Material mater; // this is the mat you want the hands changed to.


    private GameObject handLeft;
    private GameObject handRight;

    //
    void Update()
    {
        // find and grab the hand objects
            handRight = GameObject.Find("hand_right_renderPart_0");
            handLeft = GameObject.Find("hand_left_renderPart_0");

                    // if i've found the hands change the texture
            if(handRight !=null && handLeft !=null)
            {
                handLeft.GetComponent<Renderer>().material = mater;
                handRight.GetComponent<Renderer>().material = mater;
            // remove this script so it stops running.
            }
    
    }
}
