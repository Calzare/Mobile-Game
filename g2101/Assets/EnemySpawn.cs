using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform Spawnpoint;

    void OnTriggerEnter2D(Collider2D col)
    {
        enemyPrefab.SetActive(true);
        Destroy(gameObject);
    }
}
