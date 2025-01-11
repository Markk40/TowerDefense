using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterGenerator : MonoBehaviour
{
    public GameObject baseZombiePrefab;
    public GameObject level2ZombiePrefab;
    public List<Transform> waypoints;
    public float interval = 2.0f;
    public float minimumInterval = 0.5f;
    public int enemiesPerIncrease = 15;

    private int generatedEnemies = 0;
    private System.Random random = new System.Random();

    void Start()
    {
        StartCoroutine(GenerateEnemies());
    }

    IEnumerator GenerateEnemies()
    {
        while (true)
        {
            GameObject clonedEnemy;

            if (generatedEnemies >= 75)
            {
                clonedEnemy = Instantiate(level2ZombiePrefab, waypoints[0].position, Quaternion.identity);
            }
            else if (generatedEnemies >= 15 && random.Next(100) < 40)
            {
                clonedEnemy = Instantiate(level2ZombiePrefab, waypoints[0].position, Quaternion.identity);
            }
            else
            {
                clonedEnemy = Instantiate(baseZombiePrefab, waypoints[0].position, Quaternion.identity);
            }

            clonedEnemy.SetActive(true);
            EnemyMovement enemyScript = clonedEnemy.GetComponent<EnemyMovement>();
            enemyScript.waypoints = waypoints;

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
