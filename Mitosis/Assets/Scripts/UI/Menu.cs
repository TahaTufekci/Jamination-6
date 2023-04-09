using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] AudioSource clickSource;
    [SerializeField] AudioClip[] clickClips;
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
    public void Quit()
    {
        clickSource.PlayOneShot(clickClips[Random.Range(0, clickClips.Length)]);
        Application.Quit();
    }
}
