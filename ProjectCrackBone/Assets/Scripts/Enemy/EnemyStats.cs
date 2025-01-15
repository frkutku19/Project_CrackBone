using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public Dictionary<string,float> enemyStats = new Dictionary<string,float>();

    private void Awake()
    {
        enemyStats.TryAdd("Health", 100);
        enemyStats.TryAdd("Speed", Random.Range(2f, 4f));
        enemyStats.TryAdd("Range", 5);
    }
}
