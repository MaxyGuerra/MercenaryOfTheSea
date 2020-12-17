using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

 
    public class UISceneLoader : MonoBehaviour
    {

       
        public int sceneIndex;

        
     
        // Start is called before the first frame update
        public void GameManagerLoadScene()
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
 

