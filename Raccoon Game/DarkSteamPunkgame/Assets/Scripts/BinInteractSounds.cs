using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class BinInteractSounds : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("hi");
           

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Sounds?");
                source.PlayOneShot(clip);

            }


        }
    }
}
