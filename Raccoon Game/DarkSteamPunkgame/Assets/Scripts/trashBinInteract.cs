using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class trashBinInteract : MonoBehaviour
{

  //  public AudioSource source;
 //   public AudioClip clip;


    public GameObject interact;

   


    
    // Start is called before the first frame update
    void Start()
    {
        interact.SetActive(false);
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("hi");
            interact.SetActive(true); 

          //   if (Input.GetKeyDown(KeyCode.E))
          //  {
          //      Debug.Log("Sounds?");
          //      source.PlayOneShot(clip);
              
          //  }    
            
           
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


