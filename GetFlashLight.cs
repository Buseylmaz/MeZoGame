using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFlashLight : MonoBehaviour
{
    public float theDistance;
    public GameObject actionKey;
    public GameObject getFlashText;
    public bool flashTaken;
    public GameObject flashLight;
    public GameObject realFlashLight;
    public GameObject flashActivition;
    public GameObject message;


    void Start()
    {
        flashTaken = false;
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
                flashTaken = true;
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
                actionKey.SetActive(false);
                getFlashText.SetActive(true);
                flashActivition.SetActive(true);
                message.SetActive(true);
                StartCoroutine(KeyTakenText());
                flashLight.GetComponent<MeshRenderer>().enabled = false;
                realFlashLight.SetActive(true);

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
        getFlashText.SetActive(false);
        yield return new WaitForSeconds(4f);
        flashActivition.SetActive(false);
        yield return new WaitForSeconds(4f);
        message.SetActive(false);
    }
}
