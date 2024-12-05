using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    public int scoreValue;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    
    public void PlayGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
