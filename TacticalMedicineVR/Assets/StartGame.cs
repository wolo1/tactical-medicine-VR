using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 


public class StartGame : MonoBehaviour
{
    public void StartMainScene()
    {
        SceneManager.LoadScene(0); // Loads the first scene in Build Settings
    }
}
