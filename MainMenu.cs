using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public float delayInSeconds = 1f;
    [Header("Menu SFX")]
    public AudioSource startSound;
    GameInfo gameinfo;

    public void PlayGame()
    {
        gameinfo = FindObjectOfType<GameInfo>();
        Destroy(gameinfo);
        StartCoroutine(WaitAndLoadGame());
        //SceneManager.LoadScene(1);
    }

    IEnumerator WaitAndLoadGame()
    {
        startSound.Play();
        yield return new WaitForSeconds(delayInSeconds); // waits for delayInSeconds before loading
        SceneManager.LoadScene(1); // loads the main game over screen from build settings
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0); // loads the main menu screen
    }

    public void QuitGame()
    {
        Debug.Log("Quitting the game");
        Application.Quit();
    }
}
