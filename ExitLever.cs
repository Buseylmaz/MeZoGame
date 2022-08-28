using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLever : MonoBehaviour
{
    public float theDistance;
    public GameObject actionKey;
    public GameObject exitLeverText;
    

    void Update()
    {
        theDistance = Player.distanceFromTarget;

    }

    void OnMouseOver()
    {
        if (theDistance <= 2)
        {
            actionKey.SetActive(true);
            exitLeverText.SetActive(true);
        }
        else
        {
            actionKey.SetActive(false);
            exitLeverText.SetActive(false);
        }

        if (Input.GetButton("Action"))
        {
            if (theDistance <= 2)
            {
                SceneManager.LoadScene(2);
            }
        }
    }

    void OnMouseExit()
    {
        actionKey.SetActive(false);
        exitLeverText.SetActive(false);
    }
}
