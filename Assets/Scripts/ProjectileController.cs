using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {
    public int damage;

    int ownerID;

    public void Init (int ownerID) {
        this.ownerID = ownerID;
        Destroy(gameObject, 5f);
    }

    void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Player") {
            HealthController healthCon = coll.gameObject.GetComponent<HealthController>();
            if (healthCon.playerID != ownerID) {
                healthCon.TakeDamage(damage, (Vector2)transform.position);
                Destroy(gameObject);
            }
        } else {
            Destroy(gameObject);
        }
    }
}
