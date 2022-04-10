using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab = default;

    // cached references
    SpriteRenderer sprite;
    Color colorSelected, colorUnselected;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        colorSelected = Color.white;
        colorUnselected = Color.HSVToRGB(0f, 0f, 0.25f);
        Unselect();
        LabelButtonWithCost();
    }

    void LabelButtonWithCost()
    {
        Text costText = GetComponentInChildren<Text>();
        if (!costText)
        {
            // Debug.LogError(name + " has no cost text, add some!");
        }
        else
            costText.text = defenderPrefab.GetStarCost().ToString();
    }

    void OnMouseDown()
    {
        UnselectOtherButtons();
        Select();
    }

    public void Select()
    {
        sprite.color = colorSelected;
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
    }
    public void Unselect() => sprite.color = colorUnselected;

    void UnselectOtherButtons() // Note: Also unselects THIS button
    {   
        // foreach (Transform button in transform.parent)
        //     button.GetComponent<DefenderButton>().SetUnselected();
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach (DefenderButton button in buttons)
            button.Unselect();
    }
}
