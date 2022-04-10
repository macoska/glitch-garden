using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] int baseLives = 3, livesCritical = 2;

    int lives;
    Text livesText;
    Color textColor, textCriticalColor;

    void Start()
    {
        lives = baseLives - Mathf.RoundToInt(PlayerPrefsController.GetDifficulty());
        livesText = GetComponent<Text>();
        textColor = new Color32(85, 255, 0, 255);
        textCriticalColor = new Color32(255, 81, 0, 255);
        UpdateDisplay();
        // Debug.Log("Difficulty setting currently at: " + PlayerPrefsController.GetDifficulty());
    }

    public void Decrease1Life()
    {
        if (lives <= 0) return;
        lives--;
        UpdateDisplay();
        if (lives <= 0)
            FindObjectOfType<LevelController>().HandleLoseCondition();
    }

    void UpdateDisplay()
    {
        livesText.text = lives.ToString();
        livesText.color = lives > livesCritical ? textColor : textCriticalColor;
    }
}
