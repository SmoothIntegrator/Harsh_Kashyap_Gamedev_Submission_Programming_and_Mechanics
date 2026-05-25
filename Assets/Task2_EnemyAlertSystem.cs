using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task2_EnemyManager : MonoBehaviour
{
    [Header("Detection")]
    public float detectionRange;
    public LayerMask playerLayer;

    [Header("References")]
    public Transform player;

    protected bool playerDetected;
    protected bool isAlerted;

    private float alertTimer;

    protected virtual void Start() { }

    protected virtual void Update()
    {
        
        if (isAlerted)
        {
            alertTimer -= Time.deltaTime;
            if (alertTimer <= 0)
            {
                isAlerted = false;
            }
        }

        DetectPlayer();

        if (playerDetected)
        {
            AlertNearbyEnemies();
        }
    }

    protected virtual void DetectPlayer()
    {
        if (isAlerted)
        {
            playerDetected = true;
        }
        else
        {
            playerDetected = Physics2D.OverlapCircle(transform.position, detectionRange, playerLayer);
        }
    }

    protected virtual void AlertNearbyEnemies() { }

    public virtual void ReceiveAlert(Vector3 playerPosition)
    {
        isAlerted = true;
        alertTimer = 2f; 
    }

    protected virtual void Patrol() { }
    protected virtual void ChasePlayer() { }
    protected virtual void ReturnToPatrol() { }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}