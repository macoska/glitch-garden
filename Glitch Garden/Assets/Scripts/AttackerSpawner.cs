using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1f, maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackerArray = default;
    bool spawn = true;

    IEnumerator Start()
    {
        while(spawn)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    public void StopSpawning() => spawn = false;

    private void SpawnAttacker()
    {
        if (attackerArray.Length == 0) return;
        var attackerIndex = UnityEngine.Random.Range(0, attackerArray.Length);
        Attacker attacker = attackerArray[attackerIndex];
        Spawn(attacker);
    }

    private void Spawn(Attacker attacker)
    {
        Attacker newAttacker = Instantiate(attacker, transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }
}