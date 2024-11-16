using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Button MainMenu;
    void Start()
    {
        MainMenu.onClick.AddListener(MainMenuClicked);
    }

    private void MainMenuClicked()
    {
        SceneController.instance.PlayGame("Main Menu");
    }
}
