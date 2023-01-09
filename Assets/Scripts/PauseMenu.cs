using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pMenu;
    public Player playerScript;

    GameObject player;
    private void Start()
    {
        player = GameObject.Find("Player");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && playerScript.activatorMenu)
        {
            pMenu.SetActive(!pMenu.activeSelf);
            playerScript.turbineSound.Stop();
            if (pMenu.activeSelf)
            {
                playerScript.enabled = false;
                player.GetComponent<Rigidbody>().isKinematic = true;
            }
            else
            {
                playerScript.enabled = true;
                player.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
}
