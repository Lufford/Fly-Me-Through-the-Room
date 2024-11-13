using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //Start
    public void OnStart()
    {
        SceneManager.LoadScene(0);
    }

    //Add Controls Scene and Button Function

    //Exit
    public void OnExit()
    {
        Application.Quit();
    }
}