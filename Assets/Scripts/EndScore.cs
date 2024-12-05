using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScore : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private int score;
    

    private void Start()
    {
        score = SceneController.instance.scoreValue;
        scoreText.text = "Score\n" + score.ToString();
    }
}
