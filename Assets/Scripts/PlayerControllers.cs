using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControllers : MonoBehaviour
{
    public Animator animDead;
    public Player playerScript;

    public Image darkening;

    public bool activatorDarkening = false;

    public GameObject deadPlane;
    float timer = 4f;
    Meteorites scMeteorites;
    private void Start()
    {
        scMeteorites = GameObject.Find("Meteorites").GetComponent<Meteorites>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Danger"))
        {
            scMeteorites.deadPlayerSound.Play();
            animDead.SetFloat("DeadPlayerBomb", 1);
            playerScript.enabled = false;
            activatorDarkening = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.transform.position == deadPlane.transform.position)
        //    activatorDarkening = true;
        if (other.gameObject.CompareTag("Danger"))
        {
            animDead.SetFloat("DeadPlayerBomb", 1);
            playerScript.enabled = false;
            activatorDarkening = true;
        }
    }
    private void Update()
    {
        if(activatorDarkening)
            darkening.color = new Color(darkening.color.r, darkening.color.g, darkening.color.b, darkening.color.a + 0.3f * Time.deltaTime);
        if (activatorDarkening)
        {
            timer -= Time.deltaTime;
            if (timer <= 0.1f)
                SceneManager.LoadScene("Game");
        }
    }
}
