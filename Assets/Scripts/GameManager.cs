using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance != null)
            {
                return instance;
            }
            instance = FindObjectOfType(typeof(GameManager)) as GameManager;
            if (instance == null)
            {
                Debug.Log("Game Manager not found");
            }

            return instance;
        }
    }
}
