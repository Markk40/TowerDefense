using UnityEngine;
using System.Collections.Generic;

public abstract class TurretBase : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab de la bala
    public float fireInterval = 1f; // Intervalo entre disparos
    private int turretLevel = 1;

    protected float fireTimer = 0f;
    protected List<GameObject> enemiesInRange = new List<GameObject>(); // Lista de enemigos dentro del rango
    protected Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>(); // Inicializa el Animator
        animator.SetBool("isShooting", false);
    }

    void Update()
    {
        fireTimer += Time.deltaTime;

        GameObject closestEnemy = GetClosestEnemy();

        if (closestEnemy != null)
        {
            AimAtEnemy(closestEnemy.transform);

            if (fireTimer >= fireInterval)
            {
                if (animator != null)
                {
                    animator.SetTrigger("Shoot");
                }

                Fire(closestEnemy.transform);
                fireTimer = 0f;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            enemiesInRange.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            enemiesInRange.Remove(other.gameObject);
        }
    }

    GameObject GetClosestEnemy()
    {
        GameObject closestEnemy = null;
        float minDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemiesInRange)
        {
            if (enemy != null)
            {
                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestEnemy = enemy;
                }
            }
        }

        return closestEnemy;
    }

    protected void AimAtEnemy(Transform enemy)
    {
        Vector3 direction = (enemy.position - transform.position).normalized;
        Quaternion lookAtEnemyRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookAtEnemyRotation, Time.deltaTime * 5f);
    }

    protected abstract void Fire(Transform target); // Método abstracto para que cada torreta implemente su disparo específico

    public int TurretLevel
    {
        get => turretLevel;
        set => turretLevel = value;
    }
}
