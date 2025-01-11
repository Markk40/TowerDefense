using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory
{
    private GameObject normalZombiePrefab;
    private GameObject level2ZombiePrefab;

    public EnemyFactory(GameObject normalPrefab, GameObject level2Prefab)
    {
        normalZombiePrefab = normalPrefab;
        level2ZombiePrefab = level2Prefab;
    }

    public Enemy CreateEnemy(int totalEnemiesGenerated)
    {
        float chance = Random.Range(0f, 1f);
        if (totalEnemiesGenerated >= 75)
        {
            return new Level2Zombie(level2ZombiePrefab);
        }
        else if (totalEnemiesGenerated > 15 && chance <= 0.4f)
        {
            return new Level2Zombie(level2ZombiePrefab);
        }
        else
        {
            return new Level1Enemy(normalZombiePrefab);
        }
    }
}
