using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Pause : MonoBehaviour
{
    [SerializeField] AudioSource clickSource;
    [SerializeField] AudioClip[] clickClips;
    [SerializeField] GameObject pausePanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausePanel.gameObject.SetActive(true);
        }
    }


    public void Play()
    {
        clickSource.PlayOneShot(clickClips[Random.Range(0,clickClips.Length)]);
        StartCoroutine(StartDelay());
    }
    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("SampleScene");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void Continue()
    {
        pausePanel.gameObject.SetActive(false);
    }
    
    public void Quit()
    {
        clickSource.PlayOneShot(clickClips[Random.Range(0, clickClips.Length)]);
        Application.Quit();
    }
}
