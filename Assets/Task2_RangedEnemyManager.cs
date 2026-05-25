using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task2_RangedEnemyManager : Task2_EnemyManager
{
    [Header("Ranged Settings")]
    public float preferredDistance;
    public float moveSpeed = 8f;  

    [Header("Patrol Settings")]
    public Transform pointA;
    public Transform pointB;
    private Transform currentPatrolTarget;

    [Header("Weapon Settings")]
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float shootingCooldown = 2f;

    private bool canShoot = true;
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

        if (!canShoot)
        {
            HandleShootCooldown();
        }

        if (playerDetected)
        {
            MaintainDistance();

            if (canShoot)
            {
                ShootProjectile();
            }
        }
        else
        {
            Patrol();
        }
    }

    private void MaintainDistance()
    {
        float currentDistance = Vector2.Distance(rb.position, player.position);

        if (currentDistance > preferredDistance)
        {
            Vector2 nextStep = Vector2.MoveTowards(rb.position, player.position, moveSpeed * Time.deltaTime);
            rb.MovePosition(nextStep);
        }
        else if (currentDistance < preferredDistance)
        {
            Vector2 nextStep = Vector2.MoveTowards(rb.position, player.position, -moveSpeed * Time.deltaTime);
            rb.MovePosition(nextStep);
        }
    }

    private void ShootProjectile()
    {
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        canShoot = false;
        currentCooldownTimer = shootingCooldown;
    }

    private void HandleShootCooldown()
    {
        currentCooldownTimer -= Time.deltaTime;
        if (currentCooldownTimer <= 0)
        {
            canShoot = true;
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