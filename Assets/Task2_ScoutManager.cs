using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]  
public class Task2_ScoutManager : Task2_EnemyManager
{
    [Header("Camera Settings")]
    public float sweepSpeed = 2f;
    public float sweepAngle = 45f;
    private float startRotation;

    [Header("Vision & Lasers")]
    public LayerMask obstacleLayer;  
    private LineRenderer lineRenderer;

    protected override void Start()
    {
        base.Start();
        startRotation = transform.eulerAngles.z;

         lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;  
    }

    protected override void Update()
    {
        base.Update();

        if (!playerDetected)
        {
            SweepCamera();
        }
    }

    private void SweepCamera()
    {
        float angle = Mathf.Sin(Time.time * sweepSpeed) * sweepAngle;
        transform.rotation = Quaternion.Euler(0, 0, startRotation + angle);
    }

    protected override void DetectPlayer()
    {
         int combinedMask = playerLayer | obstacleLayer;

         RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, detectionRange, combinedMask);

         lineRenderer.SetPosition(0, transform.position);

         if (hit.collider != null)
        {
             lineRenderer.SetPosition(1, hit.point);

             if (((1 << hit.collider.gameObject.layer) & playerLayer) != 0)
            {
                playerDetected = true;
            }
            else
            {
                 playerDetected = false;
            }
        }
        else
        {
             playerDetected = false;
            lineRenderer.SetPosition(1, transform.position + transform.right * detectionRange);
        }
    }

    protected override void AlertNearbyEnemies()
    {
        Task2_EnemyManager[] allEnemies = FindObjectsOfType<Task2_EnemyManager>();
        foreach (Task2_EnemyManager enemy in allEnemies)
        {
            if (enemy != this)
            {
                enemy.ReceiveAlert(player.position);
            }
        }
    }
}