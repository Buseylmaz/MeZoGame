using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGateKey : MonoBehaviour
{
    public float theDistance;
    public GameObject actionKey;
    public GameObject takenKey;
    public AudioSource gateSound;

    public bool keyTaken;
    public GameObject key;
   


    void Start()
    {
        keyTaken = false;
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
            
        }
        else
        {
            actionKey.SetActive(false);
           
        }

        if (Input.GetButton("Action"))
        {
            if (theDistance <= 2)
            {
                keyTaken = true;
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
                actionKey.SetActive(false);
                takenKey.SetActive(true);
                StartCoroutine(KeyTakenText());
                gateSound.Play();
                key.GetComponent<MeshRenderer>().enabled = false;
               
            }
        }
    }

    void OnMouseExit()
    {
        actionKey.SetActive(false);
        
    }

    IEnumerator KeyTakenText()
    {
        yield return new WaitForSeconds(2f);
        takenKey.SetActive(false);
    }
}
