﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int points = 40;
    public Transform shottingOffset;
    public delegate void EnemyDied(int pointsWorth);
    public static event EnemyDied OnEnemyDied;
    public Player player;

    public float interval = 2f;
    private float timer;
    private float bulletSpeed = 10f;
    RaycastHit hit;
    private float timeCounter;
    private static float enemySpeedUp = 0.1f;
    private float enemyMoveSpeed = 100f;
    private float totalDistance;
    private bool travelLeft;

    private void Start()
    {
        enemySpeedUp = 1f;
    }

    void Update()
    {
        timer += Time.deltaTime;
        timeCounter += Time.deltaTime;
        
        if (timer >= interval)
        {
            timer = 0f;
            Fire();
        }
        if (player != null && enemySpeedUp < 0.5f)
        {
            player.UpgradeWeapon();
        }
        
        if (travelLeft)
        {
            if (timeCounter > 0.1f)
            {
                if ((int)totalDistance < -800)
                {
                    travelLeft = false;
                    Vector3 enemyDownStep = new Vector3(0, -enemyMoveSpeed * Time.deltaTime, 0);
                    gameObject.transform.Translate(enemyDownStep);
                }
                else
                {
                    Vector3 enemyMoveStep = new Vector3(-enemyMoveSpeed * Time.deltaTime, 0, 0);

                    gameObject.transform.Translate(enemyMoveStep);
                    totalDistance -= enemyMoveSpeed;
                }

                timeCounter = 0.0f;
            }
        }
        else
        {
            if (timeCounter > 0.1f)
            {
                if ((int)totalDistance > 1000)
                {
                    travelLeft = true;
                    Vector3 enemyDownStep = new Vector3(0, -enemyMoveSpeed * Time.deltaTime, 0);
                    gameObject.transform.Translate(enemyDownStep);
                }
                else
                {
                    Vector3 enemyMoveStep = new Vector3(enemyMoveSpeed * Time.deltaTime, 0, 0);

                    gameObject.transform.Translate(enemyMoveStep);
                    totalDistance += enemyMoveSpeed;
                }

                timeCounter = 0.0f;
            }
        }
    }
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("speed before: " + enemySpeedUp);
            enemySpeedUp -= 0.02f;
            Debug.Log("speed after: " + enemySpeedUp);
            OnEnemyDied.Invoke(points);
            
            Destroy(gameObject);
            Destroy(other.gameObject);
            
            
        }
        
    }
    void Fire()
    {
        GameObject shot = Instantiate(bulletPrefab, shottingOffset.position, Quaternion.identity);
        Rigidbody shotRigidbody = shot.GetComponent<Rigidbody>();
        shotRigidbody.velocity = Vector2.down * bulletSpeed; 
        if (shot != null)
            Destroy(shot, 3f);
    }
}
