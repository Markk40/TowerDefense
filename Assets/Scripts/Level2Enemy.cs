using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Zombie : Enemy
{
    private GameObject _prefab;

    public Level2Zombie(GameObject prefab)
    {
        _prefab = prefab;
    }

    public override void Initialize(Vector3 position, List<Transform> waypoints)
    {
        GameObject enemy = GameObject.Instantiate(_prefab, position, Quaternion.identity);
        enemy.GetComponent<EnemyMovement>().waypoints = waypoints;
    }
}
