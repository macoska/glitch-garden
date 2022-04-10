using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 20;

    [Header("FX")]
    [SerializeField] GameObject deathVFX = default;
    [SerializeField] AudioClip deathSFX = default;
    [SerializeField] [Range(0f,1f)] float volumeSFX = 1f;

    // cached references
    Collider2D myCollider;

    void Start()
    {
        myCollider = GetComponent<Collider2D>();
    }

    public void DealDamage(int damage)
    {
        damage = Mathf.Clamp(damage, 0, health);
        health -= damage;
        if (health <= 0)
            Die();
    }

    void Die()
    {
        TriggerDeathFX();
        Destroy(gameObject);
    }

    void TriggerDeathFX()
    {
        if(deathSFX) AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, volumeSFX);
        if(deathVFX)
        {
            var position = (Vector2)transform.position;
            if (myCollider) position += myCollider.offset; // put VFX onto enemy center (= collider center)
            var VFX = Instantiate(deathVFX, position, transform.rotation);
            Destroy(VFX, 1f);
        }
    }
}
