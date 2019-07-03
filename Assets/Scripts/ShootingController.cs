using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour {
    public GameObject projectilePrefab;
    public Transform projectileSpawn;
    public float projectileSpeed;
    public float fireRate;
    float fireTimer = 0f;

    int playerID;

	// Use this for initialization
	void Start () {
        playerID = GetComponent<HealthController>().playerID;
	}

    public void AttemptShoot () {
        if (fireTimer <= 0f)
            Shoot();
    }

    void Shoot () {
        fireTimer = fireRate;

        GameObject newProjectile = Instantiate(projectilePrefab, projectileSpawn.position, projectileSpawn.rotation);
        newProjectile.GetComponent<Rigidbody2D>().velocity = projectileSpawn.right * projectileSpeed;
        newProjectile.GetComponent<ProjectileController>().Init(playerID);
    }
	
	void Update () {
        if (fireTimer > 0f)
            fireTimer -= Time.deltaTime;
	}
}
