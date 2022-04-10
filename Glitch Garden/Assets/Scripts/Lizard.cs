using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherObject = other.gameObject;
        if (IsDefender(otherObject))
            GetComponent<Attacker>().Attack(otherObject);
    }

    private bool IsDefender(GameObject otherObject) => otherObject.GetComponent<Defender>() != null;
}
