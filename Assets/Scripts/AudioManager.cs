using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public bool isMusicEnabled = true;
    public GameObject boton1, boton2;

    public void SoundOn()
    {
        boton1.SetActive(true);
        boton2.SetActive(false);
        AudioListener.volume = 1f;
    }  

    public void SoundOff()
    {
        boton2.SetActive(true);
        boton1.SetActive(false);
        AudioListener.volume = 0f;
    }
}
