using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    Animator myAnimator;

    void Start() => myAnimator = GetComponent<Animator>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherObject = other.gameObject;
        if (IsGravestone(otherObject))
            myAnimator.SetTrigger("jumpTrigger");
        else if (IsDefender(otherObject))
            GetComponent<Attacker>().Attack(otherObject);
    }

    private bool IsDefender(GameObject otherObject) => otherObject.GetComponent<Defender>() != null;
    private bool IsGravestone(GameObject otherObject) => otherObject.GetComponent<Gravestone>() != null;
}
