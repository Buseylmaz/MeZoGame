using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    Light FL;
    public bool drainOverTime;
    public float maxBrightness;
    public float minBrightness;
    public float drainRate;
    public AudioSource flashAS;
    public AudioClip flashAC;


    void Start()
    {
        flashAS = GetComponent<AudioSource>();
        FL = GetComponent<Light>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            FL.enabled = !FL.enabled;
            flashAS.PlayOneShot(flashAC);
        }

        if(drainOverTime==true && FL.enabled==true)
        {
            FL.intensity = Mathf.Clamp(FL.intensity, minBrightness, maxBrightness);
            if (FL.intensity > minBrightness)
            {
                FL.intensity -= Time.deltaTime * (drainRate / 1000);
            }
        }
        else if (drainOverTime == true && FL.enabled == false)
        {
            if (FL.intensity < maxBrightness)
            {
                FL.intensity += Time.deltaTime * (drainRate / 1000);
            }
        }

    }
}
