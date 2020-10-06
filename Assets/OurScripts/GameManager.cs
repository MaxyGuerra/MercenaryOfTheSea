using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public void NextScene()
    {
        Debug.Log("Next Scene");
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void ReloadScene()
    {
        Debug.Log("Restart Actual Scene");
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Time.timeScale = 1;
        Application.Quit();
    }
}
