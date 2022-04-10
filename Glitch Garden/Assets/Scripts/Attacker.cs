using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)] float moveSpeed = 1f;
    GameObject currentTarget;
    Animator myAnimator;

    void Awake() => FindObjectOfType<LevelController>().AttackerSpawned();
    void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if (levelController)
            levelController.AttackerKilled();
    }
    void Start() => myAnimator = GetComponent<Animator>();

    void Update()
    {
        UpdateAnimationState();
        MoveLeft();
    }

    void UpdateAnimationState()
    {
        if (!currentTarget) // if no target in sight
            myAnimator.SetBool("isAttacking", false); // start running
    }

    void MoveLeft() => transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

    public void SetMovementSpeed(float speed) => moveSpeed = speed;

    public void Attack(GameObject target)
    {
        myAnimator.SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(int damage)
    {
        if (!currentTarget) return;

        Health health = currentTarget.GetComponent<Health>();
        if (health)
            health.DealDamage(damage);
    }
}
