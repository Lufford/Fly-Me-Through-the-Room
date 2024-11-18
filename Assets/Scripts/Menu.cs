
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //Start
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