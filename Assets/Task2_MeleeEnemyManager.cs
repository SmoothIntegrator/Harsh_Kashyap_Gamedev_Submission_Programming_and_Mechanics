using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Task2_MeleeEnemyManager : Task2_EnemyManager
{
    [Header("Melee Settings")]
    public float attackRange;
    public float attackCooldown;
    public float moveSpeed = 8f;  

    [Header("Patrol Settings")]
    public Transform pointA;
    public Transform pointB;
    private Transform currentPatrolTarget;

    private bool canAttack = true;
    private float currentCooldownTimer;
    private Rigidbody2D rb;

    protected override void Start()
    {
        base.Start();
        currentPatrolTarget = pointA;
        rb = GetComponent<Rigidbody2D>();
    }

    protected override void Update()
    {
        base.Update();

        if (!canAttack)
        {
            HandleAttackCooldown();
        }

        if (playerDetected)
        {
            ChasePlayer();

            if (Vector2.Distance(rb.position, player.position) <= attackRange)
            {
                PerformAttack();
            }
        }
        else
        {
            Patrol();
        }
    }

    protected override void ChasePlayer()
    {
        Vector2 nextStep = Vector2.MoveTowards(rb.position, player.position, moveSpeed * Time.deltaTime);
        rb.MovePosition(nextStep);
    }

    private void PerformAttack()
    {
        Debug.Log("YOU GOT CAUGHT! Restarting...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        canAttack = false;
        currentCooldownTimer = attackCooldown;
    }

    private void HandleAttackCooldown()
    {
        currentCooldownTimer -= Time.deltaTime;
        if (currentCooldownTimer <= 0)
        {
            canAttack = true;
        }
    }

    protected override void Patrol()
    {
        Vector2 nextStep = Vector2.MoveTowards(rb.position, currentPatrolTarget.position, moveSpeed * Time.deltaTime);
        rb.MovePosition(nextStep);

        if (Vector2.Distance(rb.position, currentPatrolTarget.position) <= 0.2f)
        {
            if (currentPatrolTarget == pointA)
            {
                currentPatrolTarget = pointB;
            }
            else
            {
                currentPatrolTarget = pointA;
            }
        }
    }
}