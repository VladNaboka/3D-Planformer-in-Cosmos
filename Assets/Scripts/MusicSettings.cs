using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSettings : MonoBehaviour
{
    public void SetVolume(float volume)
    {
        AudioListener.volume  = volume;
    }
}
