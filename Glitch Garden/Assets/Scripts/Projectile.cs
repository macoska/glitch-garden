using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] int damage = 0;
    [SerializeField] float moveSpeed = 1f, rotateSpeed = -360f;
    [SerializeField] bool destroyWhenHit = true;

    void Update() => MoveAndRotate();

    private void MoveAndRotate()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (IsAttacker(other))
        {
            Health healthComponent = other.GetComponent<Health>();
            if (healthComponent) healthComponent.DealDamage(damage);
            if (destroyWhenHit) Destroy(gameObject);
        }
    }

    private bool IsAttacker(Collider2D other) => other.GetComponent<Attacker>() != null;
}
