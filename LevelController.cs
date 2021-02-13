using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public float delayInSeconds = 3f;
    
    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoadGameOver());
    }
    
    public void LoadWinGame()
    {
        StartCoroutine(WaitAndLoadWinGame());
    }

    IEnumerator WaitAndLoadGameOver()
    {
        yield return new WaitForSeconds(delayInSeconds); // waits for delayInSeconds before loading
        SceneManager.LoadScene(2); // loads the main game over screen from build settings
    }
    
    IEnumerator WaitAndLoadWinGame()
    {
        yield return new WaitForSeconds(delayInSeconds); // waits for delayInSeconds before loading
        SceneManager.LoadScene(3); // loads the main game over screen from build settings
    }
}
