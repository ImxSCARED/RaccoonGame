using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDeathAudio : MonoBehaviour
{
    public AudioSource playSound;


    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            playSound.Play();
            Debug.Log("Raccoon has died rip");


        }

    }



}
