using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginningGate : MonoBehaviour
{
    Animator anim;
    public AudioSource gateSound;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            anim.SetBool("Gate", true);
            gateSound.Play();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            anim.SetBool("Gate", false);
            gateSound.Play();
        }
    }
}
