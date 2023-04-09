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
            if (pausePanel.activeSelf)
            {
                Continue();
            }
            else
            {
                pausePanel.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    IEnumerator MenuDelay()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
    public void MainMenu()
    {
        clickSource.PlayOneShot(clickClips[Random.Range(0, clickClips.Length)]);
        StartCoroutine(MenuDelay());
    }
    public void Continue()
    {
        clickSource.PlayOneShot(clickClips[Random.Range(0, clickClips.Length)]);
        pausePanel.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    
    public void Quit()
    {
        clickSource.PlayOneShot(clickClips[Random.Range(0, clickClips.Length)]);
        Application.Quit();
    }
}
