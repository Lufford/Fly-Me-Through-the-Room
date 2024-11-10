using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public GameObject Enemy;
    private float spawnRate = 0f;
    private float spawnTime = 0f;
    private int spawnAmount = 0;
    
    
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
    
    private void spawnEnemy()
    {
        spawnRate = Random.Range(5, 10);
        spawnAmount = Random.Range(1, 4);
        if (Time.time > spawnTime)
        {
            for (int i = spawnAmount; i <= 4; i++)
            {
                Instantiate(Enemy, new Vector3(Random.Range(-2,2), Random.Range(6,15), 0f), Quaternion.identity);
            }
            
            spawnTime = Time.time + spawnRate;
        }
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        spawnEnemy();
    }
}
