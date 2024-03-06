using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shottingOffset;
    public AudioClip shootingSound;

    private float moveSpeed = 10f;
    private float leftSideEnd = -7f;
    private float rightSideEnd = 7f;
    private string playerAxis = "Horizontal";
    private float bulletSpeed = 10f;
    RaycastHit hit;
    private AudioSource audioSource;
    private bool isFiring;
    private float fireCooldown = 0.5f;
    private float lastFireTime;
    private bool upgradeWeapon;
    private void Start()
    {
        Enemy.OnEnemyDied += EnemyOnOnEnemyDied;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = shootingSound;
    }

    private void OnDestroy()
    {
        Enemy.OnEnemyDied -= EnemyOnOnEnemyDied;
    }

    void EnemyOnOnEnemyDied(int pointsWorth)
    {
        Debug.Log($"Player received 'EnemyDied' worth {pointsWorth}");
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

    void Update()
    {
        float playerInput = Input.GetAxis(playerAxis);
        MovePlayer(playerInput);

        if (Input.GetKey(KeyCode.Space))
        {
            if (Time.time - lastFireTime >= fireCooldown)
            {
                isFiring = true;
            }
        }
        else
        {
            isFiring = false;
        }
        if (isFiring)
        {
            Fire();
            lastFireTime = Time.time;
            isFiring = false;
        }
    }

    void MovePlayer(float input)
    {
        GameObject player = GameObject.Find("Player");
        float moveAmount = input * moveSpeed * Time.deltaTime;

        Vector3 newPosition = player.transform.position + new Vector3(moveAmount, 0, 0);

        if (newPosition.x >= leftSideEnd && newPosition.x <= rightSideEnd)
        {
            player.transform.Translate(new Vector3(moveAmount, 0, 0));
        }
        else
        {
            float clampedX = Mathf.Clamp(newPosition.x, leftSideEnd, rightSideEnd);
            player.transform.position = new Vector3(clampedX, player.transform.position.y, player.transform.position.z);
        }
        
    }

    void Fire()
    {
        audioSource.Play();
        if (!upgradeWeapon)
        {
            GameObject shot = Instantiate(bulletPrefab, shottingOffset.position, Quaternion.identity);
            Rigidbody shotRigidbody = shot.GetComponent<Rigidbody>();
            shotRigidbody.velocity = Vector2.up * bulletSpeed;
            if (shot != null)
                Destroy(shot, 3f);
        }
        else
        {
            Vector3 bullet1position = new Vector3(shottingOffset.position.x - 0.1f, shottingOffset.position.y,
                shottingOffset.position.z);
            Vector3 bullet2position = new Vector3(shottingOffset.position.x + 0.1f, shottingOffset.position.y,
                shottingOffset.position.z);
            GameObject shot = Instantiate(bulletPrefab, bullet1position, Quaternion.identity);
            GameObject shot2 = Instantiate(bulletPrefab, bullet2position, Quaternion.identity);
            Rigidbody shotRigidbody = shot.GetComponent<Rigidbody>();
            Rigidbody shotRigidbody2 = shot2.GetComponent<Rigidbody>();
            shotRigidbody.velocity = Vector2.up * bulletSpeed;
            shotRigidbody2.velocity = Vector2.up * bulletSpeed;
            if (shot != null)
                Destroy(shot, 3f);
            if (shot2 != null)
                Destroy(shot, 3f);
        }

    }

    public void UpgradeWeapon()
    {
        upgradeWeapon = true;
    }
}