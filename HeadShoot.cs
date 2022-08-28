using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadShoot : MonoBehaviour
{
    public GameObject head;

    void Start()
    {
        
    }

  
    void Update()
    {
        
    }
    public void OnDisable()
    {
        head.SetActive(false);
    }
}
