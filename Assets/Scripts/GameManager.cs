
using System.Collections;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public GameObject Enemy, Crumb, pausePanel, pauseTimer;
    private float spawnRate = 0f;
    private float spawnTime = 0f;
    private float crumbSpawnTime = 0f;
    private float crumbSpawnRate = 0f;
    private int spawnAmount = 0;
    public int totalScore = 0;
    private bool gameIsPaused = false;
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
        if (Input.GetKeyDown(KeyCode.Escape))
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
        while(i > 0)
        {
            pauseTimeText.text = "Resume in " + i.ToString() + " seconds";
            yield return new WaitForSecondsRealtime(1f);
            i--;
        }
        pauseTimer.SetActive(false);
        Time.timeScale = 1f;
    }
    private void Start()
    {
        Time.timeScale = 1f;
    }
    private void Update()
    {
        SpawnEnemy(); 
        SpawnCrumb();
        PauseGame();
    }
}
