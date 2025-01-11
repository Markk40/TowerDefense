using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy
{
    public abstract void Initialize(Vector3 position, List<Transform> waypoints);
}
