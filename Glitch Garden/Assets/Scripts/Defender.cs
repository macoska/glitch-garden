using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int starCost = 20;

    public int GetStarCost() => starCost;
    public void AddStars(int amount) => FindObjectOfType<StarDisplay>().AddStars(amount);
}