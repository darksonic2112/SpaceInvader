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
    
    public float interval = 2f;
    private float timer;
    private float bulletSpeed = 10f;
    RaycastHit hit;

    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= interval)
        {
            timer = 0f;
            Fire();
        }
    }
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
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
