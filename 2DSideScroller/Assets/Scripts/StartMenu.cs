using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    private AudioSource startSound;

    private void Start()
    {
        startSound = GetComponent<AudioSource>();
    }
    public void StartGame()
    {
        startSound.Play();
        Invoke("StartLevel", 0.256f);
    }

    private void StartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
