using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BInFind : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    public int numberOfBins { get; private set; }

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("hi");
     
                source.PlayOneShot(clip);
            gameObject.SetActive(false);
        }
    }

    public void BinFound()
    {
        numberOfBins++;
    }
}
