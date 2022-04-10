using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 20, starMaxLimit = 999;
    Text starText;
    Color textColor;
    Color textLimitColor;

    void Start()
    {
        starText = GetComponent<Text>();
        textColor = new Color32(242, 255, 0, 255);
        textLimitColor = new Color32(255, 194, 0, 255);
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        starText.text = stars.ToString();
        starText.color = stars < starMaxLimit ? textColor : textLimitColor;
    }

    public bool HaveEnoughStars(int amount) => stars >= amount;

    public void AddStars(int amount)
    {
        amount = Mathf.Clamp(starMaxLimit - stars, 0, amount);
        stars += amount;
        UpdateDisplay();
    }

    public void SpendStars(int amount)
    {
        if (stars < amount) return;
        stars -= amount;
        UpdateDisplay();
    }
}
