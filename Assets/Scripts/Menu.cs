
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{ 
    public void OnStart()
    {
        SceneManager.LoadScene(1);
    }

    //Add Controls Scene and Button Function

    //Exit
    public void OnExit()
    {
        Application.Quit();
    }
}