using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    public AudioSource fx;
    public AudioClip hoverFx;
    public AudioClip clickFx;

    public void HoverSound()
    {
        fx.PlayOneShot(hoverFx);
    }

    public void ClickSound()
    {
        fx.PlayOneShot(clickFx);
    }
}
