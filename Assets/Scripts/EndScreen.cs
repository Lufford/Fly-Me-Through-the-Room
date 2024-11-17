using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    //Start
    public void OnReturn()
    {
        SceneManager.LoadScene(1);
    }
}
