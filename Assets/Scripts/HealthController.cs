using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour {
    public int health;

    float damageToForceRatio = 10f;

    bool dead = false;

    Rigidbody2D rb;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    public void TakeDamage (int damage, Vector2 hitPos) {
        health -= damage;

        Vector2 hitDir = (hitPos - (Vector2)transform.position).normalized;
        rb.AddForce(hitDir * damage * damageToForceRatio);

        if (health <= 0) {
            Die();
        }
    }

    void Die() {
        dead = true;


        Destroy(GetComponent<MovementController>());
        //Destroy(gameObject);
    }
}
