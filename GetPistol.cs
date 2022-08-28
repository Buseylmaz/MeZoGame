using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPistol : MonoBehaviour
{
    public float theDistance;
    public GameObject actionKey;
    public GameObject pistol;
    public GameObject realPistol;
    public GameObject ammoPanel;
   
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
                realPistol.SetActive(true);
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
                actionKey.SetActive(false);
                ammoPanel.SetActive(true);
                Destroy(pistol);
               
            }
        }
    }

    void OnMouseExit()
    {
        actionKey.SetActive(false);

    }


}
