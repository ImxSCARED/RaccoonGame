using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainSounds : MonoBehaviour
{
    public AudioSource Source;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if(gameObject.tag == "Player")
        {
            Source.PlayOneShot(clip);
        }
    }
}
