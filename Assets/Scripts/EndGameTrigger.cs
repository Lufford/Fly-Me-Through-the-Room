using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameTrigger : MonoBehaviour
{
    public GameObject cutscene;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            GameManager.Instance.canSpawn = false;
            StartCoroutine(CutScene());
        }
    }

    private IEnumerator CutScene()
    {
        cutscene.SetActive(true);
        yield return new WaitForSecondsRealtime(3f);
        SceneController.instance.PlayGame("Game Over");
    }
}
