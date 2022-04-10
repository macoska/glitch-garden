using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel = default;
    [SerializeField] GameObject loseLabel = default;
    [SerializeField] float loadDelay = 5f;

    int numberOfAttackers = 0;
    bool levelTimerFinished = false;

    void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    public void AttackerSpawned() => numberOfAttackers++;

    public void AttackerKilled()
    {
        numberOfAttackers--;
        if (numberOfAttackers <= 0 && levelTimerFinished)
        {
            // Debug.Log("End Level now!");
            StartCoroutine(HandleWinCondition());
        }
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(loadDelay);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }

    void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnerArray)
            spawner.StopSpawning();
    }
}
