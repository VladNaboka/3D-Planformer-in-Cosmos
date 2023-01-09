using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    Rigidbody rb;
    float moveX;
    Vector3 move;
    bool isGround;

    public int score;
    public Text scoreCoins;

    bool activPlus90;
    bool activMinus90;

    public Image energy;

    public Animator animDead;
    PlayerControllers plContr;

    public GameObject win;

    public AudioSource turbineSound;
    public AudioSource nullEnergy;
    public AudioSource winSound;
    public bool activatorMenu;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        plContr = GameObject.Find("Player").GetComponent<PlayerControllers>();
        win.SetActive(false);
        activatorMenu = true;
    }
    private void Update()
    {
        //cameraD.transform.LookAt(gameObject.transform.position);
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.AddForce(0, 500, 0);
        }
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene("Game");
        Controller(true);
    }
    void FixedUpdate()
    {
        Energy();
    }
    void Energy()
    {
        energy.fillAmount -= 0.03f * Time.fixedDeltaTime;
        if (energy.fillAmount == 0)
        {
            nullEnergy.Play();
            plContr.animDead.SetFloat("AcDead", 1);
            plContr.playerScript.enabled = false;
            plContr.activatorDarkening = true;
        }
        //gameObject.SetActive(false);
    }
    void Controller(bool activC)
    {
        if(activC == true)
        {
            moveX = Input.GetAxis("Horizontal");
            if(Input.GetAxis("Horizontal") == 0)
                turbineSound.Play();

            //move = Vector3.forward * moveX * speed;
            if (moveX < 0)
            {
                move = -Vector3.forward * moveX * speed;
                gameObject.transform.rotation = Quaternion.Euler(10, 90, 0);
                activPlus90 = true;
                activMinus90 = false;
                transform.Translate(move * Time.deltaTime);
            }
            if (moveX > 0)
            {
                move = Vector3.forward * moveX * speed;
                gameObject.transform.rotation = Quaternion.Euler(10, -90, 0);
                activPlus90 = false;
                activMinus90 = true;
                transform.Translate(move * Time.deltaTime);
            }

            if (moveX == 0 && activMinus90)
                gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);
            if (moveX == 0 && activPlus90)
                gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
            //transform.Translate(move * Time.fixedDeltaTime);
            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isGround = true;
        }
        if (collision.gameObject.CompareTag("Win"))
        {
            winSound.Play();
            win.SetActive(true);
            plContr.activatorDarkening = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isGround = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            score++;
            scoreCoins.text = score.ToString();
        }
        if (other.gameObject.CompareTag("Energy"))
        {
            energy.fillAmount = 1f;
        }
    }
}
