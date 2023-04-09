using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] AudioSource clickSource;
    [SerializeField] AudioClip[] clickClips;
    [SerializeField] GameObject gameOverPanel;
    
    public void MainMenu()
    {
        clickSource.PlayOneShot(clickClips[Random.Range(0, clickClips.Length)]);
        StartCoroutine(MenuDelay());
    }
    IEnumerator MenuDelay()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
    public void Restart()
    {
        clickSource.PlayOneShot(clickClips[Random.Range(0, clickClips.Length)]);
        StartCoroutine(RestartDelay());
        Time.timeScale = 1;
    }
    IEnumerator RestartDelay()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("SampleScene");
    }
    public void Quit()
    {
        clickSource.PlayOneShot(clickClips[Random.Range(0, clickClips.Length)]);
        Application.Quit();
    }
}
