using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Level Timer in SECONDS")]
    [SerializeField] float levelTime = 10f;
    bool triggeredLevelFinished = false;

    void Update()
    {
        if (triggeredLevelFinished) return;

        // Set slider
        Slider slider = GetComponent<Slider>();
        if (slider)
            slider.value = Time.timeSinceLevelLoad / levelTime;

        // Check if timer finished
        bool timerFinished = Time.timeSinceLevelLoad >= levelTime;
        if (timerFinished)
        {
            triggeredLevelFinished = true;
            FindObjectOfType<LevelController>().LevelTimerFinished();
        }
    }
}
