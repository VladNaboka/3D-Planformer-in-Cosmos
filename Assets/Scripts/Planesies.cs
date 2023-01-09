using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Planesies : MonoBehaviour
{
    public GameObject[] planes;
    private void Start()
    {
        planes = GameObject.FindGameObjectsWithTag("Planes");
    }
    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i <= planes.Length - 1; i++)
        {
            if (other.gameObject.transform.position == planes[i].transform.position)
            {
                gameObject.transform.SetParent(planes[i].transform);
                Camera.main.transform.SetParent(planes[i].transform);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i <= planes.Length - 1; i++)
        {
            if (other.gameObject.transform.position == planes[i].transform.position || Input.GetButtonDown("Jump"))
            {
                gameObject.transform.SetParent(null);
                Camera.main.transform.SetParent(null);
            }
        }
    }
}
