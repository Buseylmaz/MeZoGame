using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public float theDistance;
    public GameObject actionKey;
    public GameObject openDoor;
    public GameObject hingeAnim;
    public AudioSource doorSound;

    
    void Update()
    {
        theDistance = Player.distanceFromTarget;

    }

    void OnMouseOver()
    {   
        if (theDistance<= 2)
        {
            actionKey.SetActive(true);
            openDoor.SetActive(true);
        }
        else
        {
            actionKey.SetActive(false);
            openDoor.SetActive(false);
        }

        if (Input.GetButton("Action"))
        {
            if (theDistance <= 2)
            {
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
                actionKey.SetActive(false);
                openDoor.SetActive(false);
                hingeAnim.GetComponent<Animation>().Play("Door");
                hingeAnim.GetComponent<Animation>().Play("OppositeDoor");
                doorSound.Play();
            }
        }
    }

    void OnMouseExit()
    {
        actionKey.SetActive(false);
        openDoor.SetActive(false);
    }
}
