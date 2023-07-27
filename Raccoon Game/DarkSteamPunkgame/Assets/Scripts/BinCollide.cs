using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinCollide : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Death");
     
                source.PlayOneShot(clip);
        }
    }
}
