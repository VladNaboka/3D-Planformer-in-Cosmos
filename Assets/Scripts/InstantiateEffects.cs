using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateEffects : MonoBehaviour
{
    public GameObject effect;
    public AudioSource coinOrEnergySound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            coinOrEnergySound.Play();
            Instantiate(effect, transform.position, Quaternion.identity);
        }
    }
    
}
