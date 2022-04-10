using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollider : MonoBehaviour
{
    LivesDisplay healthDisplay;

    void Start() => healthDisplay = FindObjectOfType<LivesDisplay>();

    void OnTriggerEnter2D(Collider2D other)
    {
        Attacker attacker = other.GetComponent<Attacker>();
        if (attacker)
            healthDisplay.Decrease1Life();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Attacker attacker = other.GetComponent<Attacker>();
        if (attacker)
            Destroy(attacker.gameObject);
    }
}
