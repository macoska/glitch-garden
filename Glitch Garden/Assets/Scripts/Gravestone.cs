using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravestone : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        Attacker attacker = other.GetComponent<Attacker>();

        if (attacker)
        {
            // TODO Add some sort of animation
        }
    }
}
