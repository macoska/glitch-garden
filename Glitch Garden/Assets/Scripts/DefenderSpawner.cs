using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "Defenders";

    void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
    }

    public void SetSelectedDefender(Defender defender) => this.defender = defender;

    void OnMouseDown() => AttemptToPlaceDefenderAt(GetSquareClicked());

    void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        if (!defender) return;

        var starDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.GetStarCost();
        if(starDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefender(gridPos);
            starDisplay.SpendStars(defenderCost);
        }
    }

    Vector2 GetSquareClicked()
    {
        Vector2 screenPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private static Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    void SpawnDefender(Vector2 gridPos)
    {
        Defender newDefender = Instantiate(defender, gridPos, transform.rotation) as Defender;
        newDefender.transform.parent = defenderParent.transform;
    }
}
