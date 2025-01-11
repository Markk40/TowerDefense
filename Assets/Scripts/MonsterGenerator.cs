using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterGenerator : MonoBehaviour
{
    public GameObject level1ZombiePrefab;
    public GameObject level2ZombiePrefab;
    public List<Transform> waypoints;
    public float interval = 2.0f;
    public float minimumInterval = 0.5f;
    public int enemiesPerIncrease = 15;

    private int generatedEnemies = 0;
    private System.Random random = new System.Random();
    private EnemyFactory enemyFactory;

    void Start()
    {
        enemyFactory = new EnemyFactory(level1ZombiePrefab, level2ZombiePrefab);
        StartCoroutine(GenerateEnemies());
    }

    IEnumerator GenerateEnemies()
    {
        while (true)
        {
            Enemy enemigo = enemyFactory.CreateEnemy(generatedEnemies);
            enemigo.Initialize(waypoints[0].position, waypoints);

            generatedEnemies++;

            if (generatedEnemies % enemiesPerIncrease == 0)
            {
                ReduceDifficulty();
            }

            yield return new WaitForSeconds(interval);
        }
    }

    void ReduceDifficulty()
    {
        if (interval > minimumInterval)
        {
            interval -= 0.5f;
            interval = Mathf.Max(interval, minimumInterval);
        }
    }
}
