using UnityEngine;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour
{
    public List<Transform> waypoints; // Lista de waypoints
    public float speed = 3.0f; // Velocidad de movimiento del monstruo
    public float rotationSpeed = 5.0f; // Velocidad de rotación del monstruo
    public int health = 100; // Vida del zombie
    private int currentPoint = 0; // Índice del waypoint actual
    private Animator animator; // Referencia al Animator del monstruo
    private bool isDead = false; // Indica si el zombie está muerto
    private const int deadPoints = 5;

    void Start()
    {
        animator = GetComponent<Animator>();

        if (waypoints.Count > 0)
        {
            transform.position = waypoints[0].position;
        }
    }

    void Update()
    {
        if (isDead) return;

        if (currentPoint < waypoints.Count)
        {
            Transform target = waypoints[currentPoint];
            Vector3 direction = target.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            transform.position += direction.normalized * speed * Time.deltaTime;

            if (direction.magnitude < 0.1f)
            {
                currentPoint++;
            }
        }
        else
        {
            ReachEnd();
        }
    }

    void ReachEnd()
    {
        isDead = true;
        animator.SetTrigger("Morir");
        Destroy(gameObject, 2f);
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;

        health -= amount;

        if (health <= 0)
        {
            isDead = true;
            animator.SetTrigger("Morir");
            ScoreManager.Instance.AddPoints(deadPoints);
            Destroy(gameObject, 2f);
        }
    }
}

