using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public void NextScene()
    {
        Debug.Log("Next Scene");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
