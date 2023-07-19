using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class trashBinInteract : MonoBehaviour
{

    public AudioSource RaccoonNoise;


    public GameObject interact;
    public GameObject Bin;

    


    private bool isPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        interact.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
             if (Input.GetKey(KeyCode.E))
            {
                RaccoonNoise.Play();
            }    
            interact.SetActive(true); 
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            interact.SetActive(false);
        }
    }
}


