using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    public float theDistance;
    public GameObject actionKey;
    public GameObject medkitBox;
    PlayerHealth player;
    public GameObject fullHealthText;

    public void Start()
    {
        player = FindObjectOfType<PlayerHealth>();
    }

    void Update()
    {
        theDistance = Player.distanceFromTarget;

    }

    void OnMouseOver()
    {
        if (theDistance <= 5)
        {
            if(player.currentHealth == 100)
            {
                actionKey.SetActive(false);
                fullHealthText.SetActive(true);
               
            }
            else if (player.currentHealth < 100)
            {
                actionKey.SetActive(true);
            }
        }
       
        else
        {
            actionKey.SetActive(false);

        }

        if (Input.GetButton("Action"))
        {
            if (theDistance <= 5)
            {
                if (player.currentHealth < 100)
                {
                    player.currentHealth += 25;
                    player.UpdateText();
                    player.healthBarSlider.value += 25;

                    actionKey.SetActive(false);

                    Destroy(medkitBox);
                }
            }
        }
    }

    void OnMouseExit()
    {
        actionKey.SetActive(false);
        fullHealthText.SetActive(false);
    }

   
}
