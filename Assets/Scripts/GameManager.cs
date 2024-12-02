
using System;
using System.Collections;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Enemy, Fan, BugLamp, Crumb, pausePanel, pauseTimer;
    private GameObject FanCopy, BugLampCopy;
    private float spawnRate = 0f;
    private float spawnTime = 0f;
    private float obstacleSpawnRate = 0f;
    private float obstacleSpawnTime = 0f;
    private float crumbSpawnRate = 0f;
    private float crumbSpawnTime = 0f;
    private int spawnAmount = 0;
    public int totalScore = 0;
    private bool gameIsPaused = false;
    private bool PressEscAgain = true;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text pauseTimeText;

    
    
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
    
    private void SpawnEnemy()
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

    private void SpawnFan()
    {
        obstacleSpawnRate = Random.Range(6, 12);
        if (Time.time > obstacleSpawnTime)
        {
            //Spawn Fan
            if ( Random.Range(0f, 1f) > 0.5f)
            {
                //Spawns on Left
                if (Random.Range(0f, 1f) > 0.5f)
                {
                    FanCopy = Instantiate(Fan, new Vector2(-2.15f, 6f), Quaternion.identity);
                    FanCopy.transform.localScale = new Vector2(0.5f, 0.5f);
                }
                //Spawns on Right
                else
                {
                    FanCopy = Instantiate(Fan, new Vector2(2.15f, 6f), Quaternion.identity);
                    FanCopy.transform.localScale = new Vector2(-0.5f, 0.5f);
                }
            }
            //Spawn Bug Lamp
            else
            {
                //Spawns on Left
                if (Random.Range(0f, 1f) > 0.5f)
                {
                    BugLampCopy = Instantiate(BugLamp, new Vector2(-2.17f, 6f), Quaternion.identity);
                    BugLampCopy.transform.localScale = new Vector2(-0.4f, 0.4f);
                }
                //Spawns on Right
                else
                {
                    BugLampCopy = Instantiate(BugLamp, new Vector2(2.17f, 6f), Quaternion.identity);
                    BugLampCopy.transform.localScale = new Vector2(0.4f, 0.4f);
                }
            }

            obstacleSpawnTime = Time.time + obstacleSpawnRate;
        }
    }

    private void SpawnCrumb()
    {
        crumbSpawnRate = 3;
        if (Time.time > crumbSpawnTime)
        {
            Instantiate(Crumb, new Vector3(Random.Range(-2, 2), 6f, 0f), Quaternion.identity);
            crumbSpawnTime = Time.time + crumbSpawnRate;
        }
    }

    public void AddScore(int score)
    {
        totalScore+=score;
        scoreText.text = "Score\n" + totalScore.ToString();
    }

    private void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && PressEscAgain == true)
        {
            gameIsPaused = !gameIsPaused;
            pausePanel.SetActive(gameIsPaused);
            if (gameIsPaused == false)
            {
                
                StartCoroutine(PauseCountdown(3));
            }
            else
            {
                Time.timeScale = 0f;
            }
        }
    }

    private IEnumerator PauseCountdown(int i)
    {
        pauseTimer.SetActive(true);
        PressEscAgain = false;
        while(i > 0)
        {
            pauseTimeText.text = "Resume in " + i.ToString() + " seconds";
            yield return new WaitForSecondsRealtime(1f);
            i--;
        }
        pauseTimer.SetActive(false);
        Time.timeScale = 1f;
        PressEscAgain = true;
    }

    private void Start()
    {
        Time.timeScale = 1f;
    }
    private void Update()
    {
        SpawnEnemy(); 
        SpawnFan();
        SpawnCrumb();
        PauseGame();
    }
}
