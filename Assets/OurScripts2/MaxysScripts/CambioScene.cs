using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioScene : MonoBehaviour
{
    public int numeroEscena;

    public void NextScene()
    {
        SceneManager.LoadScene(numeroEscena);
    }
}

