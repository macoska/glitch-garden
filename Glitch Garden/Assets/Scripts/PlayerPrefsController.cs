using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string
    MASTER_VOLUME_KEY = "master volume",
    DIFFICULTY_KEY    = "difficulty";

    const float MIN_VOLUME = 0f, MAX_VOLUME = 1f;
    const float MIN_DIFFICULTY = 0f, MAX_DIFFICULTY = 2f;

    public static void SetMasterVolume(float volume)
    {
        if (MIN_VOLUME <= volume && volume <= MAX_VOLUME)
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        else
            Debug.LogError("Master volume is out of range");
    }
    public static float GetMasterVolume() => PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);

    public static void SetDifficulty(float difficulty)
    {
        if (MIN_DIFFICULTY <= difficulty && difficulty <= MAX_DIFFICULTY)
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        else
            Debug.LogError("Difficulty is out of range");
    }
    public static float GetDifficulty() => PlayerPrefs.GetFloat(DIFFICULTY_KEY);
}
