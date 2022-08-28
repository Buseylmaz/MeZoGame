using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleGate : MonoBehaviour
{
    public float theDistance;
    public GameObject actionKey;
    public GameObject needKey;
    public GameObject middleGateAnim;
    public AudioSource gateSound;
    GetGateKey key;
    void Start()
    {
        key = FindObjectOfType<GetGateKey>();
    }


    void Update()
    {
        theDistance = Player.distanceFromTarget;

    }

    void OnMouseOver()
    {
        if (theDistance <= 2)
        {
            actionKey.SetActive(true);
            needKey.SetActive(true);
        }
        else
        {
            actionKey.SetActive(false);
            needKey.SetActive(false);
        }

        if (Input.GetButton("Action") && key.keyTaken==true)
        {
            if (theDistance <= 2)
            {
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
                actionKey.SetActive(false);
                needKey.SetActive(false);
                middleGateAnim.GetComponent<Animation>().Play("MiddleGate");
                gateSound.Play();
            }
        }
    }

    void OnMouseExit()
    {
        actionKey.SetActive(false);
        needKey.SetActive(false);
    }
}
