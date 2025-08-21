using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip backgroundMusic;

    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
        audioSource.Stop();
    }

    public void Start()
    {
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.Play();
    }
}
