using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClose : MonoBehaviour
{

    public float theDistance;
    public GameObject actionKey;
    public GameObject lockDoor;
    public AudioSource doorSound;
    public float waitTime;


    void Update()
    {
        theDistance = Player.distanceFromTarget;

    }

    void OnMouseOver()
    {
        if (theDistance <= 2)
        {
            actionKey.SetActive(true);
           
        }
        else
        {
            actionKey.SetActive(false);
           
        }

        if (Input.GetButton("Action"))
        {
            if (theDistance <= 2)
            {
               
                actionKey.SetActive(false);
                lockDoor.SetActive(true);
                StartCoroutine(ClosedDoor());
                doorSound.Play();
            }
        }
    }

    void OnMouseExit()
    {
        actionKey.SetActive(false);
        
    }

    IEnumerator ClosedDoor()
    {
        yield return new WaitForSeconds(waitTime);
        lockDoor.SetActive(false);
    }
}
