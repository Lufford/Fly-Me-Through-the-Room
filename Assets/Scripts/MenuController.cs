using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Button MainMenu;
    
    public void OnMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
