using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouse : MonoBehaviour
{
    public AudioSource sound;
    private void OnMouseDown()
    {
        sound.Play();
    }
}
