using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorites : MonoBehaviour
{
    float timer = 2f;
    float timerDead = 10f;
    public GameObject player;
    bool activMeteor = false;
    public PlayerControllers playerControllers;
    public GameObject deadEffect;

    public AudioSource meteorSound;
    public AudioSource deadPlayerSound;
    private void Start()
    {
        player = GameObject.Find("Player");
        playerControllers = GameObject.Find("Player").GetComponent<PlayerControllers>();
    }
    private void Update()
    {
        if (activMeteor)
            Meteorit();
        
    }
    void Meteorit()
    {
        timer -= 1f * Time.deltaTime;
        if (timer <= 0.05f)
        {
            gameObject.transform.position = gameObject.CompareTag("Meteor") ? gameObject.transform.position -= new Vector3(0, 0, 50f * Time.deltaTime) : gameObject.transform.position -= new Vector3(0, 50f * Time.deltaTime, 0);
        }
        timerDead -= Time.deltaTime;
        if (timerDead <= 0.05f)
            Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (player.transform.position == other.gameObject.transform.position)
        {
            activMeteor = true;
            meteorSound.Play();
        }
        else
        {
            activMeteor = false;
        }
            
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            deadPlayerSound.Play();
            Instantiate(deadEffect, player.transform.position, Quaternion.identity);
            playerControllers.animDead.SetFloat("DeadPlayerBomb", 1);
            playerControllers.playerScript.enabled = false;
            playerControllers.activatorDarkening = true;
        }
    }
}
