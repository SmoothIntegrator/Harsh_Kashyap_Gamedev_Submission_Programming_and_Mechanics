using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class Task2_Projectile : MonoBehaviour
{
    public float speed = 7f;
    public float lifetime = 3f;

    private Vector2 moveDirection;

    void Start()
    {
        Destroy(gameObject, lifetime);
        GameObject player = GameObject.Find("Player");

        if (player != null)
        {
            moveDirection = (player.transform.position - transform.position).normalized;
        }
    }

    void Update()
    {
         
        transform.position += (Vector3)(moveDirection * speed * Time.deltaTime);

         
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
             
            if (Vector2.Distance(transform.position, player.transform.position) < 0.5f)
            {
                Debug.Log("YOU GOT SHOT (Math Check)! Restarting...");
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            }
        }
    }

     
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("YOU GOT SHOT! Restarting...");
           
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(gameObject);  
        }
    }
}