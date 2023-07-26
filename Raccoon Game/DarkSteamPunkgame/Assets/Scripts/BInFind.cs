using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BInFind : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("hi");
     
                source.PlayOneShot(clip);
        }
    }
}
