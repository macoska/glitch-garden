using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] Projectile projectile = default;
    [SerializeField] GameObject gun = default;

    // state variables
    AttackerSpawner myLaneSpawner;
    Animator myAnimator;
    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";

    void Start()
    {
        SetLaneSpawner();
        myAnimator = GetComponent<Animator>();
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
    }

    void Update()
    {
        bool isAttacking = IsAttackerInLane();
        myAnimator.SetBool("isAttacking", isAttacking);
    }

    bool IsAttackerInLane() => myLaneSpawner.transform.childCount > 0;

    void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners)
        {
            bool IsCloseEnough = Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon;
            if (IsCloseEnough)
                myLaneSpawner = spawner;
        }
    }

    public void Fire()
    {
        Projectile newProjectile = Instantiate(projectile, gun.transform.position, gun.transform.rotation) as Projectile;
        newProjectile.transform.parent = projectileParent.transform;
    }
}
