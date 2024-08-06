using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISFX : MonoBehaviour
{
    //REFERENCES//
    public AudioSource sfxSource;
    public AudioManager audioManager;

    //Called on the PointerEnter EventTrigger
    //Plays the SFX for hovering over a UI button 
    //when hovering over a Button in a Menu.
    public void PlayHover()
    {
        sfxSource.PlayOneShot(audioManager.UIHover);
    }

    //Called on the PointerDown EventTrigger
    //Plays the Click SFX when clicking a Button in a Menu
    public void PlayClick()
    {
        sfxSource.PlayOneShot(audioManager.UIClick);
    }
}
