using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class Train : MonoBehaviour
{
    public AudioSource TrainSoundSource;
    public bool awake;

    // Start is called before the first frame update
    void Start()
    {
        TrainSoundSource = GetComponent<AudioSource>();
        TrainSoundSource.enabled = false;
    }


    private void onTriggerEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Choo Choo Noise")
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
