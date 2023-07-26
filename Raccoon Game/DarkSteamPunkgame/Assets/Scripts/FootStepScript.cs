
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepScript : MonoBehaviour
{
   public AudioSource walking, Running;

    void Update()
    {
 

        if ( Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            walking.enabled = true;

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                walking.enabled = false;
                Running.enabled = true;
            }
            else
            {
                Running.enabled = false;
            }
        }
        else
        {
            walking.enabled = false;
            Running.enabled = false;
        }
    }
}