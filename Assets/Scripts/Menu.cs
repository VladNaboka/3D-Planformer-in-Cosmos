using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public Player playerScript;
    public CameraController cameraController;
    public GameObject energy;
    public GameObject score;
    public GameObject setting;

    public AudioSource soundStart;

    public GameObject pMenu;

    public GameObject nameGame;
    private void Awake()
    {
        playerScript.enabled = false;
        cameraController.enabled = false;
        energy = GameObject.Find("Energy");
        score = GameObject.Find("ScoreMoney");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && playerScript.activatorMenu == false)
        {
            setting.SetActive(!setting.activeSelf);
        }
    }
    private void Start()
    {
        energy.SetActive(false);
        score.SetActive(false);
    }
    public void ActivPlayer()
    {
        soundStart.Play();
        playerScript.enabled = true;
        cameraController.enabled = true;
        gameObject.SetActive(false);
        energy.SetActive(true);
        score.SetActive(true);
        nameGame.SetActive(false);
    }
    public void Exit()
    {
        soundStart.Play();
        Application.Quit();
    }
    public void Setting()
    {
        setting.SetActive(!setting.activeSelf);
    }
    public void LowQuality()
    {
        QualitySettings.SetQualityLevel(0, true);
    }
    public void MediumQuality()
    {
        QualitySettings.SetQualityLevel(2, true);
    }
    public void UltraQuality()
    {
        QualitySettings.SetQualityLevel(4, true);
    }
}
